using UnityEngine;
using System.Collections;
using System;

public class SupportImpl
{

}

public class FireSupport : SupportInterface
{
    int tier;

    public FireSupport(int tier)
    {
        this.tier = tier;
    }

    public void ApplyArtillerySupport(ArtilleryModel model)
    {
        model.damageType = DamageType.Explosive;
        model.damage = Mathf.RoundToInt(model.originalDamage * (1 + (0.1f * tier)));
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
        model.Reset();
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
    }
}

public class EarthSupport : SupportInterface
{
    int tier;

    public EarthSupport(int tier)
    {
        this.tier = tier;
    }

    public void ApplyArtillerySupport(ArtilleryModel model)
    {
        model.damageType = DamageType.Impact;
        model.damage = Mathf.RoundToInt(model.originalDamage * (1 + (0.1f * tier)));
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
        model.Reset();
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
    }
}

public class IceSupport : SupportInterface
{
    int tier;

    public IceSupport(int tier)
    {
        this.tier = tier;
    }

    public void ApplyArtillerySupport(ArtilleryModel model)
    {
        model.damageType = DamageType.Piercing;
        model.fireDelay = model.originalFireDelay * (1 / (1 + (0.1f * tier)));
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
        model.Reset();
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
    }
}

public class ThunderSupport : SupportInterface
{
    int tier;

    public ThunderSupport(int tier)
    {
        this.tier = tier;
    }

    public void ApplyArtillerySupport(ArtilleryModel model)
    {
        model.damageType = DamageType.Magic;
        model.fireDelay = model.originalFireDelay * (1 / (1 + (0.1f * tier)));
    }

    public void ProjectileSupport(GameObject projectilePool)
    {
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
        model.Reset();
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
    }
}