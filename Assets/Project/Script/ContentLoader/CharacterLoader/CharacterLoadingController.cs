using UnityEngine;

public class CharacterLoadingController : MonoBehaviour
{
    [SerializeField] private ContentLoader contentLoader;
    [SerializeField] private DataPack dataPack_Characters;
    [SerializeField] private CharacterView characterViewPrefab;
    [SerializeField] private Transform viewParent;

    void Start()
    {
        var characterManager = new CharacterManager();

        CharacterConfig[] characters = LoadCharacters();
        contentLoader.LoadContent(characterManager, characters);
        DisplayCharacters(characters);
    }

    private CharacterConfig[] LoadCharacters()
    {
        return dataPack_Characters.GetItems<CharacterConfig>();
    }

    private void DisplayCharacters(CharacterConfig[] characters)
    {
        foreach (CharacterConfig character in characters)
        {
            CharacterView viewInstance = Instantiate(characterViewPrefab, viewParent);
            viewInstance.DisplayCharacter(character);
        }
    }
}
