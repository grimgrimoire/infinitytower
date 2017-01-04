using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SupportUI : MonoBehaviour {

    public Text moduleName;
    public Image image;

    private Image uiImage;
    // Use this for initialization
    void Start () {
        uiImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetName(SupportModel model)
    {
        if(model != null)
        {
            moduleName.text = model.name;
            if (model.price != 0)
            {
                image.sprite = Resources.LoadAll<Sprite>("Buff")[model.imageUIIndex];
                image.color = Color.white;
            }
            else
            {
                image.sprite = null;
                image.color = Color.black;
            }
        }
        else
        {
            moduleName.text = "Empty";
            image.sprite = null;
            image.color = Color.black;
        }
    }

    public void SetSelected()
    {
        uiImage.sprite = Resources.LoadAll<Sprite>("UIOutline")[1];
    }

    public void SetUnselected()
    {
        uiImage.sprite = Resources.LoadAll<Sprite>("UI")[9];
    }
}
