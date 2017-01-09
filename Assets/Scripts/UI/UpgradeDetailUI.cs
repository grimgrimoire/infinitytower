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
    public Text damageType;

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
        switch (model.damageType)
        {
            case DamageType.Piercing:
                damageType.text = "Piercing";
                break;
            case DamageType.Explosive:
                damageType.text = "Explosive";
                break;
            case DamageType.Impact:
                damageType.text = "Impact";
                break;
            case DamageType.Magic:
                damageType.text = "Magic";
                break;
            default:
                damageType.text = "";
                break;
        }
    }

    public void LoadSupportInfo(SupportModel model)
    {
        selectedSupport = model;
        isArtillery = false;
        canvas.enabled = true;
        upgradeName.text = model.name;
        price.text = model.price + " Gold";
        description.text = model.description;
        damage.text = model.bonusDamage;
        range.text = model.bonusRange;
        fireRate.text = model.bonusSpeed;
        damageType.text = "";
        image.sprite = Resources.LoadAll<Sprite>("Buff")[model.imageUIIndex];
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
