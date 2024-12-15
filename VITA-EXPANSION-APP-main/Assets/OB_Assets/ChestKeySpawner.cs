using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;         
    public Transform keySpawnPoint;
    private float timeInTrigger = 0f;
    public float timeToSpawnKey = 5f;
    private bool keySpawned = false;
    private bool playerInTrigger = false; // Flag to track if the player is in the trigger

    private void Start()
    {
        UnityEngine.Debug.Log("ChestKeySpawner script is running!");
    }

    private void Update()
    {
        
        if (playerInTrigger && !keySpawned)
        {
            timeInTrigger += Time.deltaTime;
            UnityEngine.Debug.Log("Time in trigger: " + timeInTrigger);

            if (timeInTrigger >= timeToSpawnKey)
            {
                UnityEngine.Debug.Log("Spawning key...");
                SpawnKey();
                keySpawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player entered trigger zone!");
            playerInTrigger = true; // Set flag to true
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player left the trigger zone.");
            playerInTrigger = false; // Reset flag
            timeInTrigger = 0f;      // Reset timer
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
            if (keyPrefab == null)
                UnityEngine.Debug.LogError("Key Prefab is not assigned in the Inspector!");
            if (keySpawnPoint == null)
                UnityEngine.Debug.LogError("Key Spawn Point is not assigned in the Inspector!");
        }
    }
}



