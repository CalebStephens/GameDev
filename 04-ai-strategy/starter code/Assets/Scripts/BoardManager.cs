/* Program name: AI Stratergy
   Project file name: BoardManager.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Create board for chess game
   Description: On awake create instance of board setting it up for game
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private static BoardManager instance;
    public static BoardManager Instance
    {
        get{ return instance; }
    }
    private void Awake()
    {
        if (instance == null)        
            instance = this;        
        else if (instance != this)        
            Destroy(this);    
    }  

    private TileData[,] board = new TileData[8, 8];

    public void SetupBoard()
    {
        for (int y = 0; y < 8; y++)        
            for (int x = 0; x < 8; x++)            
                board[x, y] = new TileData(x, y);                    
    }

    public TileData GetTileFromBoard(Vector2 tile)
    {
        return board[(int)tile.x, (int)tile.y];
    }
}
