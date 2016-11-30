using System.Collections;
using UnityEngine;

public class RangerArrowProjectile : MonoBehaviour
{

    private Vector2 target;
    private int damage;
    private DamageType damageType;
    GameObject hit;
    Vector2 delta;
    bool isHit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target) > 0.05f && !isHit)
            transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 8 * Time.deltaTime);
        else if (hit != null)
        {
            transform.position = (Vector2)transform.position + ((Vector2)hit.transform.position - delta);
            delta = hit.transform.position;
        }
        else
            gameObject.SetActive(false);
    }

    public RangerArrowProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        isHit = false;
        hit = null;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE && !isHit)
        {
            isHit = true;
            StartCoroutine(RainNumerator());
            hit = collider.gameObject;
            delta = hit.transform.position;
        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD && !isHit)
        {
            isHit = true;
            StartCoroutine(RainNumerator());
        }
    }

    IEnumerator RainNumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            RainArrow();
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
    }

    private void RainArrows()
    {
        for (int i = 0; i < 10; i++)
        {
            RainArrow();
        }
    }

    private void RainArrow()
    {
        GameObject arrow = ObjectPool.GetInstance().GetArrow();
        if (arrow != null)
        {
            arrow.SetActive(true);
            ArtilleryProjectileForward arrowScript = arrow.GetComponent<ArtilleryProjectileForward>();
            arrowScript.transform.position = (Vector2)transform.position + Random.insideUnitCircle + (Vector2.up * 8);
            arrowScript.SetDamageType(damage, damageType).SetTarget((Vector2)transform.position + Random.insideUnitCircle * 0.3f);
        }
    }
}
