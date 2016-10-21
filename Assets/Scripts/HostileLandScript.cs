using UnityEngine;
using System.Collections;
using System;

public class HostileLandScript : MonoBehaviour, HostileInterface
{

    public float speed;
    Vector2 direction;

    HostileMainScript mainScript;
    Animator animator;

    public void OnKilled()
    {
        //rigid.velocity = Vector2.zero;
        //animator.speed = 1;
    }

    public void OnRecycled()
    {
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        //direction = new Vector2(1, 0) * speed;
        //rigid.velocity = direction;
        //animator.speed = 1;
    }

    // Use this for initialization
    void Start()
    {
        mainScript = GetComponent<HostileMainScript>();
        animator = GetComponentInChildren<Animator>();
        //animator.enabled = false;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Time.deltaTime * speed);
    }

}
