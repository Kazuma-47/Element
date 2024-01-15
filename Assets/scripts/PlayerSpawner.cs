using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public static GameObject playerInstance;

    private void Start()
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            playerInstance = Instantiate(playerPrefab);
        }
    }
}
