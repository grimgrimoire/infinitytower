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
    private TowerAimingInterface aimingInterface;

    // Use this for initialization
    void Start()
    {
        artilleryName = "No weapon installed";
        supportScript = gameObject.GetComponentInParent<SupportScript>();
    }

    void Update()
    {
        if (aimingInterface != null)
            if(lockedTarget != null)
                aimingInterface.SetAiming(lockedTarget.transform.position);
    }

    public string getName()
    {
        return artilleryName;
    }

    public SupportScript GetSupport()
    {
        return supportScript;
    }

    public void SetAimingInterface(TowerAimingInterface aImpl)
    {
        aimingInterface = aImpl;
    }

    public void SetModel(ArtilleryModel model)
    {
        this.model = model;
        StopAllCoroutines();
        artilleryName = model.name + " " + model.upgradeCode + " " + model.upgradeBranch;
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
        RemoveOldArtillery();
        if (model.shootImpl != null)
            ApplyNewArtillery();
        System.GC.Collect();
        lockedTarget = null;
    }

    public void RemoveArtillery()
    {
        this.model = null;
        StopAllCoroutines();
        RemoveOldArtillery();
    }

    private void RemoveOldArtillery()
    {
        EmptyProjectilePrefab();
        aimingInterface = null;
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    private void ApplyNewArtillery()
    {
        PreloadProjectile();
        ApplySupportedEffect();
        GameObject graphics = (GameObject)Instantiate(Resources.Load(model.ingameModelPrefabName, typeof(GameObject)) as GameObject, transform);
        graphics.transform.localPosition = Vector3.zero;
        if (isLeft)
            graphics.transform.localScale = new Vector3(-graphics.transform.localScale.x, graphics.transform.localScale.y, graphics.transform.localScale.z);
        StartCoroutine(shootTarget());
    }

    public ArtilleryModel GetModel()
    {
        return model;
    }

    IEnumerator shootTarget()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (lockedTarget == null || !lockedTarget.GetComponent<HostileMainScript>().isAlive)
            {
                FindNewTarget();
                yield return new WaitForFixedUpdate();
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
                    yield return new WaitForFixedUpdate();
                }
            }
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
                        if (model.targetingImpl.CheckPriorityCondition(lockedTarget, hostile, gameObject))
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
        projectilePool = new GameObject[model.poolSize];
        for (int i = 0; i < model.poolSize; i++)
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
        if (projectilePool != null)
            for (int i = 0; i < model.poolSize; i++)
            {
                supportScript.GetImplements().ProjectileSupport(projectilePool[i]);
            }
    }

    private void RemoveProjectileSupport()
    {
        if (projectilePool != null)
            for (int i = 0; i < model.poolSize; i++)
            {
                supportScript.GetImplements().RemoveProjectileSupport(projectilePool[i]);
            }
    }

    public void RemoveSupportedEffect()
    {
        if (supportScript.GetImplements() != null)
        {
            RemoveProjectileSupport();
            supportScript.GetImplements().RemoveArtillerySupport(model);
        }
    }

    public void ApplySupportedEffect()
    {
        if (supportScript.GetImplements() != null)
        {
            ApplyProjectileSupport();
            supportScript.GetImplements().ApplyArtillerySupport(model);
        }
    }
}
