using UnityEngine;
using System.Collections;

public class TornadoProjectile : MonoBehaviour {

    private Vector2 target;
    private int damage;
    private DamageType damageType;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, 3 * Time.deltaTime);
    }

    public TornadoProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        direction = new Vector3(target.x - transform.position.x, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            gameObject.SetActive(false);
        }
    }
}
