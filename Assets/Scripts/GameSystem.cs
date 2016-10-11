using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameSystem : MonoBehaviour {

    public int gold;
    public InfoUI infoUI;

    static GameSystem instance;
    List<GameObject> hostiles;
    bool isPaused;
    bool isGameStarted;

	// Use this for initialization
	void Start () {
        if (instance != null)
            Destroy(instance);
        instance = this;
        hostiles = new List<GameObject>();
        StartCoroutine(updateHostile());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator updateHostile()
    {
        yield return new WaitForSeconds(1f);
        hostiles = GameObject.FindGameObjectsWithTag(TagsAndLayers.TAG_HOSTILE).ToList();
        GameObject.FindGameObjectWithTag(TagsAndLayers.TAG_TOWER).GetComponent<TowerFloorScript>().LoadTowerFloorToUI();
        isGameStarted = true;
        isPaused = false;
    }

    public void SetGamePaused(bool pause)
    {
        isPaused = pause;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public static GameSystem GetGameSystem()
    {
        return instance;
    }

    public void AddHostile(GameObject hostile)
    {
        hostiles.Add(hostile);
    }

    public void RemoveHostile(GameObject hostile)
    {
        hostiles.Remove(hostile);
    }

    public List<GameObject> GetHostiles()
    {
        return hostiles;
    }

    public void UpdateGoldValue()
    {
        infoUI.UpdateGold(gold);
    }
}
