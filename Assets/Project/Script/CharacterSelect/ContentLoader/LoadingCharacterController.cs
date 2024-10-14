using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCharacterController : ContentLoadingContoller<CharacterView, CharacterConfig>
{
    public void Start()
    {
        Consturct(new CharacterManager());
    }
   
}
