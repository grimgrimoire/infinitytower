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
    public ArtilleryInterface shootImpl;
}

public class ArtilleryModelList
{

    public static int TOTAL_ARTILLERY = 4;

    public static ArtilleryModel GetArtilleryAtIndex(int index)
    {
        switch (index)
        {
            case 0:
                return Archer();
            case 1:
                return Longbowmen();
            case 2:
                return Cannon();
            case 3:
                return Mage();
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
        arrow.projectilePrefabName = "prefab/arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
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
        arrow.projectilePrefabName = "prefab/arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
        return arrow;
    }

    static ArtilleryModel Cannon()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Cannon";
        cannon.lockRange = 6f;
        cannon.fireDelay = 5f;
        cannon.lockNumber = 1;
        cannon.damage = 15;
        cannon.ingameModelPrefabName = "Prefab/TowerCannon";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = "prefab/CannonBall";
        cannon.shootImpl = new CannonArtillery(cannon);
        return cannon;
    }

    static ArtilleryModel Mage()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Mage";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }
}
