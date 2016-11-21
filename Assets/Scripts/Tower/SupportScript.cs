using UnityEngine;
using System.Collections;

public class SupportScript : MonoBehaviour
{

    private string supportName;
    private SupportInterface implements;
    public ArtilleryScript left;
    public ArtilleryScript right;

    // Use this for initialization
    void Start()
    {
        supportName = "No support installed";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetImplements(SupportModel model)
    {
        if (transform.GetChild(4).childCount > 0)
        {
            Destroy(transform.GetChild(4).GetChild(0).gameObject);
        }
        left.RemoveSupportedEffect();
        right.RemoveSupportedEffect();
        supportName = model.name;
        implements = model.supportImpl;
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
        left.ApplySupportedEffect();
        right.ApplySupportedEffect();
        if (model.supportModelPrefabName != null)
        {
            GameObject graphics = (GameObject)Instantiate(Resources.Load(model.supportModelPrefabName, typeof(GameObject)) as GameObject, transform.GetChild(4).transform);
            graphics.transform.localPosition = Vector3.zero;
        }
    }

    public string getName()
    {
        return supportName;
    }

    public SupportInterface GetImplements()
    {
        return implements;
    }
}
