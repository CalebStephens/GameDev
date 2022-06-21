/* Program name: Introduction To Unity Scripting
   Project file name: HayMachineSwitcher.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Allow user to change colour of their hay machine
   Description: uses an enum called HayMachineColour, then uses an index on the users click to find which colour they have choosen.
   Known Bugs:            
   Additional Features: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;

    private int selectedIndex;

    public void OnPointerClick(PointerEventData eventData) 
    {
        selectedIndex++; 
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length; 

        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex; 

        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
            break;
        }
    }
}
