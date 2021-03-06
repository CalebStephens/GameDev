/* Program name: Introduction To Unity Scripting
   Project file name: Sheep.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Instatiate each sheep and its characteristics
   Description: Each sheep spawned will be given characteristics allowing it to act appropriately.
   Known Bugs:            
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; 
    public float gotHayDestroyDelay; 
    private bool hitByHay; 
    public float dropDestroyDelay; 
    public bool dropped;
    private Collider myCollider; 
    private Rigidbody myRigidbody; 
    private SheepSpawner sheepSpawner;
    public float heartOffset; 
    public GameObject heartPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0;

        Destroy(gameObject, gotHayDestroyDelay);
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0; 
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject); 
            HitByHay(); 
        }else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false; 
        myCollider.isTrigger = false; 
        Destroy(gameObject, dropDestroyDelay); 
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.DroppedSheep();
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;  
    }
}
