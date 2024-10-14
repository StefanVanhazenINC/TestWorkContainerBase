
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "newLevel", menuName = "Content/Level Data", order = 1)]
public class LevelConfig : ScriptableObject, ILevel
{
    [SerializeField] private int id;
    [SerializeField] private string levelName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private string sceneName;
    public int Id => id;
    public string LevelName => levelName;
    public string Description => description;
    public Sprite Icon => icon;
    public string SceneName => sceneName;

#if UNITY_EDITOR
    public void SetEditorOnlyProperties(int id, string levelName, string sceneName)
    {
        this.id = id;
        this.levelName = levelName;
        this.sceneName = sceneName;
      
    }
#endif
}
