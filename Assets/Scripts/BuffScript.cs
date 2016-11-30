using UnityEngine;
using System.Collections;

public abstract class BuffScript
{
    float duration;

    public void GetBuff(HostileMainScript script)
    {
        if (!script.IsAlreadyHasBuff(GetBuffTag()) && script.isActiveAndEnabled)
        {
            if (!IsStackable())
            {
                script.AddBuffTag(this);
            }
            duration = Duration();
            script.StartCoroutine(BuffEffectRoutine(script));
        }
        else if (!IsStackable() && script.IsAlreadyHasBuff(GetBuffTag()))
        {
            script.ResetBuffDuration(GetBuffTag());
        }
    }

    private IEnumerator BuffEffectRoutine(HostileMainScript script)
    {
        BuffEffect(script);
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        RemoveBuffEffect(script);
        if (!IsStackable())
            script.RemoveBuffTag(GetBuffTag());
    }

    public void ResetDuration()
    {
        duration = Duration();
    }

    public abstract void BuffEffect(HostileMainScript hostile);

    public abstract void RemoveBuffEffect(HostileMainScript hostile);

    public abstract float Duration();

    public abstract string GetBuffTag();

    public abstract bool IsStackable();
}
