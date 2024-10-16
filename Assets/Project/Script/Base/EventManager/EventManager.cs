using System;

public class EventManager
{
    public static event Action OnLevelLoading;
    public static void LoadingLevel() 
    {
        OnLevelLoading?.Invoke();
    }

    public static event Action<InputDirection> OnInputDirectionSelected;
    public static void InputDirectionSelected(InputDirection direction)
    {
        OnInputDirectionSelected?.Invoke(direction);
    }

    public static event Action<IObject> OnObjectSelected;
    public static void ObjectSelected(IObject newObject)
    {
        OnObjectSelected?.Invoke(newObject);
    }

    public static event Action<IObject> OnObjectSetActive;
    public static void ObjectSetActive(IObject newObject)
    {
        OnObjectSetActive?.Invoke(newObject);
    }

    public static event Action<IObject> OnChangeActiveObject;
    public static void ChangeActiveObject(IObject newActiveObject)
    {
        OnChangeActiveObject?.Invoke(newActiveObject);
    }
}
