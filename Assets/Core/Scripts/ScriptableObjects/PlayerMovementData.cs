using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/Player/MovementData")]
public class PlayerMovementData : ScriptableObject
{
    public float MovementSpeed;
    public float SwerveSpeed;
    public Vector2 ClampX;
}
