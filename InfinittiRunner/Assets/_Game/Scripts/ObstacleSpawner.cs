using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    [SerializeField]
    private Transform spawnPoint;
    void Start()
    {
        SpawnRandomObstacle();
    }

    // Update is called once per frame
    void SpawnRandomObstacle()
    {
        int randomNumber = Random.Range(1, 11);

        if(randomNumber >= 5)
        {
            GameObject tempPrefab = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            tempPrefab.transform.parent = spawnPoint.transform;
        }
    }
}
