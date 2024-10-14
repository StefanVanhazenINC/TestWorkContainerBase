using UnityEngine;

public abstract class ObjectManager<T> where T : IObject
{
    protected T[] objects;

    public virtual void LoadObjects(T[] objectsToLoad)
    {
        objects = objectsToLoad;
    }

    public abstract void SelectObject(int id);
}
