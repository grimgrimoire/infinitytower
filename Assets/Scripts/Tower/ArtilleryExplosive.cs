﻿using UnityEngine;
using System.Collections;

public class ArtilleryExplosive : MonoBehaviour
{

    public GameObject explosionPrefab;

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

    public ArtilleryExplosive SetDamageType(int damage, DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
        return this;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        //StartCoroutine(Move());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE || collider.tag == TagsAndLayers.TAG_WORLD)
        {
            //collider.GetComponent<HostileMainScript>().TakeDamage(damage, damageType);
            GameObject explosion = GameSystem.GetGameSystem().GetObjectPool().GetExplosion();
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().SetDamageType(damage, damageType);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    void DismisExplosion(GameObject explosion)
    {
        explosion.SetActive(false);
    }

    //IEnumerator Move()
    //{
    //    while (true)
    //    {
            
    //        yield return new WaitForEndOfFrame();
    //    }
    //}
}
