using UnityEngine;
using System.Collections;

public class TowerFloorScript : MonoBehaviour
{

    ArtilleryScript leftArtillery;
    ArtilleryScript rightArtillery;

    int towerHealth = 20;

    // Use this for initialization
    void Start()
    {
        leftArtillery = transform.GetChild(0).GetComponent<ArtilleryScript>();
        rightArtillery = transform.GetChild(1).GetComponent<ArtilleryScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public ArtilleryScript GetLeftArtillery()
    {
        return leftArtillery;
    }

    public ArtilleryScript GetRightArtillery()
    {
        return rightArtillery;
    }

    public SupportScript GetLeftSupport()
    {
        return leftArtillery.GetSupport();
    }

    public SupportScript GetRightSupport()
    {
        return rightArtillery.GetSupport();
    }

    public void LoadTowerFloorToUI()
    {
        ControlUI.GetUI().GetTowerInternalUI().LoadTowerFloor(leftArtillery, rightArtillery);
        ControlUI.GetUI().GetTowerInternalUI().SetTowerFloorScript(this);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == TagsAndLayers.TAG_HOSTILE)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        towerHealth -= 1;
        Debug.Log("Health remaining : " + towerHealth);
        if (towerHealth <= 0)
            TowerDestroyed();
    }

    private void TowerDestroyed()
    {

    }
}
