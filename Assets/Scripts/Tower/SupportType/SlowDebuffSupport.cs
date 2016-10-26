using UnityEngine;
using System.Collections;
using System;

public class SlowDebuffSupport : SupportInterface
{

    public void ArtillerySupport()
    {
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
        projectilePool.AddComponent<SlowDebuff>();
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
        GameObject.Destroy(projectilePool.GetComponent<SlowDebuff>());
    }
}
