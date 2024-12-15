using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public GameObject doorPrefab;
    public string doorSpawnPointTag = "DoorSpawnPoint";
    public float timeToCollectKey = 5f;
    private float timeInTrigger = 0f;
    private bool doorSpawned = false;

    private bool playerInTrigger = false; 
    private Transform doorSpawnPoint;

    private void Start()
    {
        // Find the door spawn point by its tag
        GameObject spawnPointObject = GameObject.FindWithTag(doorSpawnPointTag);
        if (spawnPointObject != null)
        {
            doorSpawnPoint = spawnPointObject.transform;
        }
        else
        {
            UnityEngine.Debug.LogError("No GameObject with tag '" + doorSpawnPointTag + "' found!");
        }
    }

    private void Update()
    {
        if (playerInTrigger && !doorSpawned)
        {
            timeInTrigger += Time.deltaTime; 
            UnityEngine.Debug.Log("Time in trigger: " + timeInTrigger);

            if (timeInTrigger >= timeToCollectKey)
            {
                UnityEngine.Debug.Log("Spawning door...");
                SpawnDoor();
                doorSpawned = true; // Prevent further spawning of the door
            }
        }

        if (doorSpawned)
        {
            Destroy(gameObject); // Destroy the key
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player entered trigger zone!");
            playerInTrigger = true; 
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player left the trigger zone.");
            playerInTrigger = false; 
            timeInTrigger = 0f;      
        }
    }

    // Method to spawn the door
    private void SpawnDoor()
    {
        if (doorPrefab != null && doorSpawnPoint != null)
        {
            UnityEngine.Debug.Log("Spawning door...");
            Instantiate(doorPrefab, doorSpawnPoint.position, Quaternion.identity);
            UnityEngine.Debug.Log("Door spawned successfully!");
        }
        else
        {
            if (doorPrefab == null)
                UnityEngine.Debug.LogError("Door Prefab is not assigned in the Inspector!");
            if (doorSpawnPoint == null)
                UnityEngine.Debug.LogError("Door Spawn Point was not found at runtime!");
        }
    }
}




