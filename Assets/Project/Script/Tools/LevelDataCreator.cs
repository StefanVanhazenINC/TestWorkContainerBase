using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelDataCreator : MonoBehaviour
{
    private const string Path = "Assets/Project/Resources/Level/";

    [MenuItem("Content/Level Data From Selected Scene")]
    private static void CreateLevelDataFromSelectedScene()
    {
        int indexValue = 0;

        foreach (Object obj in Selection.objects)
        {
            Debug.Log(obj);
            if (obj is SceneAsset)
            {
                indexValue++;
                SceneAsset scene = obj as SceneAsset;
                string path = AssetDatabase.GetAssetPath(scene);

                LevelConfig newLevel = ScriptableObject.CreateInstance<LevelConfig>();

                newLevel.SetEditorOnlyProperties(
                    indexValue,
                    scene.name ,
                    scene.name);

                string assetPath = AssetDatabase.GenerateUniqueAssetPath(Path + scene.name + ".asset");

                AssetDatabase.CreateAsset(newLevel, assetPath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
