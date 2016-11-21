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

    public void SetSupportToUpgrade(SupportScript support)
    {
        isArtillery = false;
        this.support = support;
        LoadAvailableSupportUpgrades();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Transform find = upgradeList.FindChild(eventData.pointerEnter.name);
        if (find != null)
        {
            if (isArtillery)
            {
                ArtilleryModel model = ArtilleryModelList.GetArtilleryAtIndex(find.GetSiblingIndex(), GetUpgradeCode());
                if (model.price < GameSystem.GetGameSystem().GetGold())
                {
                    GameSystem.GetGameSystem().AddGold(-model.price);
                    artillery.SetModel(model);
                    LoadAvailableArtilleryUpgrades();
                }
            }
            else
            {
                SupportModel model = SupportModelList.GetSupportAtIndex(find.GetSiblingIndex());
                if (model.price < GameSystem.GetGameSystem().GetGold())
                {
                    GameSystem.GetGameSystem().AddGold(-model.price);
                    support.SetImplements(model);
                }
            }
        }
    }

    public void LoadAvailableArtilleryUpgrades()
    {
        ClearList();
        for (int i = 0; i < GetUpgradeBranches(); i++)
        {
            AddArtilleryUpgradeToList(ArtilleryModelList.GetArtilleryAtIndex(i, GetUpgradeCode()));
        }
    }

    private int GetUpgradeCode()
    {
        if (artillery.GetModel() == null)
            return 0;
        else
            return artillery.GetModel().upgradeCode;
    }

    private int GetUpgradeBranches()
    {
        if (artillery.GetModel() == null)
            return ArtilleryModelList.TOTAL_ARTILLERY;
        else
            return artillery.GetModel().upgradeBranch;
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
