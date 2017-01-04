using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArtilleryUI : MonoBehaviour
{

    public Text moduleName;
    public Image moduleImage;

    private Image uiImage;

    // Use this for initialization
    void Start()
    {
        uiImage = GetComponent<Image>();
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
                moduleImage.sprite = Resources.LoadAll<Sprite>("WeaponTower 1")[model.imageUIindex];
                moduleImage.color = Color.white;
            }
            else
            {
                moduleImage.sprite = null;
                moduleImage.color = Color.black;
            }
        }
        else
        {
            moduleName.text = "Empty";
            moduleImage.sprite = null;
            moduleImage.color = Color.black;
        }
    }

    public void SetSelected()
    {
        uiImage.sprite = Resources.LoadAll<Sprite>("UIOutline")[0];
    }

    public void SetUnselected()
    {
        uiImage.sprite = Resources.LoadAll<Sprite>("UI")[5];
    }
}
