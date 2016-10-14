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

    // Use this for initialization
    void Start()
    {
        artilleryName = "No weapon installed";
        projectile = Resources.Load("prefab/arrow", typeof(GameObject)) as GameObject;
        StartCoroutine(shootTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (model != null)
        {
            if (lockedTarget == null)
            {
                FindNewTarget();
            }
            else
            {
                Debug.DrawLine(transform.position, lockedTarget.transform.position);
                if (!IsTargetInRange(lockedTarget))
                    lockedTarget = null;
            }
        }
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
        artilleryName = model.name;
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        GameObject graphics = (GameObject)Instantiate(Resources.Load(model.ingameModelPrefabName, typeof(GameObject)) as GameObject, transform);
        graphics.transform.localPosition = Vector3.zero;
        if (isLeft)
            graphics.transform.localScale = new Vector3(-1, 1, 1);
    }

    public ArtilleryModel GetModel()
    {
        return model;
    }

    IEnumerator shootTarget()
    {
        while (true)
        {
            if (lockedTarget != null)
            {
                GameObject bullet = Instantiate(projectile);
                bullet.transform.position = transform.position;
                bullet.GetComponent<ArtilleryProjectile>()
                    .SetDamageType(model.damage, model.damageType)
                    .SetTarget(lockedTarget.transform.position);
                yield return new WaitForSeconds(model.fireDelay);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void FindNewTarget()
    {
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (IsTargetInRange(hostile))
            {
                lockedTarget = hostile;
                break;
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
}
