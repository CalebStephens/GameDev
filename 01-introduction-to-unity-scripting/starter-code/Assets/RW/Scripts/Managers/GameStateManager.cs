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
    public int highScore; 

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
        if(sheepSaved > Score.keepScore){
            highScore = sheepSaved;
            Score.keepScore = highScore;
            UIManager.Instance.UpdateHighScore();
        }
        UIManager.Instance.ShowGameOverWindow(); 
    }

    public void HighScore()
    {
        
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
