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
        if (Vector2.Distance(transform.position, target) < 0.05f)
            gameObject.SetActive(false);
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 5 * Time.deltaTime);
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
        //StartCoroutine(Move());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            //StopAllCoroutines();
            gameObject.SetActive(false);
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            //StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    IEnumerator Move()
    {
        while (Vector2.Distance(transform.position, target) > 0.05f)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 5 * Time.deltaTime);
        }
        gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
