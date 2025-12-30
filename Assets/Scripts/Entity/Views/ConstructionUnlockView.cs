using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionUnlockView : InteractionView
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _buyButton;
    private int price;
    private Action onBuy;

    protected override void Start()
    {
        base.Start();
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    public void Setup(Sprite icon, string name, int price, Action onBuySuccess)
    {
        _iconImage.sprite = icon;
        _nameText.text = name;
        _priceText.text = UIExtension.FormatMoney(price);
        this.price = price;
        onBuy = onBuySuccess;
    }

    private void OnBuyButtonClick()
    {
        onBuy?.Invoke();
    }
}
