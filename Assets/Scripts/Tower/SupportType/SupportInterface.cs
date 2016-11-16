using UnityEngine;
using System.Collections;

public interface SupportInterface {
    void ProjectileSupport(GameObject projectilePool);
    void RemoveProjectileSupport(GameObject projectilePool);
    void ApplyArtillerySupport(ArtilleryModel model);
    void RemoveArtillerySupport(ArtilleryModel model);
}


public interface SupportUpdatedInterface{
    void RemoveSupport();
    void ApplySupport();
}