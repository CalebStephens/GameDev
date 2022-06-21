/* Program name: Game Mechanics
   Project file name: BulletBehaviour.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Health bar for enemys
   Description: displays enemy health above each individual enemy
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
