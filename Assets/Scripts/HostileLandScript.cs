using UnityEngine;
using System.Collections;
using System;

public class HostileLandScript : MonoBehaviour, HostileInterface
{

    public Rigidbody2D rigid;
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
        //if (transform.position.x > 0)
        //{
        //    speed = -speed;
        //    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //}
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
