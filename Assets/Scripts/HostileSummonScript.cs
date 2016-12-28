using UnityEngine;
using System.Collections;
using System;

public class HostileSummonScript : MonoBehaviour, HostileInterface {

    public void OnKilled()
    {

    }

    public void OnRecycled()
    {
        StartCoroutine(SpawnZeppelin());
    }

    IEnumerator SpawnZeppelin()
    {
        while (GameSystem.GetGameSystem().IsGameStarted())
        {
            SpawnBalloon(ObjectPool.GetInstance().GetMiniBalloon());
            yield return new WaitForSeconds(10);
        }
    }

    private void SpawnBalloon(GameObject balloonMini)
    {
        if (balloonMini == null) return;

        balloonMini.SetActive(true);
        balloonMini.transform.position = (Vector2)transform.position;
        balloonMini.GetComponent<HostileMainScript>().SetHealthAndGoldMultiplier(0, GameSystem.GetGameSystem().GetSpawnSystem().healthMultiplier);
        balloonMini.GetComponent<HostileMainScript>().Recycle();
    }
}
