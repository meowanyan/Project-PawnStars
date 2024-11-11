using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemDisplay : MonoBehaviour
{
    [SerializeField] ItemCreation ItemDetails;
    [SerializeField] public int finalPrice { get; private set; }

    [field: SerializeField] TextMeshProUGUI nameText;
    [field: SerializeField] TextMeshProUGUI traitText;
    [field: SerializeField] TextMeshProUGUI priceModifierText;
    [field: SerializeField] TextMeshProUGUI finalPriceText;

    private void Update()
    {
        nameText.text = ItemDetails.name;
        traitText.text = ItemDetails.trait;
        priceModifierText.text = ItemDetails.priceModifier.ToString();
        CalculatePrice();
    }

    private void CalculatePrice()
    {
        finalPrice =+ ItemDetails.priceModifier;
        finalPriceText.text = finalPrice.ToString();
        return;
    }
}
