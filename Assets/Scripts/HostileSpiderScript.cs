using UnityEngine;
using System.Collections;
using System;

public class HostileSpiderScript : MonoBehaviour, HostileInterface {

    public void OnKilled()
    {
        for(int i = 0; i < 6; i++)
        {
            SpawnSpider(ObjectPool.GetInstance().GetMiniSpider());
        }
    }

    private void SpawnSpider(GameObject spiderMini)
    {
        if (spiderMini == null) return;

        spiderMini.SetActive(true);
        spiderMini.transform.position = (Vector2)transform.position + (UnityEngine.Random.insideUnitCircle * 0.3f) ;
        spiderMini.GetComponent<HostileMainScript>().SetHealthAndGoldMultiplier(0, GameSystem.GetGameSystem().GetSpawnSystem().healthMultiplier);
        spiderMini.GetComponent<HostileMainScript>().Recycle();
    }

    public void OnRecycled()
    {
    }
}
