using UnityEditor;
using UnityEngine;

public class CharacterCreator 
{
    private const string Path = "Assets/Project/Resources/Character/NewCharacter_";

    [MenuItem("Content/Character Data From Selected Images")]
    private static void CreateCharacterDataFromSelectedImages()
    {
        int indexValue = 0;
     
        foreach (Object obj in Selection.objects)
        {
            Debug.Log(obj);
            if (obj is Texture2D)
            {
                indexValue++;
                Texture2D texture = obj as Texture2D;
                string path = AssetDatabase.GetAssetPath(texture);

                CharacterConfig newCharacter = ScriptableObject.CreateInstance<CharacterConfig>();

                newCharacter.SetEditorOnlyProperties(
                    path,
                    texture.name,
                    Random.Range(1, 10),
                    indexValue);

                string assetPath = AssetDatabase.GenerateUniqueAssetPath(Path + texture.name + ".asset");

                AssetDatabase.CreateAsset(newCharacter, assetPath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
