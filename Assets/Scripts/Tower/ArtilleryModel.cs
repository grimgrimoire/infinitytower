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
    public int upgradeCode = 0;
    public int upgradeBranch;
    public int poolSize = 5;
}

public class ArtilleryModelList
{
    const int UPGRADE_ZERO = 0;
    const int UPGRADE_ARCHER = 1;
    const int UPGRADE_ARCHER_HUNTER = 2;
    const int UPGRADE_LONGBOWMAN = 3;
    const int UPGRADE_CROSSBOWMAN = 4;
    const int UPGRADE_CANNON = 5;
    const int UPGRADE_BOMBARD = 6;
    const int UPGRADE_GUARDMAN = 7;
    const int UPGRADE_ARTILLERYMAN = 8;
    const int UPGRADE_GUNNER = 9;
    const int UPGRADE_SHOOTER = 10;
    const int UPGRADE_SNIPER = 11;
    const int UPGRADE_GUNSLINGER = 12;
    const int UPGRADE_MAGE = 13;
    const int UPGRADE_SORCERER = 14;
    const int UPGRADE_WIZARD = 15;
    const int UPGRADE_ALCHEMIST = 16;
    const int UPGRADE_SAGE = 17;
    const int UPGRADE_NONE = 18;

    const string PATH_ARCHER = "Prefab/TowerUnit/Archer/";
    const string PATH_CANNON = "Prefab/TowerUnit/Cannon/";
    const string PATH_GUNNER = "Prefab/TowerUnit/Gunner/";
    const string PATH_MAGE = "Prefab/TowerUnit/Mage/";

    const string PATH_PROJECTILE = "Prefab/Projectile/";

    public const int TOTAL_ARTILLERY = 4;

    public static ArtilleryModel GetArtilleryAtIndex(int index, int upgradeTree)
    {
        switch (upgradeTree)
        {
            case UPGRADE_ZERO:
                return GetArtilleryAtIndex(index);
            case UPGRADE_ARCHER:
                return GetArtilleryUpgradeArcher(index);
            case UPGRADE_ARCHER_HUNTER:
                return GetArtilleryUpgradeHighArcher(index);
            case UPGRADE_LONGBOWMAN:
                return GetArtilleryUpgradeLongbowman(index);
            case UPGRADE_CROSSBOWMAN:
                return GetArtilleryUpgradeCrossbowman(index);
            case UPGRADE_CANNON:
                return GetArtilleryUpgradeCanon(index);
            case UPGRADE_BOMBARD:
                return GetArtilleryUpgradeBombardman(index);
            case UPGRADE_ARTILLERYMAN:
                return GetArtilleryUpgradeArtilleryman(index);
            case UPGRADE_GUARDMAN:
                return GetArtilleryUpgradeGuardman(index);
            case UPGRADE_GUNNER:
                return GetArtilleryUpgradeGunner(index);
            case UPGRADE_SHOOTER:
                return GetArtilleryUpgradeShooter(index);
            case UPGRADE_SNIPER:
                return GetArtilleryUpgradeSniper(index);
            case UPGRADE_GUNSLINGER:
                return GetArtilleryUpgradeGunslinger(index);
            case UPGRADE_MAGE:
                return GetArtilleryUpgradeMage(index);
            case UPGRADE_SORCERER:
                return GetArtilleryUpgradeSorcerer(index);
            case UPGRADE_WIZARD:
                return GetArtilleryUpgradeWizard(index);
            case UPGRADE_ALCHEMIST:
                return GetArtilleryUpgradeAlchemist(index);
            case UPGRADE_SAGE:
                return GetArtilleryUpgradeSage(index);
            default:
                return Remove();
        }
    }

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

    public static ArtilleryModel Remove()
    {
        ArtilleryModel remove = new ArtilleryModel();
        remove.name = "No weapon installed";
        remove.price = 0;
        remove.upgradeCode = UPGRADE_ZERO;
        remove.upgradeBranch = TOTAL_ARTILLERY;
        return remove;
    }

    //Archer Upgrade
    public static ArtilleryModel GetArtilleryUpgradeArcher(int index)
    {
        switch (index)
        {
            case 0:
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Longbowman();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return HighCrossbowman();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Guardman();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Admiral();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Sniper();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Maniac();
            case 2:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Wizard();
            case 2:
                return Alchemist();
            case 3:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
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
                return Remove();
            case 1:
                return Warlock();
            case 2:
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
        arrow.lockRange = 6f;
        arrow.fireDelay = 1.5f;
        arrow.lockNumber = 1;
        arrow.damage = 40;
        arrow.ingameModelPrefabName = PATH_ARCHER + "TowerArcher";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 10;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
        arrow.upgradeCode = UPGRADE_ARCHER;
        arrow.upgradeBranch = 2;
        return arrow;
    }

    static ArtilleryModel Hunter()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Hunter";
        arrow.lockRange = 6f;
        arrow.fireDelay = 1f;
        arrow.lockNumber = 1;
        arrow.damage = 10;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Hunter";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 10;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
        arrow.upgradeCode = UPGRADE_ARCHER_HUNTER;
        arrow.upgradeBranch = 3;
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
        arrow.ingameModelPrefabName = PATH_ARCHER + "Longbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
        arrow.upgradeCode = UPGRADE_LONGBOWMAN;
        arrow.upgradeBranch = 2;
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
        arrow.ingameModelPrefabName = PATH_ARCHER + "Crossbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new FollowedArrow(arrow, 2);
        arrow.upgradeCode = UPGRADE_CROSSBOWMAN;
        arrow.upgradeBranch = 3;
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
        arrow.ingameModelPrefabName = PATH_ARCHER + "HighLongbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow);
        arrow.upgradeCode = UPGRADE_NONE;
        arrow.upgradeBranch = 1;
        return arrow;
    }

    static ArtilleryModel HighCrossbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighCrossbowman";
        arrow.lockRange = 5f;
        arrow.fireDelay = 1.5f;
        arrow.lockNumber = 1;
        arrow.damage = 15;
        arrow.ingameModelPrefabName = PATH_ARCHER + "HighCrossbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new MultiProjectile(arrow, 6);
        arrow.upgradeCode = UPGRADE_NONE;
        arrow.upgradeBranch = 1;
        return arrow;
    }

    static ArtilleryModel Ranger()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Ranger";
        arrow.lockRange = 5f;
        arrow.fireDelay = 1.5f;
        arrow.lockNumber = 1;
        arrow.damage = 15;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Ranger";
        arrow.damageType = DamageType.Piercing;
        arrow.price = 15;
        arrow.poolSize = 10;
        arrow.projectilePrefabName = PATH_PROJECTILE + "RangerArrow";
        arrow.shootImpl = new RangerArtillery(arrow);
        return arrow;
    }
    //end archer model

    //Canon Model
    static ArtilleryModel Cannon()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Cannoner";
        cannon.lockRange = 6f;
        cannon.fireDelay = 3f;
        cannon.lockNumber = 1;
        cannon.damage = 30;
        cannon.ingameModelPrefabName = PATH_CANNON + "TowerCannon";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.upgradeCode = UPGRADE_CANNON;
        cannon.upgradeBranch = 2;
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
        cannon.ingameModelPrefabName = PATH_CANNON + "Bombardman";
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.upgradeCode = UPGRADE_BOMBARD;
        cannon.upgradeBranch = 3;
        return cannon;
    }

    static ArtilleryModel Guardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Guardman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 1.5f;
        cannon.poolSize = 50;
        cannon.lockNumber = 1;
        cannon.damage = 15;
        cannon.ingameModelPrefabName = PATH_CANNON + "Guardman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "GuardmanCannon";
        cannon.shootImpl = new MultiProjectileGuardman(cannon, 3);
        cannon.targetingImpl = new AirTargetOnly();
        cannon.upgradeCode = UPGRADE_GUARDMAN;
        cannon.upgradeBranch = 2;
        return cannon;
    }

    static ArtilleryModel HighGuardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "HighGuardman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 1.5f;
        cannon.lockNumber = 1;
        cannon.damage = 15;
        cannon.ingameModelPrefabName = PATH_CANNON + "HighGuardman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "GuardmanCannon";
        cannon.shootImpl = new MultiProjectileGuardman(cannon, 9);
        cannon.targetingImpl = new AirTargetOnly();
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
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
        cannon.ingameModelPrefabName = PATH_CANNON + "Artilleryman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.upgradeCode = UPGRADE_ARTILLERYMAN;
        cannon.upgradeBranch = 3;
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
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
        return cannon;
    }

    static ArtilleryModel Pirate()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Pirate";
        cannon.lockRange = 6f;
        cannon.fireDelay = 5f;
        cannon.lockNumber = 1;
        cannon.damage = 60;
        cannon.ingameModelPrefabName = PATH_CANNON + "Pirate";
        cannon.damageType = DamageType.Explosive;
        cannon.price = 20;
        cannon.projectilePrefabName = PATH_PROJECTILE + "PirateBall";
        cannon.shootImpl = new PirateArtillery(cannon);
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
        return cannon;
    }
    //end canon model

    //Gunner model
    static ArtilleryModel Gunner()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Gunner";
        gunner.lockRange = 7f;
        gunner.fireDelay = 3f;
        gunner.lockNumber = 1;
        gunner.damage = 50;
        gunner.ingameModelPrefabName = PATH_GUNNER + "TowerGunner";
        gunner.damageType = DamageType.Piercing;
        gunner.price = 20;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Bullet1";
        gunner.shootImpl = new GunnerArtillery(gunner);
        gunner.upgradeCode = UPGRADE_GUNNER;
        gunner.upgradeBranch = 2;
        return gunner;
    }

    static ArtilleryModel Shooter()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Shooter";
        gunner.lockRange = 6f;
        gunner.fireDelay = 0.016f;
        gunner.lockNumber = 1;
        gunner.damage = 5;
        gunner.ingameModelPrefabName = PATH_GUNNER + "TowerGunner";
        gunner.damageType = DamageType.Piercing;
        gunner.price = 20;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Bullet1";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_SHOOTER;
        gunner.upgradeBranch = 3;
        gunner.poolSize = 50;
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
        gunner.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_SNIPER;
        gunner.upgradeBranch = 2;
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
        gunner.ingameModelPrefabName = PATH_GUNNER + "TowerGunner";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Bullet1";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_GUNSLINGER;
        gunner.upgradeBranch = 3;
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
        gunner.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
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
        gunner.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
        return gunner;
    }

    static ArtilleryModel Rocketer()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Rocketer";
        gunner.lockRange = 6f;
        gunner.fireDelay = 5f;
        gunner.lockNumber = 1;
        gunner.damage = 30;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Rocketeer";
        gunner.damageType = DamageType.Explosive;
        gunner.price = 20;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Rocket";
        gunner.shootImpl = new RocketArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
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
        mage.ingameModelPrefabName = PATH_MAGE + "TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = PATH_PROJECTILE + "ArcaneBall";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_MAGE;
        mage.upgradeBranch = 2;
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
        mage.ingameModelPrefabName = PATH_MAGE + "Sorcerer";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = PATH_PROJECTILE + "ArcaneBall";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_SORCERER;
        mage.upgradeBranch = 3;
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
        mage.ingameModelPrefabName = PATH_MAGE + "Wizard";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_WIZARD;
        mage.upgradeBranch = 2;
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
        mage.ingameModelPrefabName = PATH_MAGE + "Alchemist";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_ALCHEMIST;
        mage.upgradeBranch = 2;
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
        mage.ingameModelPrefabName = PATH_MAGE + "Sage";
        mage.damageType = DamageType.Magic;
        mage.price = 15;
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_SAGE;
        mage.upgradeBranch = 3;
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
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
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
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
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
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
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
        mage.projectilePrefabName = PATH_PROJECTILE + "arrow";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
        return mage;
    }
    //End Mage model
}
