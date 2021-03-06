﻿using UnityEngine;
using System.Collections;
using System;

public class GroundTargetOnly : ArtilleryTargetingInterface
{
    public bool CheckPriorityCondition(GameObject currentTarget, GameObject hostiles, GameObject self)
    {
        if (hostiles.GetComponent<HostileMainScript>().isGroundUnit)
        {
            if (currentTarget == null || !currentTarget.activeSelf)
                return true;
            else if (Vector2.Distance(self.transform.position, hostiles.transform.position) < Vector2.Distance(self.transform.position, currentTarget.transform.position))
                return true;
            else
                return false;
        }
        else
            return false;
    }
}

public class AirTargetOnly : ArtilleryTargetingInterface
{
    public bool CheckPriorityCondition(GameObject currentTarget, GameObject hostiles, GameObject self)
    {
        if (!hostiles.GetComponent<HostileMainScript>().isGroundUnit)
        {
            if (currentTarget == null || !currentTarget.activeSelf)
                return true;
            else if (Vector2.Distance(self.transform.position, hostiles.transform.position) < Vector2.Distance(self.transform.position, currentTarget.transform.position))
                return true;
            else
                return false;
        }
        else
            return false;
    }
}

public class HighestHealthOnly : ArtilleryTargetingInterface
{
    public bool CheckPriorityCondition(GameObject currentTarget, GameObject hostiles, GameObject self)
    {
        if (currentTarget == null || !currentTarget.activeSelf) {
            return true;
        }
        else if(currentTarget.GetComponent<HostileMainScript>().health < hostiles.GetComponent<HostileMainScript>().MaxHealth())
        {
            return true;
        }
        else{
            return false;
        }
    }
}