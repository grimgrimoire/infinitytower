using UnityEngine;
using System.Collections;

public class ArtilleryBouncingProjectile : MonoBehaviour
{

    private Vector2 target;
    private GameObject Objecttarget;
    private int damage;
    private DamageType damageType;
    public bool isLeft;
    private GameObject lockedTarget;
    private ArtilleryModel model;
    bool CheckCollider=false;
    int count=0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 5 * Time.deltaTime);
        if (CheckCollider == true)
        {
            //Debug.Log(lockedTarget.transform.position);
            //transform.LookAt(lockedTarget.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, lockedTarget.transform.position, Time.deltaTime);
        }
    }

    public ArtilleryBouncingProjectile SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTargetObject(GameObject Objecttarget)
    {
        this.Objecttarget = Objecttarget;
        transform.right = (Vector2)Objecttarget.transform.position - (Vector2)transform.position;
        lockedTarget = Objecttarget;
    }

    /*public void SetTargetPosition(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        //StartCoroutine(Move());
    }*/

    private bool IsTargetInRange(GameObject hostile)
    {
        if (isLeft)
        {
            return hostile.transform.position.x < transform.position.x && Vector2.Distance(transform.position, hostile.transform.position) < model.lockRange;
        }
        else
        {
            return hostile.transform.position.x > transform.position.x && Vector2.Distance(transform.position, hostile.transform.position) < model.lockRange;
        }
    }

    private void FindNextTarget()
    {
        //Debug.Log(lockedTarget.transform.position);
        //float distance = lockedTarget.transform.position.sqrMagnitude;
        float distance = Mathf.Infinity;
        count++;
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (hostile.activeSelf)
            {
                if (hostile != lockedTarget)
                {
                    
                    Vector2 diff = hostile.transform.position - transform.position;
                    //Debug.Log(diff);
                    float currdistance = diff.sqrMagnitude;
                    //Debug.Log(currdistance);
                    if (currdistance < distance)
                    {
                        Debug.Log(currdistance);
                        //Debug.Log(hostile.transform.position);
                        lockedTarget = hostile;
                        distance = currdistance;
                        CheckCollider = true;
                        
                    }
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            //StopAllCoroutines();
            if (count < 2)
            {
                FindNextTarget();
                
            }
            else
            {
                gameObject.SetActive(false);
                CheckCollider = false;
                count = 0;
            }


        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            //StopAllCoroutines();
            //gameObject.SetActive(false);
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
