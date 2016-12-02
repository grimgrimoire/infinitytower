using UnityEngine;
using System.Collections;

public class ChainProjectile : MonoBehaviour
{

    private GameObject target;
    private GameObject previousTarget;
    private int damage;
    private DamageType damageType;

    private int speed = 6;
    private int totalChain = 5;
    private int jumpTimes;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
    }

    private void HitTarget()
    {
        target.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
        previousTarget = target;
        target = null;
        if (jumpTimes > 0)
            SetNewTarget();
        else
            InactiveSelf();
    }

    public void SetTotalChain(int totalChain)
    {
        this.totalChain = totalChain;
    }

    public ChainProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        jumpTimes = totalChain;
        return this;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
        transform.right = target.transform.position - transform.position;
        StartCoroutine(ResetAiming());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == target.gameObject)
        {
            HitTarget();
        }
        if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            InactiveSelf();
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (target != null)
        {
            if (collider.gameObject == target.gameObject)
                HitTarget();
        }
    }

    private void SetNewTarget()
    {
        FindNewTarget();
        jumpTimes--;
        if (target == null)
            InactiveSelf();
        else
        {
            transform.right = target.transform.position - transform.position;
        }
    }

    private void InactiveSelf()
    {
        gameObject.SetActive(false);
    }

    private void FindNewTarget()
    {
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (hostile.activeSelf)
            {
                if (target == null)
                {
                    if (Vector2.Distance(hostile.transform.position, transform.position) < 3 && hostile != previousTarget)
                    {
                        target = hostile;
                    }
                }
                else
                {
                    if (Vector2.Distance(hostile.transform.position, transform.position) < 3 && previousTarget != hostile)
                        if (Vector2.Distance(hostile.transform.position, transform.position) < Vector2.Distance(target.transform.position, transform.position))
                        {
                            target = hostile;
                        }
                }
            }
        }
    }

    IEnumerator ResetAiming()
    {
        while (true && target.activeSelf)
        {
            yield return new WaitForSeconds(0.5f);
            transform.right = target.transform.position - transform.position;
        }
        InactiveSelf();
    }
}
