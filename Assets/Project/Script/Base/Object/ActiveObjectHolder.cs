using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveObjectHolder : MonoBehaviour
{
    protected IObject _activeObject;
    protected virtual void OnEnable()
    {
        EventManager.OnObjectSetActive += SetNewActiveObject;
    }

    protected virtual void OnDisable()
    {
        EventManager.OnObjectSetActive -= SetNewActiveObject;
    }
    public virtual void SetNewActiveObject(IObject newObject)
    {
        _activeObject = newObject ;
        OnChangeActiveObject();
    }
    public abstract void OnChangeActiveObject();
}
