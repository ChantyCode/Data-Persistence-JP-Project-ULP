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

    // Data persistence between sessions 
    
    [System.Serializable]
    class SaveData
    {
        public int hiScore;
        public string highScoreName;
    }
    public void SaveScore(int currentScore, string playerName)
    {
        // Create an instance of SaveData
        SaveData data = new SaveData();

        // Assign the parameters to the instance variables 
        data.hiScore = currentScore;
        data.highScoreName = playerName;

        // Save the instance with its variables as a json string format
        string json = JsonUtility.ToJson(data);

        // Write a file with a persistent data path with the string in "json"
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        // Fetch the url of the json and save it in a path variable
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            // Save the information of the path in a json string, deserialize it and store it in an instance of SaveData
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Assign the DataHoler class variables to the values saved previously
            hiScore = data.hiScore;
            highScoreName = data.highScoreName;
        }
    }
}
