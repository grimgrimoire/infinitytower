using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TowerScript : MonoBehaviour {

    public GameObject towerBodyPrefab;
    public GameObject towerAddButton;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddFloor()
    {
        GameObject newFloor = (GameObject)Instantiate(towerBodyPrefab, transform);
        newFloor.transform.position = new Vector2(0, 0.8f * (transform.childCount - 2));
        towerAddButton.transform.position = new Vector2(0, 0.8f * (transform.childCount - 1));
    }

}
