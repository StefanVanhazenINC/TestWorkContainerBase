using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Content/Character Data", order = 0)]
public class MyCharacter : ScriptableObject, ICharacter
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
    /// <summary>
    /// Sets the character's properties in the Unity Editor.
    /// This method should only be used within the Unity Editor.
    /// </summary>
    /// <param name="spritePath">The asset path of the sprite to use as the character's avatar.</param>
    /// <param name="name">The name of the character.</param>
    /// <param name="level">The level of the character.</param>
    /// <param name="id">The unique identifier for the character.</param>
    public void SetEditorOnlyProperties(string spritePath, string name, int level, int id)
    {
        avatar = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
        characterName = name;
        this.level = level;
        this.id = id;
    }
#endif
}
