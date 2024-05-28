using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    [SerializeField] Image uiPlayer;

    [SerializeField] Button playBtn;
    [SerializeField] TextMeshProUGUI playText;

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

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.characterCount-1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectOption)
    {
        Character character = characterDB.GetCharacter(selectOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

        uiPlayer.sprite = character.characterSprite;

        CheckAllowPlay(character);
    }

    public void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    public void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void CheckAllowPlay(Character _character)
    {
        if (_character.owned)
        {
            playBtn.interactable = true;
            uiPlayer.color = _character.nomarColor;
            playText.text = "Play";
        }
        else
        {
            playBtn.interactable = false;
            uiPlayer.color = _character.lockedColor;
            playText.text = "Log";
        }
    }
}
