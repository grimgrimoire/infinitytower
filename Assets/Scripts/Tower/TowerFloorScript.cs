using UnityEngine;
using System.Collections;

public class TowerFloorScript : MonoBehaviour
{

    ArtilleryScript leftArtillery;
    ArtilleryScript rightArtillery;
    SupportScript supportScript;

    int towerHealth = 20;

    // Use this for initialization
    void Start()
    {
        leftArtillery = transform.GetChild(0).GetComponent<ArtilleryScript>();
        rightArtillery = transform.GetChild(1).GetComponent<ArtilleryScript>();
        supportScript = GetComponent<SupportScript>();
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

    public SupportScript GetSupport()
    {
        return supportScript;
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
