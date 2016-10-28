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
        //transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, 5 * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, lockedTarget.transform.position, 5*Time.deltaTime);
        /*if(transform.position == lockedTarget.transform.position)
        {
            FindNextTarget();
        }*/
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

    private void FindNextTarget()
    {
        float distance = Mathf.Infinity;
        count++;
        foreach (GameObject hostile in GameSystem.GetGameSystem().GetHostiles())
        {
            if (hostile.activeSelf)
            {
                if (hostile != lockedTarget)
                {
                    //Vector2 diff = transform.position - hostile.transform.position;
                    //float currdistance = diff.sqrMagnitude;
                    if (Vector2.Distance(transform.position,hostile.transform.position) < distance)
                    {
                        lockedTarget = hostile;
                        distance = lockedTarget.transform.position.sqrMagnitude;
                        Debug.Log(distance);
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
                count = 0;
            }


        }
        else if (collider.tag == TagsAndLayers.TAG_WORLD)
        {
            //StopAllCoroutines();
            //gameObject.SetActive(false);
        }
    }

}
