using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public abstract class ObjectView : MonoBehaviour
{
    [SerializeField] protected TMP_Text infoText;
    [SerializeField] protected Image infoImage;

    public abstract void SetDislay(IObject newObject);
    
    public void SetText(string text)
    {
        if (infoText != null) infoText.text = text;
    }

    public void SetImage(Sprite image)
    {
        if (infoImage != null) infoImage.sprite = image;
    }
}
