using UnityEngine;
using System.Collections;
using System;

public class PoisonDebuff : MonoBehaviour {

    public class PoisonDebuffScript : BuffScript
    {
        const String TAG = "POISON_DEBUFF";
        Coroutine damageTick;
        HostileMainScript hostile;
        int damage;

        public PoisonDebuffScript(int damage)
        {
            this.damage = damage;
        }

        public override void BuffEffect(HostileMainScript hostile)
        {
            this.hostile = hostile;
            //damageTick = hostile.StartCoroutine(DamageTick());
            hostile.StartCoroutine(DamageTick());
        }

        public override float Duration()
        {
            return 3;
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
            //hostile.StopCoroutine(damageTick);
        }

        IEnumerator DamageTick()
        {
            while (hostile.health > 0)
            {
                hostile.TakeDamage(damage, DamageType.Magic);
                if (hostile.health < 0)
                {
                    hostile.RemoveBuffTag(GetBuffTag());
                    break;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    int damage = 50;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        //{
        //    collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new PoisonDebuffScript());
        //}
    }
    
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new PoisonDebuffScript(damage));
        }
    }
}
