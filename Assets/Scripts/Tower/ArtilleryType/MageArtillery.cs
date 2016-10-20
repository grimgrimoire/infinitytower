using UnityEngine;
using System.Collections;
using System;

public class MageArtillery : ArtilleryInterface {

    ArtilleryModel model;

    public MageArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject projectilePrefab)
    {
        projectilePrefab.SetActive(true);
        projectilePrefab.transform.position = artillery.transform.position;
        projectilePrefab.GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        yield return null;
    }
}
