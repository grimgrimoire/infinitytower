using UnityEngine;
using System.Collections;
using System;

public class MageArtillery : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    public MageArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        Shoot(target, artillery, projectilePrefab);
        yield return new WaitForSeconds(0.2f);
        Shoot(target, artillery, projectilePrefab);
        yield return new WaitForSeconds(0.2f);
        Shoot(target, artillery, projectilePrefab);
        yield return null;
    }

    private void Shoot(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < 5)
        {
            poolIndex = (poolIndex + 1) % 5;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % 5;
    }
}
