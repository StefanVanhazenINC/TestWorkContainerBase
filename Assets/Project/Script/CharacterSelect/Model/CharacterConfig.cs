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

    public int Id => this.id;
    public string Name => this.characterName;
    public int Level => this.level;
    public Sprite Avatar => this.avatar;
    public string ModelPath => this.modelPath;


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
