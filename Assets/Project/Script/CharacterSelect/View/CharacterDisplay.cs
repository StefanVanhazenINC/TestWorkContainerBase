using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image avatarImage;

    private void OnEnable()
    {
        EventManager.OnObjectSelected += DisplayCharacter;
    }

    private void OnDisable()
    {
        EventManager.OnObjectSelected -= DisplayCharacter;
    }

    private void DisplayCharacter(IObject newObject)
    {
        MyCharacter character;

        try
        {
            character = (MyCharacter)newObject;
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

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(character.name);
        sb.AppendLine();
        sb.AppendLine($"Level: {character.Level}");
        sb.AppendLine($"ID: {character.Id}");

        nameText.text = sb.ToString();
        avatarImage.sprite = character.Avatar;
    }
}
