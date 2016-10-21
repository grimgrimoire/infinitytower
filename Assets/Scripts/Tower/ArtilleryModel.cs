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
    public ArtilleryTargetingInterface targetingImpl;
}

public class ArtilleryModelList
{

    public static int TOTAL_ARTILLERY = 3;

    public static ArtilleryModel GetArtilleryAtIndex(int index)
    {
        switch (index)
        {
            case 0:
                return Archer();
            case 1:
                return Cannon();
            case 2:
                return Mage();
            case 3:
                return Gunner();
            default:
                return Archer();
        }
    }

    //Archer Upgrade
    public static ArtilleryModel GetArtilleryUpgradeArcher(int index)
    {
        switch (index)
        {
            case 0:
                return Hunter();
            default:
                return Archer();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeHighArcher(int index)
    {
        switch (index)
        {
            case 0:
                return Longbowman();
            case 1:
                return Crossbowman();
            default:
                return Archer();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeLongbowman(int index)
    {
        switch (index)
        {
            case 0:
                return HighLongbowman();
            default:
                return Longbowman();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeCrossbowman(int index)
    {
        switch (index)
        {
            case 0:
                return HighCrossbowman();
            case 1:
                return Ranger();
            default:
                return Crossbowman();
        }
    }
    //end archer upgrade

    //Canon upgrade
    public static ArtilleryModel GetArtilleryUpgradeCanon(int index)
    {
        switch (index)
        {
            case 0:
                return Bombardman();
            default:
                return Cannon();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeBombardman(int index)
    {
        switch (index)
        {
            case 0:
                return Guardman();
            case 1:
                return Artilleryman();
            default:
                return Bombardman();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeGuardman(int index)
    {
        switch (index)
        {
            case 0:
                return HighGuardman();
            default:
                return Guardman();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeArtilleryman(int index)
    {
        switch (index)
        {
            case 0:
                return Admiral();
            case 1:
                return Pirate();
            default:
                return Guardman();
        }
    }

    //end canon upgrade

    //Gunner upgrade
    public static ArtilleryModel GetArtilleryUpgradeGunner(int index)
    {
        switch (index)
        {
            case 0:
                return Shooter();
            default:
                return Gunner();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeShooter(int index)
    {
        switch (index)
        {
            case 0:
                return Sniper();
            case 1:
                return Gunslinger();
            default:
                return Shooter();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeSniper(int index)
    {
        switch (index)
        {
            case 0:
                return MasterSniper();
            default:
                return Sniper();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeGunslinger(int index)
    {
        switch (index)
        {
            case 0:
                return Maniac();
            case 1:
                return Rocketer();
            default:
                return Gunslinger();
        }
    }
    //End gunner upgrade

    //Mage upgrade
    public static ArtilleryModel GetArtilleryUpgradeMage(int index)
    {
        switch (index)
        {
            case 0:
                return Sorcerer();
            default:
                return Mage();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeSorcerer(int index)
    {
        switch (index)
        {
            case 0:
                return Wizard();
            case 1:
                return Alchemist();
            case 2:
                return Sage();
            default:
                return Sorcerer();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeWizard(int index)
    {
        switch (index)
        {
            case 0:
                return HighWizard();
            default:
                return Wizard();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeAlchemist(int index)
    {
        switch (index)
        {
            case 0:
                return GrandAlchemist();
            default:
                return Alchemist();
        }
    }

    public static ArtilleryModel GetArtilleryUpgradeSage(int index)
    {
        switch (index)
        {
            case 0:
                return Warlock();
            case 1:
                return Shaman();
            default:
                return Sage();
        }
    }
    //End Mage upgrade

    //archer Model
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

    static ArtilleryModel Hunter()
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

    static ArtilleryModel Longbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Longbowman";
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

    static ArtilleryModel Crossbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Crossbowman";
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

    static ArtilleryModel HighLongbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighLongbowman";
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

    static ArtilleryModel HighCrossbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighLongbowman";
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

    static ArtilleryModel Ranger()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighLongbowman";
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
    //end archer model

    //Canon Model
    static ArtilleryModel Cannon()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Cannoner";
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

    static ArtilleryModel Bombardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Bombardman";
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

    static ArtilleryModel Guardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Guardman";
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

    static ArtilleryModel HighGuardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "HighGuardman";
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

    static ArtilleryModel Artilleryman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Artilleryman";
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

    static ArtilleryModel Admiral()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Admiral";
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

    static ArtilleryModel Pirate()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Pirate";
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
    //end canon model

    //Gunner model
    static ArtilleryModel Gunner()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Gunner";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel Shooter()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Shooter";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel Sniper()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Sniper";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel Gunslinger()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Gunslinger";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel MasterSniper()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "MasterSniper";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel Maniac()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Maniac";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }

    static ArtilleryModel Rocketer()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Rocketer";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 15;
        gunner.ingameModelPrefabName = "Prefab/TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = "prefab/CannonBall";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        return gunner;
    }
    //End Gunner model

    //Mage model
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
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Sorcerer()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Sorcerer";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Wizard()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Wizard";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Alchemist()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Alchemist";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Sage()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Sage";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel HighWizard()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "HighWizard";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel GrandAlchemist()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "GrandAlchemist";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Warlock()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Warlock";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }

    static ArtilleryModel Shaman()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Shaman";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 20;
        mage.ingameModelPrefabName = "Prefab/TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = "prefab/arrow";
        mage.shootImpl = new MageArtillery(mage);
        return mage;
    }
    //End Mage model
}
