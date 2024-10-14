using UnityEngine;

public abstract class ObjectManager<T> where T : IObject
{
    protected T[] _objects;

    public virtual void LoadObjects(T[] objectsToLoad)
    {
        _objects = objectsToLoad;
    }

    public abstract void SelectObject(int id);
}
