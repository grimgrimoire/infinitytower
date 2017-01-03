using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreSystem
{

    const string RECORD = "REC";

    const int DEFAULT = 0;

    public static List<int> LoadData()
    {
        List<int> datas = new List<int>();
        for (int i = 1; i <= 6; i++)
        {
            datas.Add(PlayerPrefs.GetInt(RECORD + i, DEFAULT));
        }

        return datas;
    }

    public static void SaveData(int score)
    {
        List<int> datas = new List<int>();
        int val;
        int thisScore = score;
        int j = 1;
        for (int i = 1; i <= 6; i++)
        {
            val = PlayerPrefs.GetInt(RECORD + j, DEFAULT);
            if (thisScore > val)
            {
                datas.Add(score);
                thisScore = 0;
            }
            else
            {
                datas.Add(val);
                j++;
            }
        }
        for (int i = 1; i <= 6; i++)
        {
            PlayerPrefs.SetInt(RECORD + i, datas[i-1]);
        }
        PlayerPrefs.Save();
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
