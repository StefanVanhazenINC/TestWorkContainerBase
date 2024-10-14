using System;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private DataPack dataPackCharacters;
    private CharacterConfig[] _characters;
    private int _currentIndex = 0;

    private void OnEnable()
    {
        EventManager.OnObjectSelected += SetCurrentCharacter;
        EventManager.OnInputDirectionSelected += GetInput;
    }

    private void OnDisable()
    {
        EventManager.OnObjectSelected -= SetCurrentCharacter;
        EventManager.OnInputDirectionSelected -= GetInput;
    }

    private void SetCurrentCharacter(IObject newObject)
    {
        CharacterConfig newCharacter;

        try
        {
            newCharacter = (CharacterConfig)newObject;
        }
        catch (InvalidCastException)
        {
            Debug.LogError($"The provided object cannot be cast to CharacterConfig.");
            return;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
            return;
        }

        if (_characters[_currentIndex].Id == newCharacter.Id)
        {
            EventManager.ObjectSetActive(_characters[_currentIndex]);
            return;
        }

        for (int i = 0; i < _characters.Length; i++)
        {
            if (_characters[i].Id == newCharacter.Id)
            {
                _currentIndex = i;
                break;
            }
        }
    }

    private void Start()
    {
        LoadCharacters();
       
    }

    private void LoadCharacters()
    {
        _characters = dataPackCharacters.GetItems<CharacterConfig>();
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
                EventManager.ObjectSetActive(_characters[_currentIndex]); 
                break;
        }
    }

    private void MoveSelection(int step)
    {
        _currentIndex += step;
        if (_currentIndex < 0) 
        {
            _currentIndex = _characters.Length - 1;
        }
        else
        {
            if (_currentIndex >= _characters.Length)
            {
                _currentIndex = 0;
            }
        }

        SelectCharacter(_currentIndex);
    }

    private void SelectCharacter(int index)
    {
        EventManager.CharacterSelected(_characters[index]);
    }
}
