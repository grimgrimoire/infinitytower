using UnityEngine;
using System.Collections;

public class SupportModel
{
    public string name;
    public int price;
    public SupportInterface supportImpl;
    public string supportModelPrefabName;
    public int imageIndex = 0;
}

public class SupportModelList
{

    const string RESOURCE = "Prefab/BuffUnit/";

    public static int TOTAL_SUPPORT = 3;

    public static SupportModel GetSupportAtIndex(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
            case 1:
                return SlowDebuffSupport();
            case 2:
                return DamageBuff();
            default:
                return SlowDebuffSupport();
        }
    }

    public static SupportModel Empty()
    {
        SupportModel model = new SupportModel();
        model.name = "Remove";
        model.price = 0;
        return model;
    }

    public static SupportModel SlowDebuffSupport()
    {
        SupportModel model = new SupportModel();
        model.name = "Slow debuff";
        model.price = 15;
        model.supportImpl = new SlowDebuffSupport();
        return model;
    }

    public static SupportModel DamageBuff()
    {
        SupportModel model = new SupportModel();
        model.name = "Damage buff";
        model.price = 15;
        model.supportImpl = new DamageBuffSupport();
        model.supportModelPrefabName = RESOURCE + "FireBuff";
        return model;
    }
}
