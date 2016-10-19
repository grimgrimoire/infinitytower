using UnityEngine;
using System.Collections;

public class HostileMainScript : MonoBehaviour
{

    public int goldValue;
    public int health;
    public ArmorType armor;

    // Use this for initialization
    void Start()
    {
        GameSystem.GetGameSystem().AddHostile(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {

    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        health -= Mathf.RoundToInt(CalculateDamageMultiplication(damageType) * damage);
        if (health <= 0)
        {
            DestroyAndUnregister();
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
            DestroyAndUnregister();
        }
    }

    private void DestroyAndUnregister()
    {
        GameSystem.GetGameSystem().AddGold(goldValue);
        GameSystem.GetGameSystem().RemoveHostile(this.gameObject);
        Destroy(gameObject);
    }
}
