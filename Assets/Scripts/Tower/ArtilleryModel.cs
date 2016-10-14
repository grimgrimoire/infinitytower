public class ArtilleryModel
{
    public string name;
    public float lockRange;
    public float fireDelay;
    public int lockNumber;
    public string ingameModelPrefabName;
    public string projectilePrefabName;
    public int damage;
    public DamageType damageType;
    public int price;
}

public class ArtilleryModelList
{

    public static int TOTAL_ARTILLERY = 2;

    public static ArtilleryModel GetArtilleryAtIndex(int index)
    {
        switch (index)
        {
            case 0:
                return Archer();
            case 1:
                return Longbowmen();
            default:
                return Archer();
        }
    }

    static ArtilleryModel Archer()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Archer";
        arrow.lockRange = 3f;
        arrow.fireDelay = 0.5f;
        arrow.lockNumber = 1;
        arrow.damage = 10;
        arrow.ingameModelPrefabName = "Prefab/TowerArcher";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 10;
        return arrow;
    }

    static ArtilleryModel Longbowmen()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Longbowmen";
        arrow.lockRange = 5f;
        arrow.fireDelay = 1.5f;
        arrow.lockNumber = 1;
        arrow.damage = 15;
        arrow.ingameModelPrefabName = "Prefab/TowerArcher";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        return arrow;
    }
}
