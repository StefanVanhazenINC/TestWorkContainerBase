using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterView : ObjectView
{
    [SerializeField] private Button selectButton;
    private CharacterConfig _character;

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
        EventManager.CharacterSelected(_character);
    }

    public override void SetDislay(IObject newObject)
    {
        _character = newObject as CharacterConfig;
        SetText(_character.Name);
        SetImage(_character.Avatar);
    }
}
