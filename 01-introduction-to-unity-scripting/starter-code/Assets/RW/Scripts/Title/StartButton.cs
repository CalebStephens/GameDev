/* Program name: Introduction To Unity Scripting
   Project file name: StartButton.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Behaviour for start button
   Description: when start button is called load scene "Game"
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData) 
    {
        SceneManager.LoadScene("Game"); 
    }

}
