/* Program name: Game Mechanics
   Project file name: PlaceMonster.cs
   Author: Caleb Stephens
   Date: 21/6/22
   Language: C#
   Platform: Mac OS
   Purpose: Allows user to place and upgrade monster to defend base
   Description: when an openspot is clicked places monster but also checks if moster is placed then upgrade current monster, and if user has enough coins.
   Known Bugs:           
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{

    public GameObject monsterPrefab;
    private GameObject monster;
    private GameManagerBehaviour gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private bool CanPlaceMonster()
    {
        int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        return monster == null && gameManager.Gold >= cost;
    }

    private bool CanUpgradeMonster()
    {
        if (monster != null)
        {
            MonsterData monsterData = monster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
            return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }

    void OnMouseUp()
    {
        if (CanPlaceMonster())
        {
            monster = (GameObject)Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }else if (CanUpgradeMonster())
        {
            monster.GetComponent<MonsterData>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }
    }
}
