/* Program name: Introduction To Unity Scripting
   Project file name: ChangeColourOnMouseOver.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Hover behaviour on title screen
   Description: changes colour of buttons on title screen when mouse is hovering over them
   Known Bugs:           
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model; 
    public Color normalColor; 
    public Color hoverColor; 

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        model.material.color = normalColor;
    }

}
