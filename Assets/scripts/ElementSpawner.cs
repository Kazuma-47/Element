using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ElementSpawner : MonoBehaviour
{
    [SerializeField] private Elements Element;
    [SerializeField] private List<Ability> Abilities = new List<Ability>();
    public UnityEvent<Ability> GiveAbility;

    public Ability ability;
    public  bool OnPlayerInRange;

    private GameObject playerInstance;
    private PlayerInput controls;
    private InputParser inputParser;
    

    //configure Spawner
    private void Start()
    {
        playerInstance = PlayerSpawner.playerInstance;
        inputParser = playerInstance.GetComponent<InputParser>();
        controls = inputParser.controls;
        GiveAbility.AddListener(delegate { inputParser.SetAbility(ability); });
        for (int i = 0; i < Abilities.Count; i++)
        {
            if (Element == Abilities[i].Element)
            {
                ability = Abilities[i];
                return;
            }
            else
            {
                Debug.Log("could not find the given ability");
            }    
        }
        
    }
    public void UseSpawner()
    {
        if (OnPlayerInRange)
        {
            Debug.Log("button pressed");
             GiveAbility.Invoke(ability);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnPlayerInRange = true;
            controls.Player.Interact.performed += ctx => UseSpawner();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerInRange = false;
        }
    }
}
