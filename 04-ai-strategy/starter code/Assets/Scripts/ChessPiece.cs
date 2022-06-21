﻿/* Program name: AI Stratergy
   Project file name: ChessPiece.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Movement for each piece
   Description: finds what type the piece being moved is and where it can move to
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum PieceType
    {
        NONE = -1,
        PAWN,
        BISHOP,
        KNIGHT,
        ROOK,
        QUEEN,
        KING,
    };    

    [SerializeField] private PieceType type = PieceType.NONE;
    [SerializeField] private PlayerTeam team = PlayerTeam.NONE;

    public PieceType Type
    {
        get{ return type; }
    }
    public PlayerTeam Team
    {
        get{ return team; }
    }
    public Vector2 chessPosition;
    private Vector2 moveTo;

    private bool hasMoved = false;
    public bool HasMoved
    {
        get{ return hasMoved; }
        set{ hasMoved = value; }
    }
        
    void Start()
    {
        transform.position = chessPosition;
        moveTo = transform.position;
    }

    void Update()
    {
        transform.position = moveTo;
    }

    public void MovePiece(Vector2 position)
    {
        moveTo = position;
    }
}
