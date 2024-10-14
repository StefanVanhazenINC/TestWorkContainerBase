using System;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    [SerializeField] private Transform parent = null;

    private void OnEnable()
    {
        EventManager.OnObjectSelected += LoadCharacterModel;
    }

    private void OnDisable()
    {
        EventManager.OnObjectSelected -= LoadCharacterModel;
    }

    void LoadCharacterModel(IObject newObject)
    {
        CharacterConfig character;

        try
        {
            character = (CharacterConfig)newObject;
        }
        catch (InvalidCastException)
        {
            Debug.LogError($"The provided object cannot be cast to CharacterConfig.");
            return;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
            return;
        }

        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

        var model = Resources.Load(character.ModelPath, typeof(GameObject)) as GameObject;
        if (model != null)
        {
            var gameObject = Instantiate(model, parent);
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.LogError("Failed to load the model.");
        }
    }
}
