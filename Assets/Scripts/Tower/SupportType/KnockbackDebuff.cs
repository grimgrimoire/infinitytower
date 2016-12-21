using UnityEngine;
using System.Collections;
using System;

public class KnockbackDebuff : MonoBehaviour
{

    class KnockbackDebuffScript : BuffScript
    {
        const string TAG = "KNOCKBACK_DEBUFF";

        public override void BuffEffect(HostileMainScript hostile)
        {
            if (hostile.armor != ArmorType.Heavy)
                hostile.SetSpeed(-10);
        }

        public override float Duration()
        {
            return 0.1f;
        }

        public override string GetBuffTag()
        {
            return TAG;
        }

        public override bool IsStackable()
        {
            return false;
        }

        public override void RemoveBuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(1);
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
            collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new KnockbackDebuffScript());
        }
    }

}
