using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterDisplay : ObjectView<CharacterConfig>
{
    
    public override void SetDisplayInfo(CharacterConfig newObject)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(newObject.LevelName);
        sb.AppendLine();
        sb.AppendLine($"Level: {newObject.Level}");
        sb.AppendLine($"ID: {newObject.Id}");
        //
        SetText(sb.ToString());
        SetImage(newObject.Avatar);
    }   
}       
        
        
        
        
        