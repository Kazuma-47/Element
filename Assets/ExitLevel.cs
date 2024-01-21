using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneSwitcher.Instance.SwitchScene("Level1");
    }
}

