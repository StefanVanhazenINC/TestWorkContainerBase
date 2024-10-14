using UnityEngine;
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

    public void DisplayCharacter(CharacterConfig character)
    {
        this._character = character;
        SetText(character.Name);
        SetImage(character.Avatar);
    }
}
