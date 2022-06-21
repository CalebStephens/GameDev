/* Program name: Introduction To Unity Scripting
   Project file name: QuitButton.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Behaviour for Quit button
   Description: when quit button is clicked, quit the application
   Known Bugs:           
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {
       Application.Quit();
       
    }
}
