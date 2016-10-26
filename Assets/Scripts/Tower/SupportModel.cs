using UnityEngine;
using System.Collections;

public class SupportModel
{

    public string name;
    public int price;
    public SupportInterface supportImpl;
}

public class SupportModelList
{

    public static int TOTAL_SUPPORT = 2;

    public static SupportModel GetSupportAtIndex(int i)
    {
        switch (i)
        {
            case 0:
                return Empty();
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
}
