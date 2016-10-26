using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TowerUpgradeUI : MonoBehaviour, IPointerClickHandler
{

    public RectTransform upgradeList;

    public GameObject prefabUI;

    private ArtilleryScript artillery;
    private SupportScript support;
    private bool isArtillery;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetArtilleryToUpgrade(ArtilleryScript artillery)
    {
        isArtillery = true;
        this.artillery = artillery;
        LoadAvailableArtilleryUpgrades();
    }

    public void SetSupportToUpgrade(ArtilleryScript support)
    {
        isArtillery = false;
        this.artillery = support;
        this.support = support.GetSupport();
        LoadAvailableSupportUpgrades();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Transform find = upgradeList.FindChild(eventData.pointerEnter.name);
        if (find != null)
        {
            if (isArtillery)
            {
                ArtilleryModel model = ArtilleryModelList.GetArtilleryAtIndex(find.GetSiblingIndex());
                if (model.price < GameSystem.GetGameSystem().GetGold())
                {
                    GameSystem.GetGameSystem().AddGold(-model.price);
                    artillery.SetModel(model);
                }
            }
            else
            {
                SupportModel model = SupportModelList.GetSupportAtIndex(find.GetSiblingIndex());
                if (model.price < GameSystem.GetGameSystem().GetGold())
                {
                    GameSystem.GetGameSystem().AddGold(-model.price);
                    artillery.RemoveSupportedEffect();
                    support.SetImplements(model);
                    artillery.ApplySupportedEffect();
                }
            }
        }
    }

    public void LoadAvailableArtilleryUpgrades()
    {
        ClearList();
        for (int i = 0; i < ArtilleryModelList.TOTAL_ARTILLERY; i++)
        {
            AddArtilleryUpgradeToList(ArtilleryModelList.GetArtilleryAtIndex(i));
        }
    }

    public void ClearList()
    {
        for (int i = upgradeList.childCount - 1; i >= 0; i--)
        {
            Destroy(upgradeList.GetChild(i).gameObject);
        }
    }

    public void LoadAvailableSupportUpgrades()
    {
        ClearList();
        for (int i = 0; i < SupportModelList.TOTAL_SUPPORT; i++)
        {
            AddSupportUpgradeToList(SupportModelList.GetSupportAtIndex(i));
        }
    }

    private void AddArtilleryUpgradeToList(ArtilleryModel model)
    {
        GameObject instance = (GameObject)Instantiate(prefabUI, upgradeList, false);
        instance.name = model.name;
        instance.GetComponentInChildren<Text>().text = model.name + "\n" + "Price : " + model.price;
    }

    private void AddSupportUpgradeToList(SupportModel model)
    {
        GameObject instance = (GameObject)Instantiate(prefabUI, upgradeList, false);
        instance.name = model.name;
        instance.GetComponentInChildren<Text>().text = model.name + "\n" + "Price : " + model.price;
    }
}
