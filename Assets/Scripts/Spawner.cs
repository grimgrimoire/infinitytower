using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy(GameObject peon, int goldM, float healthM)
    {
        if (peon == null) return;

        peon.SetActive(true);
        peon.transform.position = transform.position;
        peon.GetComponent<HostileMainScript>().SetHealthAndGoldMultiplier(goldM, healthM);
        peon.GetComponent<HostileMainScript>().Recycle();
    }

    public bool IsGroundSpawner()
    {
        return transform.position.y < -0.17f;
    }
}
