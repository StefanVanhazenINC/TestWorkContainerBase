using UnityEngine;

public class CharacterManager : ObjectManager<CharacterConfig>
{

    public override void LoadObjects(CharacterConfig[] charactersToLoad)
    {
        base.LoadObjects(charactersToLoad);
    }

    public override int SelectObject(int id)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }
   
}
