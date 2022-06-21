/* Program name: Game Mechanics
   Project file name: BulletBehaviour.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Controls spawning enemy and what type of enemy
   Description: finds what wave the player is on and what type of enemy needs to spawn along with how many enemies to spawn
   Known Bugs:           
   Additional Features: Spawn a mix of harder and normal enemies at round 3
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
  public GameObject enemyPrefab;
  public float spawnInterval = 2;
  public int maxEnemies = 20;
}


public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    public List<GameObject> enemiesList;

    private GameManagerBehaviour gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();

        //creates a list with all the enemy prefabs in the resources folder "Enemy"
        enemiesList = new List<GameObject>(Resources.LoadAll<GameObject>("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || (enemiesSpawned != 0 && timeInterval > spawnInterval)) && 
    (enemiesSpawned < waves[currentWave].maxEnemies))
            {
                //Spawns second type of enemy at the 3rd wave 
                if(currentWave < 2){
                    lastSpawnTime = Time.time;
                    GameObject newEnemy = (GameObject)Instantiate(enemiesList[0]);
                    newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                    enemiesSpawned++;
                }else{
                    //new random number each time before an enemy is spawned to determine which enemy is spawned. Works if someone adds a new enemy
                    randNum = Random.Range(0,enemiesList.Count);
                    lastSpawnTime = Time.time;
                    GameObject newEnemy = (GameObject)Instantiate(enemiesList[randNum]);
                    newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                    enemiesSpawned++;
                }
            }
            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }
}
