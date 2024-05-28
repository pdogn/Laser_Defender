using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI coinText;
    [SerializeField] public int Coin;

    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = .5f;
    float itemWidth;

    [Header("UI elements")]
    //[SerializeField] Image selectedCharacterIcon;
    //[SerializeField] Transform ShopMenu;
    [SerializeField] Transform ShopItemsContainer;
    [SerializeField] GameObject itemPrefab;
    [Space(20)]
    [SerializeField] CharacterDatabase characterDB;

    void Start()
    {
        if (PlayerPrefs.HasKey(Scorekeeper.instance.GetTotalCoinKey))
        {
            Coin = Scorekeeper.instance.GetTotalCoin();
            coinText.text = "Coin: " + Scorekeeper.instance.GetTotalCoin().ToString();
        }

        GenerateShopItemsUI();
    }

    void GenerateShopItemsUI()
    {

        //Delete itemTemplate after calculating item's Height :
        itemWidth = ShopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        Destroy(ShopItemsContainer.GetChild(0).gameObject);
        //DetachChildren () will make sure to delete it from the hierarchy, otherwise if you 
        //write ShopItemsContainer.ChildCount you w'll get "1"
        ShopItemsContainer.DetachChildren();

        //Generate Items
        for (int i = 0; i < characterDB.characterCount; i++)
        {
            //Create a Character and its corresponding UI element (uiItem)
            Character character = characterDB.GetCharacter(i);
            CharacterItemUI uiItem = Instantiate(itemPrefab, ShopItemsContainer).GetComponent<CharacterItemUI>();

            //Move item to its position
            uiItem.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

            //Set Item name in Hierarchy (Not required)
            //uiItem.gameObject.name = "Item" + i + "-" + character.name;
            //Set Index Ship
            uiItem.SetIndexShip(i);
            //Add information to the UI (one item)
            if (character.owned)
            {
                uiItem.SetPriceText("onwed");
                uiItem.SetNoInteractableButton();
            }
            else
            {
                uiItem.SetPriceText(character.characterPrice.ToString());
                uiItem.SetPrice(character.characterPrice);
            }
            uiItem.SetShipName(character.characterName);
            uiItem.SetShipSkin(character.characterSprite);

        }

    }


    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
