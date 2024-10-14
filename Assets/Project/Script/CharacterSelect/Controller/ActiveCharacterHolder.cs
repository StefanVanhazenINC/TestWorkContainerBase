using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacterHolder : ActiveObjectHolder
{
   
    private CharacterConfig _activeCharacter;
    public override void OnChangeActiveObject()
    {
        _activeCharacter = _activeObject as CharacterConfig;
        EventManager.ChangeActiveObject(_activeCharacter);
    }
}
