using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemUI : MonoBehaviour
{
    public int indexShip;

    [SerializeField] TextMeshProUGUI shipName;
    [SerializeField] Image shipSkin;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] int price;
    [SerializeField] Button priceBtn;

    [SerializeField] ShopManager shopManager;

    [SerializeField] CharacterDatabase characterDatabase;

    private void Start()
    {
        shopManager = GameObject.FindObjectOfType<ShopManager>();
    }

    public void SetIndexShip(int _indexShip)
    {
        indexShip = _indexShip;
    }

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetShipName(string _shipName)
    {
        shipName.text = _shipName;
    }

    public void SetShipSkin(Sprite _shipSkin)
    {
        shipSkin.sprite = _shipSkin;
    }

    public void SetPriceText(string _priceText)
    {
        priceText.text = _priceText.ToString();
    }

    public void SetPrice(int _price)
    {
        price = _price;
    }

    public void SetNoInteractableButton()
    {
        priceBtn.interactable = false;
    }

    public void Purchase()
    {
        if(price <= shopManager.Coin)
        {
            Debug.Log("purchased");
            shopManager.Coin -= price;

            shopManager.coinText.text = "Coin: " + shopManager.Coin.ToString();

            Scorekeeper.instance.TotalCoin = shopManager.Coin;
            Scorekeeper.instance.SaveTotalCoin();

            characterDatabase.GetCharacter(indexShip).owned = true;
            SetPriceText("onwed");
            SetNoInteractableButton();
        }
        else
        {
            Debug.Log("Have not money");
            Debug.Log("You need more : " + (price - shopManager.Coin));
        }
    }
}
