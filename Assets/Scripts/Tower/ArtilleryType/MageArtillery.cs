using UnityEngine;
using System.Collections;
using System;

public class MageArtillery : ArtilleryInterface {

    ArtilleryModel model;

    public MageArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    public void ShootAtTarget(GameObject target, GameObject artillery, GameObject projectilePrefab)
    {
    }
}
