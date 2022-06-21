/* Program name: Introduction To Unity Scripting
   Project file name: DestroyTimer.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Time to destroy heart effect
   Description: Delays a Destroy call for specified amount of time
   Known Bugs:            
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{

    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
