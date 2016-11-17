using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public bool isGroundUnit;
    public bool isAlive;
    public CorpsePrefab corpse;
    public float inactiveDelay;
    public Animator animator;

    private HostileInterface hostileInterface;
    private int initialHealth;
    private int initialGold;
    private int healthAfterMultiplier;
    private Transform healthBar;
    private float speed = 1;

    // Use this for initialization
    void Start()
    {
        hostileInterface = GetComponent<HostileInterface>();
        healthBar = transform.FindChild("HealthBar");
        gameObject.SetActive(false);
        initialHealth = health;
        initialGold = goldValue;
    }

    void OnDestroy()
    {

    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void Recycle()
    {
        if (corpse == CorpsePrefab.Animation)
            animator.Play("Walk");
        GameSystem.GetGameSystem().AddHostile(this.gameObject);
        health = healthAfterMultiplier;
        healthBar.localScale = new Vector3(1, 0.2f, 1);
        isAlive = true;
        hostileInterface.OnRecycled();
    }

    public void SetHealthAndGoldMultiplier(int goldM, float healthM)
    {
        healthAfterMultiplier = Mathf.RoundToInt(initialHealth * healthM);
        goldValue = initialGold * goldM;
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        health -= Mathf.RoundToInt(CalculateDamageMultiplication(damageType) * damage);
        healthBar.localScale = new Vector3((health / (float)healthAfterMultiplier), 0.2f, 1);
        if (health <= 0)
        {
            healthBar.localScale = Vector3.zero;
            Killed();
        }
    }

    public void SetBuff(BuffScript buff)
    {
        StartCoroutine(buff.BuffEffectRoutine(this));
    }

    private float CalculateDamageMultiplication(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Piercing:
                return CalculatePiercing();
            case DamageType.Explosive:
                return CalculateExplosive();
            case DamageType.Impact:
                return CalculateImpact();
            case DamageType.Magic:
                return CalculateMagic();
            default:
                return 0;
        }
    }

    private float CalculatePiercing()
    {
        return GetDamageMultiplicationTable(1.5f, 0.75f, 0.75f, 1.25f);
    }

    private float CalculateExplosive()
    {
        return GetDamageMultiplicationTable(1.25f, 1, 0.5f, 50f);
    }

    private float CalculateImpact()
    {
        return GetDamageMultiplicationTable(1, 1, 1, 1);
    }

    private float CalculateMagic()
    {
        return GetDamageMultiplicationTable(1, 1, 1, 1);
    }

    private float GetDamageMultiplicationTable(float lightArmor, float MediumArmor, float heavyArmor, float noArmor)
    {
        switch (armor)
        {
            case ArmorType.Light:
                return lightArmor;
            case ArmorType.Medium:
                return MediumArmor;
            case ArmorType.Heavy:
                return heavyArmor;
            case ArmorType.NoArmor:
                return noArmor;
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
        ShowCorpse();
    }

    private void ShowCorpse()
    {
        if (corpse == CorpsePrefab.Blood)
        {
            GameObject blood = GameSystem.GetGameSystem().GetObjectPool().GetBlood();
            blood.transform.position = transform.position;
            blood.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (corpse == CorpsePrefab.Animation)
        {
            animator.Play("Dead");
            StartCoroutine(InactiveDelay());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator InactiveDelay()
    {
        yield return new WaitForSeconds(inactiveDelay);
        gameObject.SetActive(false);
    }
}
