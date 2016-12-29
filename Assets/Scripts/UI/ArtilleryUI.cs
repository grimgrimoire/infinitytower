using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArtilleryUI : MonoBehaviour
{

    public Text moduleName;
    public Image image;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetModel(ArtilleryModel model)
    {
        if (model != null)
        {
            moduleName.text = model.name;
            if (model.price != 0)
            {
                image.sprite = Resources.LoadAll<Sprite>("WeaponTower 1")[model.imageUIindex];
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
        //GetComponent<Image>().color = new Color(0.141f, 0.105f, 0.054f);
    }

    public void SetUnselected()
    {
        //GetComponent<Image>().color = new Color(0.176f, 0.133f, 0.070f);
    }
}
