using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    const string GAME_SCENE_NAME = "main";
    [SerializeField] TMP_Text highscoreField;
    [SerializeField] TMP_InputField nameInput;

    private void Start()
    {
        highscoreField.text = GameDataManager.instance.GetHighScoreString();
        nameInput.text = GameDataManager.instance.GetCurrentName();
    }

    private void Update()
    {
        highscoreField.text = GameDataManager.instance.GetHighScoreString();
    }

    public void StartGame()
    {
        Debug.Log("Start game please");
        SceneManager.LoadScene(GAME_SCENE_NAME);

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
