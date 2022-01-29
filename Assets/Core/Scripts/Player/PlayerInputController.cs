using UnityEngine;


public class PlayerInputController : MonoBehaviour
{
    private const float INPUT_LIMIT = 10;

    private float inputX;
    public float InputX { get { return inputX; } }

    private Vector2 lastInputPosition;


    private void Update()
    {
        GetSwerveInput();
    }

    private void GetSwerveInput()
    {
        if (Input.GetMouseButtonDown(0))
            lastInputPosition = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            inputX = Mathf.Clamp(Input.mousePosition.x - lastInputPosition.x, -INPUT_LIMIT, INPUT_LIMIT);

            lastInputPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
            inputX = 0;
    }
}
