using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectDisplayInstaller : MonoBehaviour
{
    [SerializeField] private CharacterDisplay characterDisplay;

    private void OnEnable()
    {
        characterDisplay??= GetComponent<CharacterDisplay>();
        EventManager.OnObjectSelected += characterDisplay.DisplayCharacter;
    }

    private void OnDisable()
    {
        EventManager.OnObjectSelected -= characterDisplay.DisplayCharacter;
    }

}
