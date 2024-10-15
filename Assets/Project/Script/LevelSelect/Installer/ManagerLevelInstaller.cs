using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevelInstaller : MonoBehaviour
{
    [SerializeField] private LevelSelector levelSelector;
    [SerializeField] private LoadingLevelController loadingCharacterController;
    private void Start()
    {
        Construct();
    }
    private void Construct()
    {
        LevelManager levelManager = new LevelManager();
        loadingCharacterController.Consturct(levelManager);
        levelSelector.Construct(levelManager);

    }
}
