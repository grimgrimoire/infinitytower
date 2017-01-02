using UnityEngine;
using System.Collections;
using System;

public interface TowerSoundInterface
{
    void StartSound();
    void StopSound();
}

public class PlaySoundOnShoot : MonoBehaviour, TowerSoundInterface {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Playsound()
    {

    }

    public void StopSound()
    {

    }

    public void StartSound()
    {
        throw new NotImplementedException();
    }
}
