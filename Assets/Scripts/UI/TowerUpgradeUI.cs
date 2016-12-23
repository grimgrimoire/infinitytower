using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TowerUpgradeUI : MonoBehaviour, IPointerClickHandler, DialogInterface
{

    public RectTransform upgradeList;
    public UpgradeDetailUI upgradeDetailUI;
    public GameObject prefabUI;

    private ArtilleryScript artillery;
    private SupportScript support;
    private bool isArtillery;

    private int upgradeIndex;

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
            upgradeIndex = find.GetSiblingIndex();
            ShowUpgradeDetail();
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
        for (int i = 0; i < SupportModelList.GetTotalSupport(GetSupportUpgradeCode()); i++)
        {
            AddSupportUpgradeToList(SupportModelList.GetSupportAtIndex(i, GetSupportUpgradeCode()));
        }
    }

    private int GetSupportUpgradeCode()
    {
        if (support.model == null)
            return 0;
        else
            return support.model.upgradeCode;
    }

    private void AddArtilleryUpgradeToList(ArtilleryModel model)
    {
        GameObject instance = (GameObject)Instantiate(prefabUI, upgradeList, false);
        instance.name = model.name;
        instance.transform.GetChild(0).GetComponent<Text>().text = model.name;
        instance.transform.GetChild(1).GetComponent<Text>().text = "Price : " + model.price;
        instance.transform.GetChild(2).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("WeaponTower 1")[model.imageUIindex];
    }

    private void AddSupportUpgradeToList(SupportModel model)
    {
        GameObject instance = (GameObject)Instantiate(prefabUI, upgradeList, false);
        instance.name = model.name;
        instance.transform.GetChild(0).GetComponent<Text>().text = model.name;
        instance.transform.GetChild(1).GetComponent<Text>().text = "Price : " + model.price;
        instance.transform.GetChild(2).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Buff")[model.imageUIIndex];
    }

    private void RemoveDialog()
    {
        DialogUI dialog = GameSystem.GetGameSystem().GetControlUI().dialogUI;
        dialog.gameObject.SetActive(true);
        if (isArtillery)
        {
            dialog.SetMessage("Remove artillery?");
        }
        else
        {
            dialog.SetMessage("Remove support?");
        }
        dialog.SetDialogType(true);
        dialog.SetInterface(this);
    }

    public void OnOkButtonClicked()
    {
    }

    public void OnNoButtonClicked()
    {
    }

    public void OnBuyArtillery(ArtilleryModel model)
    {
        if (model.price <= GameSystem.GetGameSystem().GetGold() && model.price != 0)
        {
            GameSystem.GetGameSystem().AddGold(-model.price);
            artillery.SetModel(model);
            LoadAvailableArtilleryUpgrades();
        }
        else
        {
            GameSystem.GetGameSystem().AddGold(Mathf.RoundToInt(artillery.GetModel().price * (0.7f)));
            artillery.SetModel(model);
            LoadAvailableArtilleryUpgrades();
        }
    }

    public void OnBuySupport(SupportModel model)
    {
        if (model.price <= GameSystem.GetGameSystem().GetGold())
        {
            GameSystem.GetGameSystem().AddGold(-model.price);
            support.SetImplements(model);
            LoadAvailableSupportUpgrades();
        }

    }

    public void OnYesButtonClicked()
    {
        if (isArtillery)
        {
            ArtilleryModel model = ArtilleryModelList.GetArtilleryAtIndex(upgradeIndex, GetUpgradeCode());
            GameSystem.GetGameSystem().AddGold(Mathf.RoundToInt(artillery.GetModel().price * (0.7f)));
            artillery.SetModel(model);
            LoadAvailableArtilleryUpgrades();
        }
        else
        {
            SupportModel model = SupportModelList.GetSupportAtIndex(upgradeIndex, GetSupportUpgradeCode());
            GameSystem.GetGameSystem().AddGold(Mathf.RoundToInt(support.model.price * (0.7f)));
            support.SetImplements(model);
            LoadAvailableSupportUpgrades();
        }
    }

    public void ShowUpgradeDetail()
    {
        if (isArtillery)
        {
            if (upgradeIndex == 0 && GetUpgradeCode() != 0)
                RemoveDialog();
            else
            {
                ArtilleryModel model = ArtilleryModelList.GetArtilleryAtIndex(upgradeIndex, GetUpgradeCode());
                upgradeDetailUI.LoadArtilleryInfo(model);
            }
        }
        else
        {
            if (upgradeIndex == 0 && GetSupportUpgradeCode() != 0)
            {
                RemoveDialog();
            }
            else
            {
                SupportModel model = SupportModelList.GetSupportAtIndex(upgradeIndex, GetSupportUpgradeCode());
                upgradeDetailUI.LoadSupportInfo(model);
            }

        }
    }
}
