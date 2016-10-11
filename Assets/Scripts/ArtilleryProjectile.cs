using UnityEngine;
using System.Collections;

public class ArtilleryProjectile : MonoBehaviour
{

    private Vector2 target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        transform.right = target - (Vector2)transform.position;
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        while (Vector2.Distance(transform.position, target) > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, 5 * Time.deltaTime);
        }
        Destroy(this.gameObject);
        yield return new WaitForEndOfFrame();
    }
}
