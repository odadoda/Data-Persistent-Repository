using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreField;
    private void Start()
    {
        highscoreField.text = GameDataManager.instance.GetHighScoreString();
    }

    private void Update()
    {
        highscoreField.text = GameDataManager.instance.GetHighScoreString();
    }
}
