using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Configuration")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("GrounCheck Configuration")]
    [SerializeField] private float rayCastLength = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 originOffSet;

    private float checkCooldown = 0.2f; 
    private float timeSinceLastCheck = 0f;

    private Rigidbody playerRigidbody;
    private Vector3 origin;

    [SerializeField]
    private bool airborne = false;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    public void PerformMovement(Vector2 playerinput)
    {
        Vector3 movement = new Vector3(playerinput.x, 0f, playerinput.y) * movementSpeed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
    }
    public void PerformJump()
    {
        if (!airborne)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            airborne = true;
        }
    }
    private void FixedUpdate()
    {
        //A timer to stop the check from happening instantly
        origin = gameObject.transform.position + originOffSet;
        timeSinceLastCheck += Time.fixedDeltaTime;
        if (timeSinceLastCheck >= checkCooldown)
        {
            timeSinceLastCheck = 0f;
            if (airborne == true)
                GroundCheck();
        }
    }
    private void GroundCheck()
    {
        if (Physics.Raycast(origin, Vector3.down, rayCastLength, groundLayer))
            airborne = false;
        else
            airborne = true;
        Debug.DrawRay(origin, Vector3.down * rayCastLength, airborne ? Color.red : Color.green);
    }

   


   

}
