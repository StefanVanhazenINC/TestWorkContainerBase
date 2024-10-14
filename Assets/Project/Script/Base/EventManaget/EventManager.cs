using System;

public class EventManager
{
    public static event Action<InputDirection> OnInputDirectionSelected;
    public static void InputDirectionSelected(InputDirection direction)
    {
        OnInputDirectionSelected?.Invoke(direction);
    }

    public static event Action<IObject> OnObjectSelected;
    public static void CharacterSelected(IObject newObject)
    {
        OnObjectSelected?.Invoke(newObject);
    }

    public static event Action<IObject> OnObjectSetActive;
    public static void ObjectSetActive(IObject newObject)
    {
        OnObjectSetActive?.Invoke(newObject);
    }
}
