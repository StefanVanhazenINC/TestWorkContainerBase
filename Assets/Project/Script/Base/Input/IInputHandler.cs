using UnityEngine;

public interface IInputHandler
{
    bool GetAction();
    Vector2 GetMovement();
    InputDirection GetDirection();
}

public enum InputDirection
{
    None,
    Up,
    Down,
    Left,
    Right
}