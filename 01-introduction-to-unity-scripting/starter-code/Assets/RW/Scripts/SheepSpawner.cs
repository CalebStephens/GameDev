using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{

    public bool canSpawn = true; 

    public GameObject sheepPrefab; 
    public List<Transform> sheepSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns; 
    public float increment;
    [HideInInspector]
    public float sheepCount;
    [HideInInspector]
    public float speedUp;

    private List<GameObject> sheepList = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; 
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); 
        sheepList.Add(sheep); 
        sheep.GetComponent<Sheep>().runSpeed += speedUp;
        sheep.GetComponent<Sheep>().SetSpawner(this); 
        sheepCount += 1;
        if(sheepCount % 5 == 0){ 
            speedUp += 1f;
            Debug.Log(speedUp);
        }
        
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
            /* Everytime a sheep is spawned time between spawns is shortened to what is set in unity
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
