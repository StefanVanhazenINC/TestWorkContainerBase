using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectDisplayInstaller : MonoBehaviour
{
    [SerializeField] private LevelDisplay levelDisplay;

    private void OnEnable()
    {
        levelDisplay ??= GetComponent<LevelDisplay>();
        EventManager.OnObjectSelected += levelDisplay.SetDislay;
        levelDisplay.LoadingLevelBtn.onClick.AddListener(EventManager.LoadingLevel);
    }

    private void OnDisable()
    {
        EventManager.OnObjectSelected -= levelDisplay.SetDislay;
        levelDisplay.LoadingLevelBtn.onClick.RemoveListener(EventManager.LoadingLevel);

    }
}
