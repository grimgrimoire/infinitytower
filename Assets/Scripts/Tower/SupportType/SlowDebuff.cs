using UnityEngine;
using System.Collections;
using System;

public class SlowDebuff : MonoBehaviour
{

    class SlowBuffScript : BuffScript
    {
        public override void BuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(0f);
        }

        public override float Duration()
        {
            return 5;
        }

        public override void RemoveBuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(1f);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (UnityEngine.Random.Range(0, 100) > 70)
            if (collider.tag == TagsAndLayers.TAG_HOSTILE)
            {
                collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new SlowBuffScript());
            }
    }

}
