using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelQuestHandler : MonoBehaviour
{
    private PlayerUiHandler playerObjective;
    [SerializeField] private string LevelName;
    [SerializeField] private string LevelObjective;

    void Start()
    {
        playerObjective = PlayerSpawner.playerInstance.GetComponent<PlayerUiHandler>();
        playerObjective.SetMissionName(LevelName);
        playerObjective.setObjective(LevelObjective);
    }

}
