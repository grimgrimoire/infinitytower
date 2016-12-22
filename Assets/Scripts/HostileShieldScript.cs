using UnityEngine;
using System.Collections;
using System;

public class HostileShieldScript : MonoBehaviour, HostileInterface {

    public GameObject shield;

    public void OnKilled()
    {
    }

    public void OnRecycled()
    {
        shield.gameObject.SetActive(true);
        shield.GetComponent<HostileMainScript>().SetHealthAndGoldMultiplier(0, GameSystem.GetGameSystem().GetSpawnSystem().healthMultiplier);
        shield.GetComponent<HostileMainScript>().Recycle();
        StartCoroutine(CheckShield());
    }

    IEnumerator CheckShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!shield.activeSelf)
                break;
        }
        GetComponent<HostileMainScript>().SetSpeed(3);
    }

}
