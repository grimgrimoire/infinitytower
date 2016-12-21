using UnityEngine;
using System.Collections;

public class PrecisionProjectile : MonoBehaviour
{

    private GameObject target;
    private int damage;
    private DamageType damageType;

    private int speed = 12;
    private bool moving;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
    }

    public PrecisionProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        GetComponent<SpriteRenderer>().enabled = true;
        moving = true;
        return this;
    }

    public PrecisionProjectile SetSpeed(int speed)
    {
        this.speed = speed;
        return this;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
        transform.right = target.transform.position - transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == target.gameObject)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            StartCoroutine(InactiveSelf());
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            StartCoroutine(InactiveSelf());
        }
    }

    IEnumerator InactiveSelf()
    {
        moving = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
