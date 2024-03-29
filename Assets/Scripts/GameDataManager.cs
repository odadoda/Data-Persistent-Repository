using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;



public class GameDataManager : MonoBehaviour
{
    
    const string GAME_SAVE_FILE_NAME = "gameData.json";

    public string currentName;
    public int highScore;
    public string playerWithHighestScore;

    public static GameDataManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();

    }
    public void CollectName(string name)
    {

        currentName = name;
    }

    

    [System.Serializable]
    class GameData
    {
        public int highScore;
        public string playerWithHighestScore;
    }

    public void SaveHighScore(int newScore)
    {
        Debug.Log("saving highscore " + newScore + " > " + highScore);
        if (newScore > highScore)
        {
            GameData gameData = new GameData();
            gameData.highScore = newScore;
            gameData.playerWithHighestScore = currentName;

            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.persistentDataPath + "/" + GAME_SAVE_FILE_NAME, json);
        }
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/" + GAME_SAVE_FILE_NAME;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            highScore = gameData.highScore;
            playerWithHighestScore = gameData.playerWithHighestScore;

        } else
        {
            highScore = 0;
        }
    }

    public string GetHighScoreString()
    {
        return $"{playerWithHighestScore}: {highScore}";
    }

    public string GetCurrentName()
    {
        return currentName;
    }
}
