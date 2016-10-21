using UnityEngine;
using System.Collections;

public interface ArtilleryInterface
{
    IEnumerator ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab);
}


public interface ArtilleryTargetingInterface
{
    bool CheckPriorityCondition(GameObject currentTarget, GameObject hostiles);
}