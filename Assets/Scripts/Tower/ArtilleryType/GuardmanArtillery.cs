using UnityEngine;
using System.Collections;
using System;

public class GuardmanArtillery : MonoBehaviour, ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        throw new NotImplementedException();
    }
}
