using UnityEngine;

public class LevelSelector : ObjectSelectors<LevelManager, LevelConfig>
{
    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnLevelLoading += LoadingSelectLevel;
    }
    protected override void OnDisable() 
    {
        base.OnDisable();
        EventManager.OnLevelLoading -= LoadingSelectLevel;

    }
    public void LoadingSelectLevel()
    {
        LevelConfig selectLevel = _manager.GetObject(_currentIndex);
        Debug.Log($"Загрузить уровень:{selectLevel.SceneName}");
    }
}
