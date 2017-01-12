using UnityEngine;
using System.Collections;

public class ArtilleryProjectile : MonoBehaviour
{
    private Vector2 target;
    private int damage;
    private DamageType damageType;
    public float delay = 0;
    private int speed = 5;
    private SpriteRenderer sprites;
    private BoxCollider2D col;

    // Use this for initialization
    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target) < 0.05f)
            StartCoroutine(Dissable());
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
    }

    public ArtilleryProjectile SetSpeed(int speed)
    {
        this.speed = speed;
        return this;
    }

    public ArtilleryProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        sprites.enabled = true;
        col.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            StartCoroutine(Dissable());
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            StartCoroutine(Dissable());
        }
    }

    IEnumerator Dissable()
    {
        col.enabled = false;
        sprites.enabled = false;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
