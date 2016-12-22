using UnityEngine;
using System.Collections;
using System;

public class SlowDebuff : MonoBehaviour
{

    class SlowBuffScript : BuffScript
    {
        const string DEBUFF_TAG = "Slow debuff";

        public override void BuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(hostile.GetSpeed() - 0.5f);
        }

        public override float Duration()
        {
            return 2.5f;
        }

        public override string GetBuffTag()
        {
            return DEBUFF_TAG;
        }

        public override bool IsStackable()
        {
            return false;
        }

        public override void RemoveBuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(hostile.GetSpeed() + 0.5f);
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
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new SlowBuffScript());
        }
    }

}
