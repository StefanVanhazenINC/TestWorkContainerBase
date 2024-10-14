using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Content/Character Data", order = 0)]
public class CharacterConfig : ScriptableObject, ICharacter
{
    [SerializeField] private int id;
    [SerializeField] private string characterName;
    [SerializeField] private int level;
    [SerializeField] private Sprite avatar;
    [SerializeField] private string modelPath;

    public int Id => id;
    public string LevelName => characterName;
    public int Level => level;
    public Sprite Avatar => avatar;
    public string ModelPath => modelPath;


#if UNITY_EDITOR
    public void SetEditorOnlyProperties(string spritePath, string name, int level, int id)
    {
        avatar = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
        characterName = name;
        this.level = level;
        this.id = id;
    }
#endif
}
