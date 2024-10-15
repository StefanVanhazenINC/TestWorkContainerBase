using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : ObjectView<LevelConfig>
{
    [SerializeField] private Button _loadingLevelBtn;

    public Button LoadingLevelBtn { get => _loadingLevelBtn; }

    public override void SetDisplayInfo(LevelConfig newObject)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"ID: {newObject.Id}");
        sb.AppendLine($"Level Name:{newObject.LevelName}");
        sb.AppendLine($"Description:{newObject.Description}");
        sb.AppendLine();
        SetText(sb.ToString());
        SetImage(newObject.Icon);
    }
}
