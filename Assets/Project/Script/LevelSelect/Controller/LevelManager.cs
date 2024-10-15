using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : ObjectManager<LevelConfig>
{

    public override void LoadObjects(LevelConfig[] levelToLoad)
    {
        base.LoadObjects(levelToLoad);
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
    public override LevelConfig GetObject(int id)
    {
        return _objects[id];
    }
}
