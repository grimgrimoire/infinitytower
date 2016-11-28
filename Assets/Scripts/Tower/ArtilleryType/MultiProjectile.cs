using UnityEngine;
using System.Collections;

public class MultiProjectile : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    public MultiProjectile(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        Shoot(target.transform.position, artillery, projectilePrefab);
        Shoot(target.transform.position, artillery, projectilePrefab);
        Shoot(target.transform.position, artillery, projectilePrefab);
        yield return null;
    }

    private void Shoot(Vector2 target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target + Random.insideUnitCircle);
        poolIndex = (poolIndex + 1) % model.poolSize;
    }
}
