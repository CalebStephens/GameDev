/* Program name: Maze Generation
   Project file name: Node.CS
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Representation of our maze data as nodes
   Description: Figure out if the node is walkable or not for player and monster movement
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x;
    public int y;
    
    public int gCost;
    public int hCost;
    public int fCost;      

    public Node cameFromNode;

    public bool isWalkable;

    public Node(int x, int y, bool isWalkable)
    {
        this.x = x;
        this.y = y;
        hCost = 0;
        this.isWalkable = isWalkable;
    }
    
    public void CalculateFCost(){
        fCost = gCost + hCost;
    } 
}