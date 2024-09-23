using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public Transform[] spawnPoints;
    private int[] currentPositions;
    public KeyCode testkey; 

    void Start()
    {
        currentPositions = new int[itemPrefabs.Length];
        RandomizeItems();
    }

    public void RandomizeItems()
    {
        // Move each orb to a new random spawn point
        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            int newPosition = Random.Range(0, spawnPoints.Length);

            while (currentPositions.Contains(newPosition))
            {
                newPosition = Random.Range(0, spawnPoints.Length);
            }

            Transform spawnPoint = spawnPoints[newPosition];
            itemPrefabs[i].transform.position = spawnPoint.position;
            currentPositions[i] = newPosition;
        }
    }
}
