using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the "selectedOption" key exists in PlayerPrefs
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            // If the key doesn't exist, set the default selectedOption to 0
            selectedOption = 0;
        }
        else
        {
            // If the key exists, load the selectedOption value from PlayerPrefs
            Load();
        }

        // Update the character sprite based on the selectedOption
        UpdateCharacter(selectedOption);
    }

    // Updates the character sprite based on the selectedOption
    private void UpdateCharacter(int selectedOption)
    {
        // Get the character from the CharacterDatabase based on the selectedOption
        Character character = characterDB.GetCharacter(selectedOption);

        // Update the artworkSprite with the character's sprite
        artworkSprite.sprite = character.characterSprite;
    }

    // Loads the selectedOption value from PlayerPrefs
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
