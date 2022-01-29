using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovementData movementData;

    #region Getters
    private PlayerInputController playerInput;
    public PlayerInputController PlayerInput { get { return playerInput == null ? playerInput = GetComponent<PlayerInputController>() : playerInput; } }
    #endregion

    private void Update()
    {
        HandleMovement();
    }

    #region Movement
    private void HandleMovement()
    {
        Vector3 movementVector = new Vector3(PlayerInput.InputX, 0, 1);

        transform.position += movementVector * Time.deltaTime * movementData.MovementSpeed;

        ClampMovement();
    }

    private void ClampMovement()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, movementData.ClampX.x, movementData.ClampX.y);

        transform.position = clampedPosition;
    }
    #endregion

}
