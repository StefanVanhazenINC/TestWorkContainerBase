using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float resetTimerValue = 0.1f;
    private float _inputTimer;
    private InputDirection _lastDirection = InputDirection.None;

    private IInputHandler _inputHandler;


    private void Start()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        _inputHandler = new KeyboardMouseInputHandler();
#elif UNITY_IOS || UNITY_ANDROID
        inputHandler = new TouchInputHandler();
#endif
        _inputTimer = resetTimerValue;
    }

    private void Update()
    {
        InputDirection currentDirection = _inputHandler.GetDirection();

        if (currentDirection == InputDirection.None)
        {
            _inputTimer = resetTimerValue;
            return;
        }

        if (_lastDirection != InputDirection.None && currentDirection != _lastDirection)
        {
            _lastDirection = currentDirection;
            _inputTimer = resetTimerValue;
            return;
        }

        _inputTimer -= Time.deltaTime;
        if (_inputTimer <= 0)
        {
            EventManager.InputDirectionSelected(currentDirection);
            _inputTimer = resetTimerValue;
        }

        _lastDirection = currentDirection;
    }
}
