using System;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private DataPack dataPackCharacters;
    private MyCharacter[] characters;
    private int currentIndex = 0;

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
        MyCharacter newCharacter;

        try
        {
            newCharacter = (MyCharacter)newObject;
        }
        catch (InvalidCastException)
        {
            Debug.LogError($"The provided object cannot be cast to MyCharacter.");
            return;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
            return;
        }

        if (characters[currentIndex].Id == newCharacter.Id)
        {
            return;
        }

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].Id == newCharacter.Id)
            {
                currentIndex = i;
                break;
            }
        }
    }

    private void Start()
    {
        LoadCharacters();
        if (characters.Length > 0)
        {
            SelectCharacter(currentIndex);
        }
        else
        {
            Debug.LogError("[CharacterSelector] Empty DataPack");
        }
    }

    private void LoadCharacters()
    {
        characters = dataPackCharacters.GetItems<MyCharacter>();
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
                EventManager.ObjectSetActive(characters[currentIndex]); 
                break;
        }
    }

    private void MoveSelection(int step)
    {
        currentIndex += step;
        if (currentIndex < 0) 
        {
            currentIndex = characters.Length - 1;
        }
        else
        {
            if (currentIndex >= characters.Length)
            {
                currentIndex = 0;
            }
        }

        SelectCharacter(currentIndex);
    }

    private void SelectCharacter(int index)
    {
        EventManager.CharacterSelected(characters[index]);
    }
}
