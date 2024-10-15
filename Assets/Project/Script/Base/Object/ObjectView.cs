using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public abstract class ObjectView<Data> : MonoBehaviour where Data : class,IObject
{
    [SerializeField] protected TMP_Text infoText;
    [SerializeField] protected Image infoImage;
    public virtual void SetDislay(IObject newObject) 
    {
        Data currentObject;

        try
        {
            currentObject = (Data)newObject;
            SetDisplayInfo(currentObject);
        }
        catch (InvalidCastException)
        {
            Debug.LogError($"The provided object cannot be cast to Config.");
            return;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
            return;
        }

    }
    public abstract void SetDisplayInfo(Data newObject);
    
    public void SetText(string text)
    {
        if (infoText != null) infoText.text = text;
    }

    public void SetImage(Sprite image)
    {
        if (infoImage != null) infoImage.sprite = image;
    }
}
