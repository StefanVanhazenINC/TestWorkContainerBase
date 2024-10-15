using UnityEngine;

public abstract class ObjectManager<T> where T : IObject
{
    protected T[] _objects;

    public virtual void LoadObjects(T[] objectsToLoad)
    {
        _objects = objectsToLoad;
    }

    public abstract int SelectObject(int id);

    public abstract T GetObject(int id);
    public int GetLenght() 
    {
        return _objects.Length;
    }
}
