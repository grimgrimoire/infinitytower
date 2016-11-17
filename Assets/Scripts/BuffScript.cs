using UnityEngine;
using System.Collections;

public abstract class BuffScript{

    public IEnumerator BuffEffectRoutine(HostileMainScript script)
    {
        BuffEffect(script);
        yield return new WaitForSeconds(Duration());
        RemoveBuffEffect(script);
    }

    public abstract void BuffEffect(HostileMainScript hostile);

    public abstract void RemoveBuffEffect(HostileMainScript hostile);

    public abstract float Duration();
}
