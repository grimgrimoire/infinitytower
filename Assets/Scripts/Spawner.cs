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

    public void SpawnEnemy(GameObject peon)
    {
        peon.SetActive(true);
        peon.transform.position = transform.position;
        peon.GetComponent<HostileMainScript>().Recycle();
    }
}
