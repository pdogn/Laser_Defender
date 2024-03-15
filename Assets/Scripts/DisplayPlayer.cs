using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayer : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectOption)
    {
        Character character = characterDB.GetCharacter(selectOption);
        artworkSprite.sprite = character.characterSprite;
    }

    public void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
