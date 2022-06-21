/* Program name: Maze Generation
   Project file name: GameController.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: creates everything needed for the gameplay
   Description: instantiates player, monster and trigger for when player reaches treasure
   Known Bugs:           
   Additional Features: 
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MazeConstructor))]           

public class GameController : MonoBehaviour
{
    private MazeConstructor constructor;
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    public GameObject playerPrefab;
    public GameObject monsterPrefab;
    private AIController aIController;


    void Awake()
    {
        constructor = GetComponent<MazeConstructor>();
        aIController = GetComponent<AIController>(); 
    }
    
    void Start()
    {
        constructor.GenerateNewMaze(rows, cols, OnTreasureTrigger);
        
        aIController.Graph = constructor.graph;
        aIController.Player = CreatePlayer();
        aIController.Monster = CreateMonster(); 
        aIController.HallWidth = constructor.hallWidth;         
        aIController.StartAI();
    }

    void Update()
    {
        
        if(Input.GetKeyDown("f"))
        {
            Hint();
            
        }
    }
    
    public void Hint(){
        int playerCol = (int)Mathf.Round(aIController.Player.transform.position.x / constructor.hallWidth);
        int playerRow = (int)Mathf.Round(aIController.Player.transform.position.z / constructor.hallWidth);

        int treasureCol = constructor.goalCol;
        int treasureRow = constructor.goalRow;

        List<Node> treasurePath = aIController.FindPath(playerRow, playerCol, treasureRow, treasureCol);

        foreach(Node node in treasurePath)
        {
            GameObject orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            orb.transform.position = new Vector3(node.y * constructor.hallWidth, 1, node.x * constructor.hallWidth);
            orb.GetComponent<SphereCollider>().enabled = false;
            orb.tag = "hint";
        }
    }

    private GameObject CreatePlayer()
    {
        Vector3 playerStartPosition = new Vector3(constructor.hallWidth, 1, constructor.hallWidth);  
        GameObject player = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player.tag = "Generated";

        return player;
    }

    private GameObject CreateMonster()
    {
        Vector3 monsterPosition = new Vector3(constructor.goalCol * constructor.hallWidth, 0f, constructor.goalRow * constructor.hallWidth);
        GameObject monster = Instantiate(monsterPrefab, monsterPosition, Quaternion.identity);
        monster.tag = "Generated";  
        return monster;  
    }

    private void OnTreasureTrigger(GameObject trigger, GameObject other)
    { 
        Debug.Log("You Won!");
        aIController.StopAI();
    }
}