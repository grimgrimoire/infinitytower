using UnityEngine;
using System.Collections;

public class ScatterExplosives : MonoBehaviour {

    private Vector2 target;
    private int damage;
    private DamageType damageType;
    bool isExploded;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 2 * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.1 && !isExploded)
        {
            isExploded = true;
            Explode();
        }
    }

    public ScatterExplosives SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage/4;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        isExploded = false;
    }

    private void Explode()
    {
        GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetGuardmanEx();
        if (explosion != null)
        {
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }
}
