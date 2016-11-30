using UnityEngine;
using System.Collections;

public class RocketProjectile : MonoBehaviour
{

    private GameObject target;
    private int damage;
    private DamageType damageType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.activeSelf)
            transform.right = target.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 3 * Time.deltaTime);
    }

    public RocketProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
        StartCoroutine(RescanTarget());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE || collider.tag == TagsAndLayers.TAG_WORLD)
        {
            GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetExplosion();
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    IEnumerator RescanTarget()
    {
        while (gameObject.activeSelf)
        {
            if (!target.activeSelf)
            {
                FindNewTarget();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void FindNewTarget()
    {
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (hostile.activeSelf)
            {
                if (!target.activeSelf)
                {
                    if (Vector2.Distance(hostile.transform.position, transform.position) < 3)
                        target = hostile;
                }
                else
                {
                    if (Vector2.Distance(hostile.transform.position, transform.position) < 3)
                        if (Vector2.Distance(hostile.transform.position, transform.position) < Vector2.Distance(target.transform.position, transform.position))
                            target = hostile;
                }
            }
        }
    }

}
