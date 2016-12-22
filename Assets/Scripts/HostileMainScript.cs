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
    public bool isShield = false;
    public CorpsePrefab corpse;
    public float inactiveDelay;
    public Animator animator;
    public int cost;
    public float animationSpeed = 1;

    private HostileInterface[] hostileInterfaces;
    private int initialHealth;
    private int initialGold;
    private int healthAfterMultiplier;
    private Transform healthBar;
    private float speed = 1;
    private float damageBonusMultiplier = 1;
    private Dictionary<string, BuffScript> buffList;

    public int MaxHealth()
    {
        return healthAfterMultiplier;
    }

    // Use this for initialization
    void Start()
    {
        healthBar = transform.FindChild("HealthBar");
        if (!isShield)
            gameObject.SetActive(false);
        initialHealth = health;
        initialGold = goldValue;
        buffList = new Dictionary<string, BuffScript>();
    }

    void OnDestroy()
    {

    }

    public void SetDamageBonus(float bonus)
    {
        damageBonusMultiplier = bonus;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        if (animator != null)
            animator.speed = speed * animationSpeed;
    }

    public void Recycle()
    {
        if (hostileInterfaces == null)
            hostileInterfaces = GetComponents<HostileInterface>();
        SetSpeed(1);
        if (corpse == CorpsePrefab.Animation)
        {
            animator.Play("Walk");
            animator.speed = animationSpeed;
        }
        if (!isShield)
            GameSystem.GetGameSystem().AddHostile(this.gameObject);
        health = healthAfterMultiplier;
        if (healthBar != null)
            healthBar.localScale = new Vector3(1, 1, 1);
        isAlive = true;
        HostileInterfaceRecycle();
    }

    private void HostileInterfaceRecycle()
    {
        foreach (HostileInterface impl in hostileInterfaces)
        {
            impl.OnRecycled();
        }
    }

    private void HostileInterfaceKilled()
    {
        foreach (HostileInterface impl in hostileInterfaces)
        {
            impl.OnKilled();
        }
    }

    public void SetHealthAndGoldMultiplier(float goldM, float healthM)
    {
        if (initialHealth == 0)
            initialHealth = health;
        healthAfterMultiplier = Mathf.RoundToInt(initialHealth * healthM);
        goldValue = Mathf.RoundToInt(initialGold * goldM);
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        if (health > 0)
        {
            health -= Mathf.RoundToInt(CalculateDamageMultiplication(damageType) * damage * damageBonusMultiplier);
            if (healthBar != null)
                healthBar.localScale = new Vector3((health / (float)healthAfterMultiplier), 1, 1);
            if (health <= 0)
            {
                if (healthBar != null)
                    healthBar.localScale = Vector3.zero;
                Killed();
            }
        }
    }

    public void SetBuff(BuffScript buff)
    {
        if (health > 0)
            buff.GetBuff(this);
    }

    public void AddBuffTag(BuffScript buff)
    {
        buffList.Add(buff.GetBuffTag(), buff);
    }

    public void RemoveBuffTag(string tag)
    {
        buffList.Remove(tag);
    }

    public bool IsAlreadyHasBuff(string tag)
    {
        return buffList.ContainsKey(tag);
    }

    public void ResetBuffDuration(string tag)
    {
        buffList[tag].ResetDuration();
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
        return GetDamageMultiplicationTable(1.25f, 1, 0.5f, 1.5f);
    }

    private float CalculateImpact()
    {
        return GetDamageMultiplicationTable(0.5f, 1, 1.5f, 1.25f);
    }

    private float CalculateMagic()
    {
        return GetDamageMultiplicationTable(0.75f, 1.25f, 1.25f, 1);
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
        if (collider.tag == TagsAndLayers.TAG_TOWER || collider.tag == TagsAndLayers.TAG_KILLZONE)
        {
            Killed();
        }
    }

    private void Killed()
    {
        GameSystem.GetGameSystem().AddGold(goldValue);
        if (!isShield)
            GameSystem.GetGameSystem().RemoveHostile(this.gameObject);
        isAlive = false;
        buffList.Clear();
        speed = 1;
        if (animator != null)
            animator.speed = animationSpeed;
        HostileInterfaceKilled();
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
            animator.speed = 1;
            animator.Play("Dead");
            StartCoroutine(InactiveDelay());
        }
        else if (corpse == CorpsePrefab.Explosion)
        {
            GameObject expl = GameSystem.GetGameSystem().GetObjectPool().GetAirDeath();
            expl.transform.position = transform.position;
            expl.SetActive(true);
            gameObject.SetActive(false);
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
