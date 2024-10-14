using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPack", menuName = "Content/Data Pack", order = 1)]
public class DataPack : ScriptableObject
{
    [SerializeField] private ScriptableObject[] items;

    public T[] GetItems<T>() where T : class, IObject
    {
        T[] filteredItems = items.OfType<T>().ToArray();
        return filteredItems;
    }
}
