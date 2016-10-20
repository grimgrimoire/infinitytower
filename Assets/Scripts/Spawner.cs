using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour
{

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        InvokeRepeating("SpawnEnemy", 3, 3);
    }

    void SpawnEnemy()
    {
        GameObject peon = GameSystem.GetGameSystem().GetObjectPool().GetPeon1();
        if (peon == null)
            return ;
        peon.SetActive(true);
        peon.transform.position = transform.position;
        peon.GetComponent<HostileMainScript>().Recycle();
    }
}
