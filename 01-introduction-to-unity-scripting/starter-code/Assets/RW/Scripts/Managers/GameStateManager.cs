/* Program name: Introduction To Unity Scripting
   Project file name: GameStateManager.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Acts as the game controller
   Description: controlls the UI and when the game is over
   Known Bugs:           
   Additional Features: HighScore saving
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved; 

    [HideInInspector]
    public int sheepDropped; 

    public int sheepDroppedBeforeGameOver; 
    public SheepSpawner sheepSpawner; 

    void Awake()
    {
        Instance = this;
        UIManager.Instance.UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
        
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep();
        /* checks if sheepSaved in current game is higher then previous highscore, 
        if so then update highscore */
        if(sheepSaved > Score.keepScore){
            Score.keepScore = sheepSaved;
            UIManager.Instance.UpdateHighScore();
        }
        UIManager.Instance.ShowGameOverWindow(); 
    }

    public void DroppedSheep()
    {
        sheepDropped++; 
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }
}
