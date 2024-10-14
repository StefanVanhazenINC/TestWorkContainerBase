
using UnityEngine;

public abstract class ContentLoadingContoller<View,Data> : MonoBehaviour where View : ObjectView where Data : class, IObject 
{
    [SerializeField] private ContentLoader contentLoader;
    [SerializeField] private DataPack dataPack;
    [SerializeField] private View iewPrefab;
    [SerializeField] private Transform viewParent;

    
    protected void Consturct<G>(G newManager) where G : ObjectManager<Data>
    {
        var manager = newManager;

        Data[] data = LoadData();
        contentLoader.LoadContent(manager, data);
        DisplayCharacters(data);
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
