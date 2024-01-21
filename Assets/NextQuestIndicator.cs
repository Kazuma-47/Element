using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class NextQuestIndicator : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCompleteQuest;
    public bool Active;
    private bool inRange;
    [HideInInspector] public PlayerInput controls;

    private void Start()
    {
        controls = PlayerSpawner.playerInstance.GetComponent<InputParser>().controls;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            CheckAndAddListener();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        RemoveListener();
    }

    private void CheckAndAddListener()
    {
        if (Active && inRange)
        {
            controls.Player.Interact.performed += InteractPerformed;
        }
    }

    private void RemoveListener()
    {
        controls.Player.Interact.performed -= InteractPerformed;
    }

    private void InteractPerformed(InputAction.CallbackContext ctx)
    {
        OnCompleteQuest.Invoke();
        RemoveListener();
    }
}
