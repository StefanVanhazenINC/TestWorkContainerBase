using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacterInstaller : MonoBehaviour
{
    [SerializeField] private CharacterSelector characterSelector;
    [SerializeField] private LoadingCharacterController loadingCharacterController;
    private void Start()
    {
        Construct();
    }
    private void Construct ()
    {
        CharacterManager characterManager = new CharacterManager();
        loadingCharacterController.Consturct(characterManager);
        characterSelector.Construct(characterManager);

    }
}
