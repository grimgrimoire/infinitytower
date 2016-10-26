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

    // Use this for initialization
    void Start()
    {
        artilleryName = "No weapon installed";
        supportScript = GetComponent<SupportScript>();
    }

    public string getName()
    {
        return artilleryName;
    }

    public SupportScript GetSupport()
    {
        return supportScript;
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
            if (lockedTarget == null || !lockedTarget.activeSelf)
            {
                FindNewTarget();
            }
            else
            {
                if (IsTargetInRange(lockedTarget))
                {
                    yield return model.shootImpl.ShootAtTarget(lockedTarget, gameObject, projectilePool);
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
            if (hostile.activeSelf)
                if (IsTargetInRange(hostile))
                {
                    if (model.targetingImpl == null)
                    {
                        DefaultTargeting(hostile);
                    }
                    else
                    {
                        if (model.targetingImpl.CheckPriorityCondition(lockedTarget, hostile))
                        {
                            lockedTarget = hostile;
                        }
                    }
                }
        }
    }

    private void DefaultTargeting(GameObject hostile)
    {
        if (lockedTarget == null || !lockedTarget.activeSelf)
            lockedTarget = hostile;
        else if (Vector2.Distance(transform.position, hostile.transform.position) < Vector2.Distance(transform.position, lockedTarget.transform.position))
            lockedTarget = hostile;
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
        if (projectilePool != null)
        {
            for (int i = 0; i < projectilePool.Length; i++)
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
            projectilePool[i].transform.position = new Vector2(3, -10);
            if (supportScript.GetImplements() != null)
                supportScript.GetImplements().ProjectileSupport(projectilePool[i]);
            projectilePool[i].SetActive(false);
        }
    }

    private void ApplyProjectileSupport()
    {
        if (supportScript.GetImplements() != null)
            for (int i = 0; i < 5; i++)
            {
                supportScript.GetImplements().ProjectileSupport(projectilePool[i]);
            }
    }

    private void RemoveProjectileSupport()
    {
        if (supportScript.GetImplements() != null)
            for (int i = 0; i < 5; i++)
            {
                supportScript.GetImplements().RemoveProjectileSupport(projectilePool[i]);
            }
    }

    public void RemoveSupportedEffect()
    {
        RemoveProjectileSupport();
    }

    public void ApplySupportedEffect()
    {
        ApplyProjectileSupport();
    }
}
