using UnityEngine;
using System.Collections;

public class HostileLandScript : MonoBehaviour
{

    public Rigidbody2D rigid;
    public float speed;
    Vector2 direction;

    // Use this for initialization
    void Start()
    {
        if (transform.position.x > 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        direction = new Vector2(1, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = direction;
    }
}
