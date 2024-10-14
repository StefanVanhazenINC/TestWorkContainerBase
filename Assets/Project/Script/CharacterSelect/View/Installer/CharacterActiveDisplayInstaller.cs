using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActiveDisplayInstaller : MonoBehaviour
{
    [SerializeField] private CharacterDisplay characterDisplay;

    private void OnEnable()
    {
        characterDisplay??=GetComponent<CharacterDisplay>();
        EventManager.OnChangeActiveObject += characterDisplay.SetDislay;
    }

    private void OnDisable()
    {
        EventManager.OnChangeActiveObject -= characterDisplay.SetDislay;
    }
}
