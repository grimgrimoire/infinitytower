using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunslingerArtillery : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    List<GameObject> targets;
    GameObject target;
    GameObject self;

    public GunslingerArtillery(ArtilleryModel model)
    {
        this.model = model;
        targets = new List<GameObject>();
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        yield return new WaitForSeconds(1f);
        this.target = target;
        self = artillery;
        targets.Clear();
        Shoot(artillery, projectilePrefab);
        for (int i = 0; i < 5; i++)
        {
            GetNewTarget();
            if (this.target == null)
                break;
            Shoot(artillery, projectilePrefab);
            yield return new WaitForSeconds(0.06f);
        }
        yield return null;
    }

    private void GetNewTarget()
    {
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (hostile.activeSelf)
            {
                if (!isAlreadyTarget(hostile))
                {
                    if (IsTargetInRange(hostile))
                    {
                        target = hostile;
                        break;
                    }
                }
            }
        }

    }

    private bool IsTargetInRange(GameObject hostile)
    {
        if (self.transform.position.x < 0)
        {
            return hostile.transform.position.x < self.transform.position.x && Vector2.Distance(self.transform.position, hostile.transform.position) < model.lockRange + 1;
        }
        else
        {
            return hostile.transform.position.x > self.transform.position.x && Vector2.Distance(self.transform.position, hostile.transform.position) < model.lockRange + 1;
        }
    }

    private bool isAlreadyTarget(GameObject hostile)
    {
        foreach(GameObject obj in targets)
        {
            if (obj.gameObject == hostile.gameObject)
                return true;
        }
        return false;
    }

    private void Shoot(GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        targets.Add(target);
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].GetComponent<PrecisionProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target);
        poolIndex = (poolIndex + 1) % model.poolSize;
        target = null;
    }
}
