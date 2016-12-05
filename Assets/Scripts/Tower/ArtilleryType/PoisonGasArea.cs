using UnityEngine;
using System.Collections;

public class PoisonGasArea : MonoBehaviour
{
    const string GAS = "";
    const string GAS_GONE = "";

    Animator animator;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        animator = GetComponent<Animator>();
        animator.Play(GAS);
        StartCoroutine(Dissipate());
    }

    IEnumerator Dissipate()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    void DissipateAnimation()
    {
        animator.Play(GAS_GONE);
    }
}
