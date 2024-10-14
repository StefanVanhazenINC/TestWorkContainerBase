using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ResourcesPathPrinter 
{
    [MenuItem("Tools/Print Resources Paths")]
    public static void PrintResourcesPaths()
    {
        foreach (Object obj in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            Debug.Log(path);

        }
    }
    
}
