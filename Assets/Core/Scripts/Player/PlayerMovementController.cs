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
        transform.position += Vector3.forward * Time.deltaTime * movementData.MovementSpeed;
    }
    #endregion

}
