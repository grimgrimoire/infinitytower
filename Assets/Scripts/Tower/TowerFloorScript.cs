using UnityEngine;
using System.Collections;

public class TowerFloorScript : MonoBehaviour
{

    ArtilleryScript leftArtillery;
    ArtilleryScript rightArtillery;
    SupportScript supportScript;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        leftArtillery = transform.GetChild(0).GetComponent<ArtilleryScript>();
        rightArtillery = transform.GetChild(1).GetComponent<ArtilleryScript>();
        supportScript = GetComponent<SupportScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void RemoveAllArtillery()
    {
        leftArtillery.RemoveArtillery();
        rightArtillery.RemoveArtillery();
        supportScript.RemoveSupport();
    }

    public void ClearSelection()
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("Tower 1");
        spriteRenderer.sortingOrder = -1;
    }

    public void LoadTowerFloorToUI()
    {
        ControlUI.GetUI().GetTowerInternalUI().LoadTowerFloor(leftArtillery, rightArtillery);
        ControlUI.GetUI().GetTowerInternalUI().SetTowerFloorScript(this);
        GameSystem.GetGameSystem().towerScript.ClearTowerSelection();
        spriteRenderer.sprite = Resources.Load<Sprite>("OutlineTower");
        spriteRenderer.sortingOrder = 0;
    }

}
