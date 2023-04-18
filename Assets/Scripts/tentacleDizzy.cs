using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacleDizzy : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnXPositionMin;
    public float spawnXPositionMax;
    public float spawnZPositionMin;
    public float spawnZPositionMax;
    public float spawnHeightOffset;
    public float objectSpeed;

    private GameObject spawnedObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            Invoke("SpawnObject", 1f);
        }
        
    }

    private void SpawnObject()
    {
        // Destroy the previously spawned object, if any
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Raycast downwards to detect the surface below the spawner
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Calculate the spawn position on top of the surface
            float spawnXPosition = Random.Range(spawnXPositionMin, spawnXPositionMax);
            float spawnZPosition = Random.Range(spawnZPositionMin, spawnZPositionMax);
            Vector3 spawnPosition = new Vector3(spawnXPosition, hit.point.y + spawnHeightOffset, spawnZPosition);

            // Spawn the object on top of the surface
            spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Set the object's velocity to a random direction on the x-z plane
            Vector3 velocity = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * objectSpeed;
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = velocity;
            }
        }
    }
}
