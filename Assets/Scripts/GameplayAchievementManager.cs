using UnityEngine;
using System.Collections;

public class GameplayAchievementManager : MonoBehaviour {

    int totalKill;
    int totalChemicalDamage;
    int totalDragonKilled;
    int totalKnightKilled;
    bool isImpenetrable = true;
    bool isMagicUsed = false;

	// Use this for initialization
	void Start () {
        isImpenetrable = true;
        isMagicUsed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChemicalDamage(int damage)
    {
        totalChemicalDamage += damage;
    }

    public void UseMagic()
    {
        isMagicUsed = true;
    }

    public void TakeDamageBefore50()
    {
        isImpenetrable = false;
    }

    public void Kill()
    {
        totalKill++;
    }

    public void DragonKill()
    {
        totalDragonKilled++;
    }

    public void KnightKill()
    {
        totalKnightKilled++;
    }

    public void CheckAchievement50()
    {
        if (isImpenetrable)
            PTDPlay.AchImpenetrable();
        if (!isMagicUsed)
            PTDPlay.AchNoMagic();
    }

    public void GameOver()
    {
        PTDPlay.AchChemical(totalChemicalDamage / 100000);
        PTDPlay.AchKnight(totalKnightKilled);
        PTDPlay.AchDragon(totalDragonKilled);
        PTDPlay.AchVeteran(totalKill/10);
    }
}
