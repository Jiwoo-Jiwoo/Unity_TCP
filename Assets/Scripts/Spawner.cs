using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Transform startingPoint;
    [SerializeField]
    GameObject playerPrefab;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CreatePlayer()
    {
        Instantiate(playerPrefab, startingPoint.position, startingPoint.rotation);
        Instantiate(playerPrefab, startingPoint.position, startingPoint.rotation);
    }
}
