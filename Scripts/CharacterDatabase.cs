using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;

    // Returns the number of characters in the database
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    // Retrieves the character at the specified index
    public Character GetCharacter(int index)
    {
        return character[index];
    }

}
