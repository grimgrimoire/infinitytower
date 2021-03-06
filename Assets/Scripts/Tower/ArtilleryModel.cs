﻿public class ArtilleryModel
{
    public string name;
    public float lockRange;
    public float fireDelay;
    public float originalFireDelay;
    public int lockNumber;
    public string ingameModelPrefabName;
    public string projectilePrefabName;
    public int damage;
    public int originalDamage;
    public DamageType damageType;
    public DamageType originalType;
    public int price;
    public ArtilleryInterface shootImpl;
    public ArtilleryTargetingInterface targetingImpl;
    public int upgradeCode = 0;
    public int upgradeBranch;
    public int poolSize = 5;
    public int imageUIindex = 3;
    public string description = "";

    public void Initialize()
    {
        originalDamage = damage;
        originalFireDelay = fireDelay;
        originalType = damageType;
    }

    public void Reset()
    {
        damage = originalDamage;
        fireDelay = originalFireDelay;
        damageType = originalType;
    }
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
    public const int UPGRADE_MAGE = 13;
    const int UPGRADE_SORCERER = 14;
    const int UPGRADE_WIZARD = 15;
    const int UPGRADE_ALCHEMIST = 16;
    const int UPGRADE_SAGE = 17;
    public const int UPGRADE_NONE = 18;

    const string PATH_ARCHER = "Prefab/TowerUnit/Archer/";
    const string PATH_CANNON = "Prefab/TowerUnit/Cannon/";
    const string PATH_GUNNER = "Prefab/TowerUnit/Gunner/";
    const string PATH_MAGE = "Prefab/TowerUnit/Mage/";

    const int UPGRADE_1_PRICE = 50;
    const int UPGRADE_2_PRICE = 600;
    const int UPGRADE_3_PRICE = 1000;
    const int UPGRADE_4_PRICE = 1500;

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
        remove.name = "Empty";
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
        arrow.price = UPGRADE_1_PRICE;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow, 8);
        arrow.upgradeCode = UPGRADE_ARCHER;
        arrow.upgradeBranch = 2;
        arrow.imageUIindex = 3;
        arrow.description = "Shoot Arrow to Enemy.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel Hunter()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Hunter";
        arrow.lockRange = 6f;
        arrow.fireDelay = 1.5f;
        arrow.lockNumber = 1;
        arrow.damage = 120;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Hunter";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_2_PRICE;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow, 8);
        arrow.upgradeCode = UPGRADE_ARCHER_HUNTER;
        arrow.upgradeBranch = 3;
        arrow.imageUIindex = 3;
        arrow.description = "Shoot Arrow to Enemy.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel Longbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Longbowman";
        arrow.lockRange = 9f;
        arrow.fireDelay = 2f;
        arrow.lockNumber = 1;
        arrow.damage = 500;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Longbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_3_PRICE;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow, 8);
        arrow.upgradeCode = UPGRADE_LONGBOWMAN;
        arrow.upgradeBranch = 2;
        arrow.imageUIindex = 13;
        arrow.description = "Shoot arrow with very high damage.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel Crossbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Crossbowman";
        arrow.lockRange = 5f;
        arrow.fireDelay = 2f;
        arrow.lockNumber = 1;
        arrow.damage = 50;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Crossbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_3_PRICE;
        arrow.poolSize = 20;
        arrow.projectilePrefabName = PATH_PROJECTILE + "ImpreciseArrow";
        arrow.shootImpl = new MultiProjectile(arrow, 10);
        arrow.upgradeCode = UPGRADE_CROSSBOWMAN;
        arrow.upgradeBranch = 3;
        arrow.imageUIindex = 7;
        arrow.description = "Scatter 10 arrow to enemy.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel HighLongbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighLongbowman";
        arrow.lockRange = 9f;
        arrow.fireDelay = 1.8f;
        arrow.lockNumber = 1;
        arrow.damage = 1000;
        arrow.ingameModelPrefabName = PATH_ARCHER + "HighLongbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_4_PRICE;
        arrow.projectilePrefabName = PATH_PROJECTILE + "arrow";
        arrow.shootImpl = new LinearProjectileArtillery(arrow, 8);
        arrow.upgradeCode = UPGRADE_NONE;
        arrow.upgradeBranch = 1;
        arrow.imageUIindex = 13;
        arrow.description = "Shoot arrow with very high damage.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel HighCrossbowman()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "HighCrossbowman";
        arrow.lockRange = 5f;
        arrow.fireDelay = 2f;
        arrow.lockNumber = 1;
        arrow.damage = 60;
        arrow.ingameModelPrefabName = PATH_ARCHER + "HighCrossbowman";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_4_PRICE;
        arrow.projectilePrefabName = PATH_PROJECTILE + "ImpreciseArrow";
        arrow.shootImpl = new MultiProjectile(arrow, 20);
        arrow.upgradeCode = UPGRADE_NONE;
        arrow.poolSize = 20;
        arrow.upgradeBranch = 1;
        arrow.imageUIindex = 7;
        arrow.description = "Scatter 10 arrow to enemy.";
        arrow.Initialize();
        return arrow;
    }

    static ArtilleryModel Ranger()
    {
        ArtilleryModel arrow = new ArtilleryModel();
        arrow.name = "Ranger";
        arrow.lockRange = 7f;
        arrow.fireDelay = 2f;
        arrow.lockNumber = 1;
        arrow.damage = 50;
        arrow.ingameModelPrefabName = PATH_ARCHER + "Ranger";
        arrow.damageType = DamageType.Piercing;
        arrow.price = UPGRADE_4_PRICE;
        arrow.poolSize = 5;
        arrow.projectilePrefabName = PATH_PROJECTILE + "RangerArrow";
        arrow.shootImpl = new RangerArtillery(arrow);
        arrow.upgradeBranch = 1;
        arrow.upgradeCode = UPGRADE_NONE;
        arrow.imageUIindex = 20;
        arrow.description = "Rain 30 arrow to marked target.";
        arrow.Initialize();
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
        cannon.damage = 50;
        cannon.ingameModelPrefabName = PATH_CANNON + "TowerCannon";
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_1_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.upgradeCode = UPGRADE_CANNON;
        cannon.upgradeBranch = 2;
        cannon.imageUIindex = 5;
        cannon.description = "Shoot explosive projectile with area damage (Target Ground Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel Bombardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Bombardman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 3f;
        cannon.lockNumber = 1;
        cannon.damage = 150;
        cannon.ingameModelPrefabName = PATH_CANNON + "Bombardman";
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_2_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "cannonball";
        cannon.shootImpl = new CannonArtillery(cannon);
        cannon.upgradeCode = UPGRADE_BOMBARD;
        cannon.upgradeBranch = 3;
        cannon.imageUIindex = 5;
        cannon.description = "Shoot explosive projectile with area damage (Target Ground Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel Guardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Guardman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 1.5f;
        cannon.poolSize = 20;
        cannon.lockNumber = 1;
        cannon.damage = 40;
        cannon.ingameModelPrefabName = PATH_CANNON + "Guardman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_3_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "GuardmanCannon";
        cannon.shootImpl = new MultiProjectileGuardman(cannon, 10);
        cannon.targetingImpl = new AirTargetOnly();
        cannon.upgradeCode = UPGRADE_GUARDMAN;
        cannon.upgradeBranch = 2;
        cannon.imageUIindex = 9;
        cannon.description = "Shoot 10 small explosive projectile (Target Air Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel HighGuardman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "HighGuardman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 1.5f;
        cannon.lockNumber = 1;
        cannon.damage = 60;
        cannon.poolSize = 30;
        cannon.ingameModelPrefabName = PATH_CANNON + "HighGuardman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_4_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "GuardmanCannon";
        cannon.shootImpl = new MultiProjectileGuardman(cannon, 15);
        cannon.targetingImpl = new AirTargetOnly();
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
        cannon.imageUIindex = 9;
        cannon.description = "shoot 15 small explosive projectile (Target Air Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel Artilleryman()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Artilleryman";
        cannon.lockRange = 6f;
        cannon.fireDelay = 3f;
        cannon.lockNumber = 1;
        cannon.damage = 400;
        cannon.ingameModelPrefabName = PATH_CANNON + "Artilleryman";
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_3_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "StunCannonBall";
        cannon.shootImpl = new StunExplosiveArtillery(cannon);
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.upgradeCode = UPGRADE_ARTILLERYMAN;
        cannon.upgradeBranch = 3;
        cannon.imageUIindex = 4;
        cannon.description = "Shoot explosive projectile with area damage and stun effect (30% Chance) (Target Ground Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel Admiral()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Admiral";
        cannon.lockRange = 6f;
        cannon.fireDelay = 3f;
        cannon.lockNumber = 1;
        cannon.damage = 1200;
        cannon.ingameModelPrefabName = PATH_CANNON + "Admiral";
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_4_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "StunCannonBall";
        cannon.shootImpl = new StunExplosiveArtillery(cannon, 50);
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
        cannon.imageUIindex = 4;
        cannon.description = "Shoot explosive projectile with area damage and stun effect (30% Chance) (Target Ground Only).";
        cannon.Initialize(); return cannon;
    }

    static ArtilleryModel Pirate()
    {
        ArtilleryModel cannon = new ArtilleryModel();
        cannon.name = "Pirate";
        cannon.lockRange = 6f;
        cannon.fireDelay = 3f;
        cannon.lockNumber = 1;
        cannon.damage = 800;
        cannon.ingameModelPrefabName = PATH_CANNON + "Pirate";
        cannon.damageType = DamageType.Explosive;
        cannon.price = UPGRADE_4_PRICE;
        cannon.projectilePrefabName = PATH_PROJECTILE + "PirateBall";
        cannon.shootImpl = new PirateArtillery(cannon);
        cannon.targetingImpl = new GroundTargetOnly();
        cannon.upgradeCode = UPGRADE_NONE;
        cannon.upgradeBranch = 1;
        cannon.imageUIindex = 18;
        cannon.description = "Shoot explosive projectile with area damage and scatter 10 small explosive projectile around (Target Ground Only).";
        cannon.Initialize(); return cannon;
    }
    //end canon model

    //Gunner model
    static ArtilleryModel Gunner()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Gunner";
        gunner.lockRange = 7f;
        gunner.fireDelay = 2f;
        gunner.lockNumber = 1;
        gunner.damage = 50;
        gunner.ingameModelPrefabName = PATH_GUNNER + "TowerGunner";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_1_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Bullet1";
        gunner.shootImpl = new GunnerArtillery(gunner);
        gunner.upgradeCode = UPGRADE_GUNNER;
        gunner.upgradeBranch = 2;
        gunner.imageUIindex = 10;
        gunner.description = "Shoot Bullet to Enemy.";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel Shooter()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Shooter";
        gunner.lockRange = 7f;
        gunner.fireDelay = 2f;
        gunner.lockNumber = 1;
        gunner.damage = 150;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Shooter";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_2_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Bullet1";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_SHOOTER;
        gunner.upgradeBranch = 3;
        gunner.poolSize = 15;
        gunner.imageUIindex = 10;
        gunner.description = "Shoot Bullet to Enemy.";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel Sniper()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Sniper";
        gunner.lockRange = 9f;
        gunner.fireDelay = 2.5f;
        gunner.lockNumber = 1;
        gunner.damage = 600;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Sniper";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_3_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "PrecisionBullet";
        gunner.shootImpl = new PrecisionProjectileArtillery(gunner);
        gunner.targetingImpl = new HighestHealthOnly();
        gunner.poolSize = 12;
        gunner.upgradeCode = UPGRADE_SNIPER;
        gunner.upgradeBranch = 2;
        gunner.imageUIindex = 27;
        gunner.description = "Shoot Bullet to Enemy with very high damage (target enemy with highest Max HP).";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel Gunslinger()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Gunslinger";
        gunner.lockRange = 5.5f;
        gunner.fireDelay = 2f;
        gunner.lockNumber = 1;
        gunner.damage = 180;
        gunner.poolSize = 6;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Gunslinger";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_3_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "PrecisionBullet";
        gunner.shootImpl = new GunslingerArtillery(gunner);
        gunner.upgradeCode = UPGRADE_GUNSLINGER;
        gunner.upgradeBranch = 3;
        gunner.imageUIindex = 11;
        gunner.description = "Shoot 6 bullet to nearest enemy.";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel MasterSniper()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "MasterSniper";
        gunner.lockRange = 9f;
        gunner.fireDelay = 2.5f;
        gunner.lockNumber = 1;
        gunner.damage = 1600;
        gunner.ingameModelPrefabName = PATH_GUNNER + "MasterSniper";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_4_PRICE;
        gunner.targetingImpl = new HighestHealthOnly();
        gunner.projectilePrefabName = PATH_PROJECTILE + "PrecisionBullet";
        gunner.shootImpl = new PrecisionProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
        gunner.imageUIindex = 27;
        gunner.description = "Shoot Bullet to Enemy with very high damage (target enemy with highest Max HP).";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel Maniac()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Maniac";
        gunner.lockRange = 6f;
        gunner.fireDelay = 0.06f;
        gunner.lockNumber = 1;
        gunner.damage = 90;
        gunner.poolSize = 30;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Maniac";
        gunner.damageType = DamageType.Impact;
        gunner.price = UPGRADE_4_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "ManiacBullet";
        gunner.shootImpl = new LinearProjectileArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
        gunner.imageUIindex = 16;
        gunner.description = "Shoot bullet with very fast fire rate.";
        gunner.Initialize(); return gunner;
    }

    static ArtilleryModel Rocketer()
    {
        ArtilleryModel gunner = new ArtilleryModel();
        gunner.name = "Rocketer";
        gunner.lockRange = 7f;
        gunner.fireDelay = 4f;
        gunner.lockNumber = 1;
        gunner.damage = 600;
        gunner.ingameModelPrefabName = PATH_GUNNER + "Rocketeer";
        gunner.damageType = DamageType.Explosive;
        gunner.price = UPGRADE_4_PRICE;
        gunner.projectilePrefabName = PATH_PROJECTILE + "Rocket";
        gunner.shootImpl = new RocketArtillery(gunner);
        gunner.upgradeCode = UPGRADE_NONE;
        gunner.upgradeBranch = 1;
        gunner.imageUIindex = 28;
        gunner.description = "Shoot 3 homing rocket to enemy.";
        gunner.Initialize(); return gunner;
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
        mage.damage = 40;
        mage.ingameModelPrefabName = PATH_MAGE + "TowerMage";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_1_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "EnergyBall";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_MAGE;
        mage.upgradeBranch = 2;
        mage.imageUIindex = 14;
        mage.description = "shoot magical projectile and slow target.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Sorcerer()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Sorcerer";
        mage.lockRange = 7f;
        mage.fireDelay = 2f;
        mage.lockNumber = 1;
        mage.damage = 120;
        mage.ingameModelPrefabName = PATH_MAGE + "Sorcerer";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_2_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "EnergyBall";
        mage.shootImpl = new MageArtillery(mage);
        mage.upgradeCode = UPGRADE_SORCERER;
        mage.upgradeBranch = 4;
        mage.imageUIindex = 14;
        mage.description = "shoot magical projectile and slow target.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Wizard()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Wizard";
        mage.lockRange = 5f;
        mage.fireDelay = 3f;
        mage.lockNumber = 1;
        mage.damage = 160;
        mage.ingameModelPrefabName = PATH_MAGE + "Wizard";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_3_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "EnergyBallChain";
        mage.shootImpl = new ChainArtillery(mage);
        mage.upgradeCode = UPGRADE_WIZARD;
        mage.upgradeBranch = 2;
        mage.imageUIindex = 30;
        mage.description = "Bounce magical projectile up to 5 enemies and slow target.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Alchemist()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Alchemist";
        mage.lockRange = 7f;
        mage.fireDelay = 4f;
        mage.lockNumber = 1;
        mage.damage = 80;
        mage.ingameModelPrefabName = PATH_MAGE + "Alchemist";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_3_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "PoisonBottle";
        mage.shootImpl = new PoisonGasArtillery(mage);
        mage.upgradeCode = UPGRADE_ALCHEMIST;
        mage.upgradeBranch = 2;
        mage.imageUIindex = 2;
        mage.description = "Throw bottle of poison and deal damage over time.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Sage()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Sage";
        mage.lockRange = 5f;
        mage.fireDelay = 2.5f;
        mage.lockNumber = 1;
        mage.damage = 180;
        mage.ingameModelPrefabName = PATH_MAGE + "Sage";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_3_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "PrecisionEnergyBall";
        mage.shootImpl = new SageArtillery(mage);
        mage.upgradeCode = UPGRADE_SAGE;
        mage.upgradeBranch = 3;
        mage.imageUIindex = 23;
        mage.description = "Shoot 5 magical projectile to nearest enemy and slow target.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel HighWizard()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "HighWizard";
        mage.lockRange = 5f;
        mage.fireDelay = 3f;
        mage.lockNumber = 1;
        mage.damage = 300;
        mage.ingameModelPrefabName = PATH_MAGE + "HighWizard";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_4_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "EnergyBallChain";
        mage.shootImpl = new ChainArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
        mage.imageUIindex = 30;
        mage.description = "Bounce magical projectile up to 8 enemies and slow target.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel GrandAlchemist()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "GrandAlchemist";
        mage.lockRange = 7f;
        mage.fireDelay = 3f;
        mage.lockNumber = 1;
        mage.damage = 200;
        mage.ingameModelPrefabName = PATH_MAGE + "GrandAlchemist";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_4_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "PoisonBottle";
        mage.shootImpl = new PoisonGasArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
        mage.imageUIindex = 2;
        mage.description = "Throw bottle of poison and deal over time damage.";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Warlock()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Warlock";
        mage.lockRange = 7f;
        mage.fireDelay = 7f;
        mage.lockNumber = 1;
        mage.damage = 1200;
        mage.ingameModelPrefabName = PATH_MAGE + "Warlock";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_4_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "Meteor";
        mage.shootImpl = new MeteorArtillery(mage);
        mage.targetingImpl = new GroundTargetOnly();
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
        mage.imageUIindex = 23;
        mage.description = "Summon Meteor with very high damage and stun target (100% chance, grounds only)";
        mage.Initialize(); return mage;
    }

    static ArtilleryModel Shaman()
    {
        ArtilleryModel mage = new ArtilleryModel();
        mage.name = "Shaman";
        mage.lockRange = 7f;
        mage.fireDelay = 8f;
        mage.lockNumber = 1;
        mage.damage = 200;
        mage.ingameModelPrefabName = PATH_MAGE + "Shaman";
        mage.damageType = DamageType.Magic;
        mage.price = UPGRADE_4_PRICE;
        mage.projectilePrefabName = PATH_PROJECTILE + "Tornado";
        mage.shootImpl = new TornadoArtillery(mage);
        mage.upgradeCode = UPGRADE_NONE;
        mage.upgradeBranch = 1;
        mage.imageUIindex = 25;
        mage.description = "Summon Tornado with knockback effect (target grounds only)";
        mage.Initialize(); return mage;
    }
    //End Mage model
}
