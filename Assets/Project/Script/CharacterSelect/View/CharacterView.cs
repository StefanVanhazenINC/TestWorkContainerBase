using UnityEngine;
using UnityEngine.UI;

public class CharacterView : ObjectView
{
    [SerializeField] private Button selectButton;
    private MyCharacter character;

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
        EventManager.CharacterSelected(character);
    }

    public void DisplayCharacter(MyCharacter character)
    {
        this.character = character;
        SetText(character.Name);
        SetImage(character.Avatar);
    }
}
