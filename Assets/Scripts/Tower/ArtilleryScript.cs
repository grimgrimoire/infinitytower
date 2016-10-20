using UnityEngine;
using System.Collections;

public class ArtilleryScript : MonoBehaviour
{

    public bool isLeft;
    private string artilleryName;
    private SupportScript supportScript;
    private GameObject lockedTarget;
    private GameObject projectile;
    private ArtilleryModel model;

    private GameObject[] projectilePool;
    private int projectilePoolIndex;

    // Use this for initialization
    void Start()
    {
        artilleryName = "No weapon installed";
    }

    public string getName()
    {
        return artilleryName;
    }

    public void setSupport(SupportScript supportScript)
    {
        this.supportScript = supportScript;
    }

    public void SetModel(ArtilleryModel model)
    {
        this.model = model;
        StopAllCoroutines();
        artilleryName = model.name;
        EmptyProjectilePrefab();
        PreloadProjectile();
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        GameObject graphics = (GameObject)Instantiate(Resources.Load(model.ingameModelPrefabName, typeof(GameObject)) as GameObject, transform);
        graphics.transform.localPosition = Vector3.zero;
        if (isLeft)
            graphics.transform.localScale = new Vector3(-graphics.transform.localScale.x, graphics.transform.localScale.y, graphics.transform.localScale.z);
        System.GC.Collect();
        StartCoroutine(shootTarget());
    }

    public ArtilleryModel GetModel()
    {
        return model;
    }

    IEnumerator shootTarget()
    {
        while (true)
        {
            if (lockedTarget == null)
            {
                FindNewTarget();
            }
            else
            {
                if (IsTargetInRange(lockedTarget))
                {
                    yield return model.shootImpl.ShootAtTarget(lockedTarget, gameObject, projectilePool[projectilePoolIndex]);
                    projectilePoolIndex = (projectilePoolIndex + 1) % 5;
                    yield return new WaitForSeconds(model.fireDelay);
                }
                else
                {
                    lockedTarget = null;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void FindNewTarget()
    {
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (IsTargetInRange(hostile))
            {
                if (lockedTarget == null)
                    lockedTarget = hostile;
                else if (Vector2.Distance(transform.position, hostile.transform.position) < Vector2.Distance(transform.position, lockedTarget.transform.position))
                    lockedTarget = hostile;
            }
        }
    }

    private bool IsTargetInRange(GameObject hostile)
    {
        if (isLeft)
        {
            return hostile.transform.position.x < transform.position.x && Vector2.Distance(transform.position, hostile.transform.position) < model.lockRange;
        }
        else
        {
            return hostile.transform.position.x > transform.position.x && Vector2.Distance(transform.position, hostile.transform.position) < model.lockRange;
        }
    }

    private void EmptyProjectilePrefab()
    {
        if(projectilePool != null)
        {
            for (int i = 0; i < 5; i++)
            {
                Destroy(projectilePool[i]);
            }
        }
    }

    private void PreloadProjectile()
    {
        projectile = Resources.Load(model.projectilePrefabName, typeof(GameObject)) as GameObject;
        projectilePool = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            projectilePool[i] = Instantiate(projectile);
            projectilePool[i].transform.position = new Vector2(3, -10) ;
            projectilePool[i].SetActive(false);
        }
    }
}
