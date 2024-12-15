using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChestKeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;         // The key prefab to spawn
    public Transform keySpawnPoint;     
    private float timeInTrigger = 0f;   
    public float timeToSpawnKey = 5f;   
    private bool keySpawned = false;

    private void Start()
    {
        UnityEngine.Debug.Log("ChestKeySpawner script is running!");
    }

    private void OnCollisionStay(Collision collision)
    {
        UnityEngine.Debug.Log("Collision detected with: " + collision.collider.name);
    }



    private void OnTriggerStay(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player is in trigger zone!");
            timeInTrigger += Time.deltaTime;

            if (timeInTrigger >= timeToSpawnKey && !keySpawned)
            {
                UnityEngine.Debug.Log("Spawning key...");
                SpawnKey();
                keySpawned = true;
            }
        }
        else
        {
            UnityEngine.Debug.Log("Something else is in the trigger zone: " + other.name);
        }
    }

    private void OnTriggerExit(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player left the trigger zone.");
            timeInTrigger = 0f;
        }
    }



    private void SpawnKey()
    {
        
        UnityEngine.Debug.Log("SpawnKey method called!");

        if (keyPrefab != null && keySpawnPoint != null)
        {
            Instantiate(keyPrefab, keySpawnPoint.position, Quaternion.identity);
            UnityEngine.Debug.Log("Key spawned successfully at: " + keySpawnPoint.position);
        }
        else
        {
            UnityEngine.Debug.LogError("Key Prefab or Spawn Point is not assigned!");
        }
    }

}//

