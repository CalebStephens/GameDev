/* Program name: Introduction To Unity Scripting
   Project file name: DestroyOnTrigger.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Destroys Game objects
   Description: If two game objects collide destroys the object that should dissapear
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(tagFilter)) 
        {
            Destroy(gameObject); 
        }
    }

}
