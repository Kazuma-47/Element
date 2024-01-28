using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Player camera configurations")]
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] float minViewDistance = 15f;

    private float Rotationx;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnTurn(Vector2 input)
    {
        Rotationx -= input.y;
        Rotationx = Mathf.Clamp(Rotationx, -90f, minViewDistance);

        transform.localRotation = Quaternion.Euler(Rotationx, input.y, 0f);
        playerBody.Rotate(Vector3.up * input.x);
    }


}
