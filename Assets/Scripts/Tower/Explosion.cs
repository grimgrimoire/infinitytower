using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private int damage;
    private DamageType damageType;
    public bool fallOff = false;

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
        yield return new WaitForSeconds(0.5f);
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
            if (fallOff)
            {
                float dist = Vector2.Distance(collider.transform.position, transform.position);
                if(dist < 0.5f)
                    collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
                else
                    collider.GetComponent<HostileMainScript>().TakeDamage(Mathf.RoundToInt(damage / (dist * 2)), damageType);
            }
            else
            {
                collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            }
        }
    }
}
