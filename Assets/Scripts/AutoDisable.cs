using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour {

    public float delay;
    public bool disableAtStart = true;

    void OnEnable()
    {
        StartCoroutine(InactiveSelf());
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator InactiveSelf()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
