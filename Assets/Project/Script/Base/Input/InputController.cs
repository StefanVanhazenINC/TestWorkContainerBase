using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float resetTimerValue = 0.1f;
    private float inputTimer;
    private InputDirection lastDirection = InputDirection.None;

    private IInputHandler inputHandler;


    private void Start()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        inputHandler = new KeyboardMouseInputHandler();
#elif UNITY_IOS || UNITY_ANDROID
        inputHandler = new TouchInputHandler();
#endif
        inputTimer = resetTimerValue;
    }

    private void Update()
    {
        InputDirection currentDirection = inputHandler.GetDirection();

        if (currentDirection == InputDirection.None)
        {
            inputTimer = resetTimerValue;
            return;
        }

        if (lastDirection != InputDirection.None && currentDirection != lastDirection)
        {
            lastDirection = currentDirection;
            inputTimer = resetTimerValue;
            return;
        }

        inputTimer -= Time.deltaTime;
        if (inputTimer <= 0)
        {
            EventManager.InputDirectionSelected(currentDirection);
            inputTimer = resetTimerValue;
        }

        lastDirection = currentDirection;
    }
}
