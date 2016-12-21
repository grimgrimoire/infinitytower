using UnityEngine;
using System.Collections;

public class PrecisionProjectileArtillery : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;
    int projectileSpeed = 5;

    public PrecisionProjectileArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    public PrecisionProjectileArtillery(ArtilleryModel model, int projectileSpeed)
    {
        this.model = model;
        this.projectileSpeed = projectileSpeed;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<PrecisionProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target);
        poolIndex = (poolIndex + 1) % model.poolSize;
        yield return null;
    }
}
