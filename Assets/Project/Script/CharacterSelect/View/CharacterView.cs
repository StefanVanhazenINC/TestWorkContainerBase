using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterView : ObjectView<CharacterConfig>
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
        EventManager.ObjectSelected(_character);
    }
  
    public override void SetDisplayInfo(CharacterConfig newObject)
    {
        _character = newObject;
        SetText(newObject.LevelName);
        SetImage(newObject.Avatar);

    }    
}        
