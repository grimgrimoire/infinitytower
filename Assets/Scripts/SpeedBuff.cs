using UnityEngine;
using System.Collections;

public class SpeedBuff : MonoBehaviour {
    public class HealthBuffScript : BuffScript
    {
        const string TAG = "SPEED_BUFF";
        int buffed;

        public override void BuffEffect(HostileMainScript hostile)
        {
            hostile.SetSpeed(hostile.GetSpeed() + 0.2f);
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
            hostile.SetSpeed(hostile.GetSpeed() - 0.2f);
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
