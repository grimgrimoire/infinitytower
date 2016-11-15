using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private int damage;
    private DamageType damageType;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StartCoroutine(InactiveSelf());
    }

    IEnumerator InactiveSelf()
    {
        yield return new WaitForSeconds(0.35f);
        gameObject.SetActive(false);
    }

    public void SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
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
