using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string NickName;
    public int BestScoreInt = 0; //Set default to avoid bug
    public string BestScoreNick = "None"; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadHightScore();
    }
    //
    [System.Serializable]
    class SaveData
    {
        public string Nick;
        public int Score;
    }
    //Save hight score to file
    public void SaveHightScore()
    {
        SaveData data = new SaveData();
        data.Nick = BestScoreNick;
        data.Score = BestScoreInt;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    //Load hight score from file
    public void LoadHightScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreInt = data.Score;
            BestScoreNick = data.Nick;
        }
    }

}
