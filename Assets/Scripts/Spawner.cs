using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    string peon1 = "Prefab/EnemyPeon";
    string peon2 = "Prefab/EnemyPeon2";

    GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        enemyPrefab = Resources.Load("Prefab/EnemyPeon", typeof(GameObject)) as GameObject;
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        InvokeRepeating("SpawnEnemy", 3, 3);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
        enemyPrefab.transform.position = transform.position;
    }
}
