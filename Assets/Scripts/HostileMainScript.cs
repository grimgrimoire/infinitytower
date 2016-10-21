using UnityEngine;
using System.Collections;

public interface HostileInterface
{
    void OnRecycled();
    void OnKilled();
}

public class HostileMainScript : MonoBehaviour
{
    public int goldValue;
    public int health;
    public ArmorType armor;

    public bool isAlive;

    private HostileInterface hostileInterface;
    private int initialHealth;

    // Use this for initialization
    void Start()
    {
        hostileInterface = GetComponent<HostileInterface>();
        gameObject.SetActive(false);
        initialHealth = health;
    }

    void OnDestroy()
    {

    }

    public void Recycle()
    {
        GameSystem.GetGameSystem().AddHostile(this.gameObject);
        health = initialHealth;
        isAlive = true;
        hostileInterface.OnRecycled();
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        health -= Mathf.RoundToInt(CalculateDamageMultiplication(damageType) * damage);
        if (health <= 0)
        {
            Killed();
        }
    }

    private float CalculateDamageMultiplication(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Piercing:
                return CalculatePiercing();
            case DamageType.Explosive:
                return CalculateExplosive();
            case DamageType.Magic:
                return CalculateMagic();
            default:
                return 0;
        }
    }

    private float CalculatePiercing()
    {
        return GetDamageMultiplicationTable(1, 1, 1);
    }

    private float CalculateExplosive()
    {
        return GetDamageMultiplicationTable(1, 1, 1);
    }

    private float CalculateMagic()
    {
        return GetDamageMultiplicationTable(1, 1, 1);
    }

    private float GetDamageMultiplicationTable(float lightArmor, float MediumArmor, float heavyArmor)
    {
        switch (armor)
        {
            case ArmorType.Light:
                return lightArmor;
            case ArmorType.Medium:
                return MediumArmor;
            case ArmorType.Heavy:
                return heavyArmor;
            default:
                return 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_TOWER)
        {
            Killed();
        }
    }

    private void Killed()
    {
        GameSystem.GetGameSystem().AddGold(goldValue);
        GameSystem.GetGameSystem().RemoveHostile(this.gameObject);
        isAlive = false;
        hostileInterface.OnKilled();
        gameObject.SetActive(false);
    }
}
