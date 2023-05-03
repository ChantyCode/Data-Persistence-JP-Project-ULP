using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;
    
    public string highScoreName;
    public int hiScore;

    public string playerName;
    public int currentScore;

    void Awake()
    {
        File.Delete("/savefile.json");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void SetName(TMP_InputField username)
    {
        playerName = username.text;
    }

    [System.Serializable]
    class SaveData
    {
        public int hiScore;
        public string highScoreName;
    }
    public void SaveScore(int currentScore, string playerName)
    {
        SaveData data = new SaveData();

        data.hiScore = currentScore;
        data.highScoreName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.hiScore;
            highScoreName = data.highScoreName;
        }
    }
}
