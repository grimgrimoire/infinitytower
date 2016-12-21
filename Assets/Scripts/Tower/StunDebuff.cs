using UnityEngine;
using System.Collections;

public class StunDebuff : MonoBehaviour
{
    public int chance = 30;
    public float duration = 2;

    class StunBuffScript : BuffScript
    {
        const string DEBUFF_TAG = "Stun debuff";
        private int chance;
        private float duration;

        public StunBuffScript(int chance, float duration)
        {
            this.chance = chance;
            this.duration = duration;
        }

        public override void BuffEffect(HostileMainScript hostile)
        {
            if(Random.Range(0, 101) < chance)
                hostile.SetSpeed(0f);
        }

        public override float Duration()
        {
            return duration;
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

    public void SetChance(int chance)
    {
        this.chance = chance;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == TagsAndLayers.TAG_HOSTILE)
        {
            collider.gameObject.GetComponent<HostileMainScript>().SetBuff(new StunBuffScript(chance, duration));
        }
    }
}
