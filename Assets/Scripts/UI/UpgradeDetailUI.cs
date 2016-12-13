using UnityEngine;
using UnityEngine.UI;

public class UpgradeDetailUI : MonoBehaviour {

    public TowerUpgradeUI towerUpgrade;

    public Text upgradeName;
    public Image image;
    public Text damage;
    public Text range;
    public Text fireRate;
    public Text description;
    public Text price;

    Canvas canvas;

    bool isArtillery;
    ArtilleryModel selected;
    SupportModel selectedSupport;

    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void LoadArtilleryInfo(ArtilleryModel model)
    {
        selected = model;
        isArtillery = true;
        canvas.enabled = true;
        upgradeName.text = model.name;
        price.text = model.price + " Gold";
        damage.text = model.damage + "";
        range.text = model.lockRange + " M";
        fireRate.text = System.Math.Round(1f / model.fireDelay, 2) + " / S";
        description.text = model.description;
        image.sprite = Resources.LoadAll<Sprite>("WeaponTower 1")[model.imageUIindex];
    }

    public void LoadSupportInfo(SupportModel model)
    {
        selectedSupport = model;
        isArtillery = false;
    }

    public void BuyButtonClick()
    {
        canvas.enabled = false;
        if(isArtillery)
            towerUpgrade.OnBuyArtillery(selected);
        else
            towerUpgrade.OnBuySupport(selectedSupport);
    }

    public void CancelButtonClick()
    {
        canvas.enabled = false;
    }
}
