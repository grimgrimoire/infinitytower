using UnityEngine;
using System.Collections;

public class ArtilleryProjectile : MonoBehaviour
{

    private Vector2 target;
    private int damage;
    private DamageType damageType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        StartCoroutine(move());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            Destroy(gameObject);
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator move()
    {
        while (Vector2.Distance(transform.position, target) > 0.05f)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, 5 * Time.deltaTime);
        }
        Destroy(this.gameObject);
        yield return new WaitForEndOfFrame();
    }
}
