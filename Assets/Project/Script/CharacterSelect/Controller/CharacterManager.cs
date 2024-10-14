using UnityEngine;

public class CharacterManager : ObjectManager<CharacterConfig>
{
    public int CurrentIndex => _currentIndex;
    private int _currentIndex = -1;

    public override void LoadObjects(CharacterConfig[] charactersToLoad)
    {
        base.LoadObjects(charactersToLoad);
    }

    public override void SelectObject(int id)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i].Id == id)
            {
                _currentIndex = i;
                DisplayCharacterInfo(_objects[i]);
                break;
            }
        }
    }

    private void DisplayCharacterInfo(CharacterConfig character)
    {
        Debug.Log($"Name: {character.Name}, Level: {character.Level}");
    }
}
