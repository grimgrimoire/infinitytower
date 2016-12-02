using UnityEngine;
using System.Collections;

public class ImpreciseProjectile : MonoBehaviour {

    private Vector2 target;
    private int damage;
    private DamageType damageType;

    private int speed = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
    }

    public ImpreciseProjectile SetSpeed(int speed)
    {
        this.speed = speed;
        return this;
    }

    public ImpreciseProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            if (Random.Range(0, 101) > 30)
            {
                collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
                gameObject.SetActive(false);
            }
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            gameObject.SetActive(false);
        }
    }
}
