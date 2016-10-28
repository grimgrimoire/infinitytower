using UnityEngine;
using System.Collections;

public interface SupportInterface {
    void ProjectileSupport(GameObject projectilePool);
    void RemoveProjectileSupport(GameObject projectilePool);
    void ArtillerySupport();
}


public interface SupportUpdatedInterface{
    void RemoveSupport();
    void ApplySupport();
}