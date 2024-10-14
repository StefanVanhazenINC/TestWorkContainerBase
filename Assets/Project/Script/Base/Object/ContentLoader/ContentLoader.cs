using UnityEngine;

public class ContentLoader : MonoBehaviour
{
    public void LoadContent<T>(ObjectManager<T> manager, T[] content) where T : IObject
    {
        manager.LoadObjects(content);
    }
}
