using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the "selectedOption" key exists in PlayerPrefs
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            // If the key exists, load the selectedOption value from PlayerPrefs
            Load();
        }

        // Update the character information based on the selectedOption
        UpdateCharacter(selectedOption);
    }

    // Method to go to the next character option
    public void nextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    // Method to go to the previous character option
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    // Updates the character information based on the selectedOption
    private void UpdateCharacter(int selectedOption)
    {
        // Get the character from the CharacterDatabase based on the selectedOption
        Character character = characterDB.GetCharacter(selectedOption);

        // Update the artworkSprite with the character's sprite
        artworkSprite.sprite = character.characterSprite;

        // Update the nameText with the character's name
        nameText.text = character.characterName;
    }

    // Loads the selectedOption value from PlayerPrefs
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    // Saves the selectedOption value to PlayerPrefs
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    // Changes the scene based on the provided sceneID
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}

