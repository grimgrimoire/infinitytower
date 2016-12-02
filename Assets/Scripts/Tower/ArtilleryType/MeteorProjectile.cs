using UnityEngine;
using System.Collections;

public class MeteorProjectile : MonoBehaviour {

    private Vector2 target;
    private int damage;
    private DamageType damageType;

    private int speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < target.y)
            ExplodeOnImpact();
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
    }

    public MeteorProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        //{
        //    collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
        //    //gameObject.SetActive(false);
        //}
        if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            ExplodeOnImpact();
        }
    }

    void ExplodeOnImpact()
    {
        GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetMeteorExplosion();
        explosion.SetActive(true);
        explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
        explosion.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
