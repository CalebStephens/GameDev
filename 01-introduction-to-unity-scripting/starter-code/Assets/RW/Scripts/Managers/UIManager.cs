/* Program name: Introduction To Unity Scripting
   Project file name: UIManager.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Updates UI
   Description: Changes the UI text when needed
   Known Bugs:           
   Additional Features: Highscore on UI
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance; 

    public Text sheepSavedText; 
    public Text sheepDroppedText; 
    public GameObject gameOverWindow; 
    public Text highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved() 
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() 
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    //update UI to display current highscore
    public void UpdateHighScore()
    {
        highScoreText.text = Score.keepScore.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
