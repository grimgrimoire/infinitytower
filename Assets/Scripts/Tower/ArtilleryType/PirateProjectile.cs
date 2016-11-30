using UnityEngine;
using System.Collections;

public class PirateProjectile : MonoBehaviour {

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
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 5 * Time.deltaTime);
    }

    public PirateProjectile SetDamageType(int damage, DamageType damageType)
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
            GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetExplosion();
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
            explosion.transform.position = transform.position;
            Scatter();
            gameObject.SetActive(false);
        }
    }

    private void Scatter()
    {
        for(int i=0; i<10; i++)
        {
            GenerateMiniBomb();
        }
    }

    private void GenerateMiniBomb()
    {
        GameObject bomb = ObjectPool.GetInstance().GetScatter();
        if (bomb != null)
        {
            bomb.SetActive(true);
            bomb.transform.position = transform.position;
            bomb.GetComponent<ScatterExplosives>().SetDamageType(damage, damageType).SetTarget((Vector2)transform.position + Random.insideUnitCircle );
        }
    }

}
