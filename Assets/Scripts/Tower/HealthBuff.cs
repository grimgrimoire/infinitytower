using UnityEngine;
using System.Collections;
using System;

public class HealthBuff : MonoBehaviour {

    public class HealthBuffScript : BuffScript
    {
        const string TAG = "HEALTH_BUFF";
        int buffed;

        public override void BuffEffect(HostileMainScript hostile)
        {
            buffed = Mathf.RoundToInt((hostile.MaxHealth() * 0.2f));
            hostile.health += buffed;
        }

        public override float Duration()
        {
            return 1;
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
            hostile.health = buffed > hostile.health ? 1 : hostile.health - buffed;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new HealthBuffScript());
        }
    }

}
