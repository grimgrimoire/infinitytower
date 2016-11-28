using UnityEngine;
using System.Collections;
using System;

public interface TowerAimingInterface
{
    void SetAiming(Vector2 target);
}

public class TowerAimingAnimation : MonoBehaviour, TowerAimingInterface {

    const string ANIMATION_INDEX = "TowerAnimation";
    const string AIMING_TAG = "Blend";

    public int towerAnimationIndex;

    Animator animator;

    public void SetAiming(Vector2 target)
    {
        animator.SetFloat(AIMING_TAG, GetAimingInFloat(target));
    }

    private float GetAimingInFloat(Vector2 target)
    {
        float angle = Vector2.Angle(Vector2.down, target - (Vector2)transform.position);
        return angle / 180;
    }

    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger(ANIMATION_INDEX, towerAnimationIndex);
        animator.Play("Idle");
        GetComponentInParent<ArtilleryScript>().SetAimingInterface(this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
