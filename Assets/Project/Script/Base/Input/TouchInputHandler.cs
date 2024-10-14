using UnityEngine;

public class TouchInputHandler : IInputHandler
{
    public bool GetAction()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public Vector2 GetMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.deltaPosition / touch.deltaTime;
        }
        return Vector2.zero;
    }

    public InputDirection GetDirection()
    {
        Vector2 movement = GetMovement();
        if (movement.magnitude > 1)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                return movement.x > 0 ? InputDirection.Right : InputDirection.Left;
            }
            else
            {
                return movement.y > 0 ? InputDirection.Up : InputDirection.Down;
            }
        }
        return InputDirection.None;
    }
}
