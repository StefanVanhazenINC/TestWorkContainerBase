
using UnityEngine;

public abstract class ContentLoadingContoller<View,Data> : MonoBehaviour where View : ObjectView where Data : class, IObject 
{
    [SerializeField] private DataPack dataPack;
    [SerializeField] private View iewPrefab;
    [SerializeField] private Transform viewParent;

    
    public void Consturct<G>(G newManager) where G : ObjectManager<Data>
    {
        var manager = newManager;

        Data[] data = LoadData();
        LoadContent(manager, data);
        DisplayCharacters(data);
    }
    private void LoadContent(ObjectManager<Data> manager, Data[] content) 
    {
        manager.LoadObjects(content);
    }
    private Data[] LoadData()
    {
        return dataPack.GetItems<Data>();
    }

    private void DisplayCharacters(Data[] characters)
    {
        foreach (Data character in characters)
        {
            View viewInstance = Instantiate(iewPrefab, viewParent);
            SetDisplay(viewInstance,character);
        }
    }

    public virtual void SetDisplay(View view, Data Data) 
    {
        view.SetDislay(Data);
    }
    
}
