using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private int damage;
    private DamageType damageType;

    public void SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage * 2;
        this.damageType = damageType;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
        }
    }
}
