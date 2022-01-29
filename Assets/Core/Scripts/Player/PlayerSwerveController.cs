using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwerveController : MonoBehaviour
{
    [SerializeField] private PlayerMovementData movementData;

    #region Getters
    private PlayerInputController playerInput;
    public PlayerInputController PlayerInput { get { return playerInput == null ? playerInput = GetComponentInParent<PlayerInputController>() : playerInput; } }
    #endregion

    private void Update()
    {
        HandleSwerve();
    }

    private void HandleSwerve()
    {
        transform.position += new Vector3(PlayerInput.InputX * Time.deltaTime * movementData.SwerveSpeed, 0, 0);

        ClampSwerve();
    }

    private void ClampSwerve()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, movementData.ClampX.x, movementData.ClampX.y);

        transform.position = clampedPosition;
    }
}
