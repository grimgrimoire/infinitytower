using UnityEngine;
using System.Collections;

public class GuardmanExplosive : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 7 * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.1)
        {
            Explode();
        }
    }

    public GuardmanExplosive SetDamageType(int damage, DamageType damageType)
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
        if (collider.tag == TagsAndLayers.TAG_HOSTILE || collider.tag == TagsAndLayers.TAG_WORLD)
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetGuardmanEx();
        explosion.SetActive(true);
        explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
        explosion.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
