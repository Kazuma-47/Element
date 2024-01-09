using UnityEngine;
using UnityEngine.InputSystem;

public class InputParser : MonoBehaviour
{
    private PlayerInput controls;
    private PlayerMovement movement;

    #region Handle PlayerInput
    public void Awake()
    {
        controls = new PlayerInput();
        controls.Player.Enable();
        movement = GetComponent<PlayerMovement>();
    }
    private void FixedUpdate()
    {
        Vector2 moveInput = controls.Player.movement.ReadValue<Vector2>();
        movement.PerformMovement(moveInput);

        controls.Player.Jump.performed += (InputAction.CallbackContext context) => movement.PerformJump();
    }
    #endregion
}