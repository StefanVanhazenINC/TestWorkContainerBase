using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : ObjectView<LevelConfig>
{
    [SerializeField] private Button selectButton;
    private LevelConfig _character;

    private void OnEnable()
    {
        selectButton.onClick.AddListener(ButtonClicked);
    }

    private void OnDisable()
    {
        selectButton.onClick.RemoveListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        EventManager.ObjectSelected(_character);
    }

 
    public override void SetDisplayInfo(LevelConfig newObject)
    {
        _character = newObject;
        SetText(_character.LevelName);
        SetImage(_character.Icon);
    }
}
