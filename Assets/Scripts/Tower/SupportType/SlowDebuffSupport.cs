using UnityEngine;
using System.Collections;
using System;

public class SlowDebuffSupport : SupportInterface
{
    public void ApplyArtillerySupport(ArtilleryModel model)
    {
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
        projectilePool.AddComponent<SlowDebuff>();
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
        GameObject.Destroy(projectilePool.GetComponent<SlowDebuff>());
    }
}
