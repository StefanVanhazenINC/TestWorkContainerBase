using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSelectors<Manager,Data> : MonoBehaviour where Data :  class, IObject where Manager : ObjectManager<Data>
{
    protected Manager _manager;
    protected int _currentIndex = 0;
    protected virtual void OnEnable()
    {
        EventManager.OnObjectSelected += SetCurrentObject;
        EventManager.OnInputDirectionSelected += GetInput;
    }

    protected virtual void OnDisable()
    {
        EventManager.OnObjectSelected -= SetCurrentObject;
        EventManager.OnInputDirectionSelected -= GetInput;
    }
    public void Construct(Manager manager) 
    {
        _manager = manager;
    }
    private void SelectCharacter(int index)
    {
        EventManager.ObjectSelected(_manager.GetObject(index));
    }
    public void SetCurrentObject(IObject newObject) 
    {
        Data newConcretObject;
        try
        {
            newConcretObject = (Data)newObject;
        }
        catch (InvalidCastException)
        {
            Debug.LogError($"The provided object cannot be cast to Config.");
            return;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
            return;
        }

        if (_manager.GetObject(_currentIndex).Id == newConcretObject.Id)
        {
            EventManager.ObjectSetActive(_manager.GetObject(_currentIndex));
            return;
        }
        _currentIndex = _manager.SelectObject(newConcretObject.Id);

    }

    private void GetInput(InputDirection direction)
    {
        switch (direction)
        {
            case InputDirection.Left:
                MoveSelection(-1);
                break;
            case InputDirection.Right:
                MoveSelection(1);
                break;
            case InputDirection.Up:
                EventManager.ObjectSetActive(_manager.GetObject(_currentIndex));
                break;
        }
    }
    private void MoveSelection(int step)
    {
        int index = _currentIndex + step;

        if (index < 0)
        {
            index = _manager.GetLenght() - 1;
        }
        else
        {
            if (index >= _manager.GetLenght())
            {
                index = 0;
            }
        }

        SelectCharacter(index);
    }

}
