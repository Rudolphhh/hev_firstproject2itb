using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    public GameObject MenemyPrefab;
    [SerializeField]
    public GameObject RenemyPrefab;


    public Transform player;
    
    private Vector3 localPlayerPosition;
    
    private Vector3 invertedPlayerPosition;

    public float playerQuadrant = 0;
    void Start()
    {
        
        
        InvokeRepeating("SpawnEnemyOppositeQuadrant", 6f, 6f);

    }

    private void Update()
    {
        localPlayerPosition = transform.InverseTransformPoint(player.position);


        invertedPlayerPosition = new Vector3(-localPlayerPosition.x, 0f, -localPlayerPosition.z);
    }

    void SpawnEnemyOppositeQuadrant()
    {
        
        

        
        

        if (localPlayerPosition.x >= 0)
        {
            if (localPlayerPosition.z >= 0)
            {
                playerQuadrant = 1;
            }
            else
            {
                playerQuadrant = 4;
            }
        }
        else
        {
            if (localPlayerPosition.z >= 0)
            {
                playerQuadrant = 2;
            }
            else
            {
                playerQuadrant = 3;
            }
        }

        
        Vector3 spawnPosition = invertedPlayerPosition;

        
        Instantiate(RenemyPrefab, spawnPosition, Quaternion.identity);
        Instantiate(MenemyPrefab, spawnPosition, Quaternion.identity);
    }
}
