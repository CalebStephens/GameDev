/* Program name: Introduction To Unity Scripting
   Project file name: SheepSpawner.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Spawns each sheep
   Description: Each sheep spawned will be given characteristics allowing it to act appropriately.
   Known Bugs:            
   Additional Features: Sheep run will increase run speed every 5 sheep.
                        Sheep spawn time gets faster gradually over time until time between spawns reaches two seconds.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{

    public bool canSpawn = true; 

    public GameObject sheepPrefab; 
    public List<Transform> sheepSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns; 
    //Variable in which is spawn time is decreased by
    public float increment;
    //Counter for each sheep spawned
    [HideInInspector]
    public float sheepCount;
    //Variable increases over time to allow sheep to run faster
    [HideInInspector]
    public float speedUp;

    private List<GameObject> sheepList = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; 
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); 
        sheepList.Add(sheep); 
        //Add speedUp to runspeed before spawning sheep.
        sheep.GetComponent<Sheep>().runSpeed += speedUp;
        sheep.GetComponent<Sheep>().SetSpawner(this); 
        //Evertyime a sheep is spawned increaase sheepCount by 1, after every 5th sheep increase speedUp
        // which is then added to the original run speed.
        sheepCount += 1;
        if(sheepCount % 5 == 0){ 
            speedUp += 1f;
        }
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
            /* Everytime a sheep is spawned, time between spawns is shortened to what is set in unity
                until timeBetween spawns is equal to 2 seconds */
            if(timeBetweenSpawns > 2){
                timeBetweenSpawns -= increment;
            }
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }
}
