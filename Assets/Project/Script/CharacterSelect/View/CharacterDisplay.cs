using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : ObjectView
{
    public override void SetDislay(IObject newObject)
    {

        CharacterConfig character;

        try
        {
            character = (CharacterConfig)newObject;
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

        //
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(character.Name);
        sb.AppendLine();
        sb.AppendLine($"Level: {character.Level}");
        sb.AppendLine($"ID: {character.Id}");
        //
        SetText(sb.ToString());
        SetImage(character.Avatar);
    }
    public void DisplayCharacter(IObject newObject)
    {
        CharacterConfig character;

        try
        {
            character = (CharacterConfig)newObject;
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

        //
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(character.Name);
        sb.AppendLine();
        sb.AppendLine($"Level: {character.Level}");
        sb.AppendLine($"ID: {character.Id}");
        //
        SetText(sb.ToString());
        SetImage(character.Avatar);


    }
}
