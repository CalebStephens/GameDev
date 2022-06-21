/* Program name: Introduction To Unity Scripting
   Project file name: TweenScale.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Add an animation to a prefab
   Description: Will 'tween' (or animate) between two sizes, essentially scaling down the heart over time
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{

    public float targetScale; 
    public float timeToReachTarget; 
    private float startScale;  
    private float percentScaled; 
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) 
        {
            percentScaled += Time.deltaTime / timeToReachTarget; 
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); 
            transform.localScale = new Vector3(scale, scale, scale); 
        }
    }
}
