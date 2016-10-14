using UnityEngine;
using System.Collections;

public class SupportScript : MonoBehaviour {

    private string supportName;

	// Use this for initialization
	void Start () {
        supportName = "No support installed";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string getName()
    {
        return supportName;
    }
}
