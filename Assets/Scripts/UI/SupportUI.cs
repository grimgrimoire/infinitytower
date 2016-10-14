using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SupportUI : MonoBehaviour {

    public Text moduleName;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetName(string name)
    {
        moduleName.text = name;
    }

    public void SetSelected()
    {
        GetComponent<Image>().color = new Color(0.141f, 0.105f, 0.054f);
    }

    public void SetUnselected()
    {
        GetComponent<Image>().color = new Color(0.176f, 0.133f, 0.070f);
    }
}
