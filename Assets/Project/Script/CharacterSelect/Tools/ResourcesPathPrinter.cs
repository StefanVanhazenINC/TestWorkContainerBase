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
           // PrintPathsRecursive(path, "");
        }

    }

    private static void PrintPathsRecursive(string directoryPath, string relativePath)
    {
        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            if (filePath.EndsWith(".meta") || filePath.EndsWith(".FBX") || filePath.EndsWith(".PNG")) continue;

            string relativeFilePath = Path.Combine(relativePath, Path.GetFileName(filePath));
            Debug.Log("Resource path: " + relativeFilePath.Replace("\\", "/"));
        }

        foreach (string subDirectory in Directory.GetDirectories(directoryPath))
        {
            string newRelativePath = Path.Combine(relativePath, Path.GetFileName(subDirectory));
            PrintPathsRecursive(subDirectory, newRelativePath);
        }
    }
}
