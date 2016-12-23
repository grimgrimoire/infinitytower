using UnityEngine;
using System.Collections;

public class SupportModel
{
    public string name;
    public int price;
    public SupportInterface supportImpl;
    public string supportModelPrefabName;
    public int imageIndex = 0;
    public int upgradeCode;
    public int imageUIIndex;
}

public class SupportModelList
{

    const string RESOURCE = "Prefab/BuffUnit/";
    const int PRICE_TIER_1 = 1000;
    const int PRICE_TIER_2 = 1500;
    const int PRICE_TIER_3 = 2000;

    public static int TOTAL_SUPPORT = 4;

    public static int GetTotalSupport(int code)
    {
        if (code == 0)
            return TOTAL_SUPPORT;
        else if (code < 9)
            return 2;
        else
            return 1;
    }

    public static SupportModel GetSupportAtIndex(int i, int code)
    {
        switch (code)
        {
            case 0:
                return GetSupportZero(i);
            case 1:
                return GetSupportFire1(i);
            case 2:
                return GetSupportFire2(i);
            case 3:
                return GetSupportIce1(i);
            case 4:
                return GetSupportIce2(i);
            case 5:
                return GetSupportThunder1(i);
            case 6:
                return GetSupportThunder2(i);
            case 7:
                return GetSupportEarth1(i);
            case 8:
                return GetSupportEarth2(i);
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportZero(int i)
    {
        switch (i)
        {
            case 0:
                return FireSupport();
            case 1:
                return IceSupport();
            case 2:
                return ThunderSupport();
            case 3:
                return EarthSupport();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportFire1(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Fire2Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportFire2(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Fire3Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportIce1(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Ice2Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportIce2(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Ice3Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportThunder1(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Thunder2Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportThunder2(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Thunder3Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportEarth1(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Earth2Support();
            default:
                return Empty();
        }
    }

    private static SupportModel GetSupportEarth2(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return Earth3Support();
            default:
                return Empty();
        }
    }

    public static SupportModel Empty()
    {
        SupportModel model = new SupportModel();
        model.name = "Remove";
        model.price = 0;
        model.upgradeCode = 0;
        return model;
    }

    public static SupportModel FireSupport()
    {
        SupportModel model = new SupportModel();
        model.name = "Fire support";
        model.price = PRICE_TIER_1;
        model.supportImpl = new FireSupport(1);
        model.upgradeCode = 1;
        model.supportModelPrefabName = RESOURCE + "FireBuff";
        model.imageUIIndex = 4;
        return model;
    }

    public static SupportModel IceSupport()
    {
        SupportModel model = new SupportModel();
        model.name = "Ice support";
        model.price = PRICE_TIER_1;
        model.supportImpl = new IceSupport(1);
        model.upgradeCode = 3;
        model.imageUIIndex = 7;
        model.supportModelPrefabName = RESOURCE + "IceBuff";
        return model;
    }

    public static SupportModel ThunderSupport()
    {
        SupportModel model = new SupportModel();
        model.name = "Thunder support";
        model.price = PRICE_TIER_1;
        model.supportImpl = new ThunderSupport(1);
        model.supportModelPrefabName = RESOURCE + "ElectricityBuff";
        model.upgradeCode = 5;
        model.imageUIIndex = 10;
        return model;
    }

    public static SupportModel EarthSupport()
    {
        SupportModel model = new SupportModel();
        model.name = "Earth support";
        model.price = PRICE_TIER_1;
        model.supportImpl = new EarthSupport(1);
        model.supportModelPrefabName = RESOURCE + "EarthBuff";
        model.upgradeCode = 7;
        model.imageUIIndex = 13;
        return model;
    }

    public static SupportModel Fire2Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Fire support";
        model.price = PRICE_TIER_2;
        model.supportImpl = new FireSupport(2);
        model.supportModelPrefabName = RESOURCE + "FireBuff2";
        model.upgradeCode = 2;
        model.imageUIIndex = 5;
        return model;
    }

    public static SupportModel Ice2Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Ice support";
        model.price = PRICE_TIER_2;
        model.supportImpl = new IceSupport(2);
        model.upgradeCode = 4;
        model.imageUIIndex = 8;
        model.supportModelPrefabName = RESOURCE + "IceBuff2";
        return model;
    }

    public static SupportModel Thunder2Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Thunder support";
        model.price = PRICE_TIER_2;
        model.supportImpl = new ThunderSupport(2);
        model.upgradeCode = 6;
        model.imageUIIndex = 11;
        model.supportModelPrefabName = RESOURCE + "ElectricityBuff2";
        return model;
    }

    public static SupportModel Earth2Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Earth support";
        model.price = PRICE_TIER_2;
        model.supportImpl = new EarthSupport(2);
        model.upgradeCode = 8;
        model.imageUIIndex = 14;
        model.supportModelPrefabName = RESOURCE + "EarthBuff2";
        return model;
    }

    public static SupportModel Fire3Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Fire support";
        model.price = PRICE_TIER_3;
        model.supportImpl = new FireSupport(3);
        model.supportModelPrefabName = RESOURCE + "FireBuff3";
        model.upgradeCode = 9;
        model.imageUIIndex = 6;
        return model;
    }

    public static SupportModel Ice3Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Ice support";
        model.price = PRICE_TIER_3;
        model.supportImpl = new IceSupport(3);
        model.supportModelPrefabName = RESOURCE + "IceBuff3";
        model.upgradeCode = 9;
        model.imageUIIndex = 9;
        return model;
    }

    public static SupportModel Thunder3Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Thunder support";
        model.price = PRICE_TIER_3;
        model.supportImpl = new ThunderSupport(3);
        model.supportModelPrefabName = RESOURCE + "ElectricityBuff3";
        model.upgradeCode = 9;
        model.imageUIIndex = 12;
        return model;
    }

    public static SupportModel Earth3Support()
    {
        SupportModel model = new SupportModel();
        model.name = "Earth support";
        model.price = PRICE_TIER_3;
        model.supportImpl = new EarthSupport(3);
        model.supportModelPrefabName = RESOURCE + "EarthBuff3";
        model.upgradeCode = 9;
        model.imageUIIndex = 15;
        return model;
    }

    //public static SupportModel SlowDebuffSupport()
    //{
    //    SupportModel model = new SupportModel();
    //    model.name = "Slow debuff";
    //    model.price = 15;
    //    model.supportImpl = new SlowDebuffSupport();
    //    return model;
    //}

    //public static SupportModel DamageBuff()
    //{
    //    SupportModel model = new SupportModel();
    //    model.name = "Damage buff";
    //    model.price = 15;
    //    model.supportImpl = new DamageBuffSupport();
    //    model.supportModelPrefabName = RESOURCE + "FireBuff";
    //    return model;
    //}
}
