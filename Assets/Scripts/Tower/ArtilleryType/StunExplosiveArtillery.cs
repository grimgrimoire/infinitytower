using UnityEngine;
using System.Collections;

public class StunExplosiveArtillery : ArtilleryInterface
{

    ArtilleryModel model;
    int poolIndex;
    int counter;
    int stunChance = 30;

    public StunExplosiveArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    public StunExplosiveArtillery(ArtilleryModel model, int stunChance)
    {
        this.model = model;
        this.stunChance = stunChance;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < 5)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<StunExplosiveProjectile>()
            .SetStunChance(stunChance)
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % model.poolSize;
        yield return null;
    }
}
