using UnityEngine;
using UnityEngine.InputSystem;

public class InputParser : MonoBehaviour
{
    [HideInInspector] public PlayerInput controls;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private AbilityManager abilityManager;
    [SerializeField] private PlayerLook playerLook;

    #region Handle PlayerInput
    public void Awake()
    {
        controls = new PlayerInput();
        controls.Player.Enable();
        abilityManager = GetComponent<AbilityManager>();
    }
    private void FixedUpdate()
    {
        Vector2 moveInput = controls.Player.movement.ReadValue<Vector2>();
        movement.PerformMovement(moveInput);

        controls.Player.Jump.performed += (InputAction.CallbackContext context) => movement.PerformJump();
        controls.Player.Skill1.performed += (InputAction.CallbackContext context) => abilityManager.ChangeSelectedAbility(0);
        controls.Player.Skill2.performed += (InputAction.CallbackContext context) => abilityManager.ChangeSelectedAbility(1);
        controls.Player.UseAbility.performed += (InputAction.CallbackContext context) => abilityManager.UseAbility();
        controls.Player.Turn.performed += ctx => playerLook.OnTurn(ctx.ReadValue<Vector2>());
    } 
    public void SetAbility(Ability ability)
    {
        Debug.Log("Added ability: "+ ability.name);
        abilityManager.AddAbility(ability);
    }
    #endregion
}