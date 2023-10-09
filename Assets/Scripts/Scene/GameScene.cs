using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    void Start()
    {
        GameObject player = Instantiate(playerPrefab);
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.Possessed = true;

    }

    void Update()
    {
        
    }
}
