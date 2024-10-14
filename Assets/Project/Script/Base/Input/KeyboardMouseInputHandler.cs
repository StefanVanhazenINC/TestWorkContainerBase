using UnityEngine;

public class KeyboardMouseInputHandler : IInputHandler
{
    public bool GetAction()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public Vector2 GetMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }

    public InputDirection GetDirection()
    {
        Vector2 movement = GetMovement();
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            return movement.x > 0 ? InputDirection.Right : InputDirection.Left;
        }
        else if (Mathf.Abs(movement.y) > 0)
        {
            return movement.y > 0 ? InputDirection.Up : InputDirection.Down;
        }
        return InputDirection.None;
    }
}
