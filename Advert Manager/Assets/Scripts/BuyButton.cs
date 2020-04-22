using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Gold50,
        Gold100
    }

    public ItemType itemType;

    public Text PriceText;

    private string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        defaultText = PriceText.text;
        StartCoroutine(LoadPriceRoutine());
        
    }

    public void ClickBuy()
    {
        switch (itemType)
        {
            case ItemType.Gold50:
                IAPmanager.Instance.Buy50Gold();
                break;

            case ItemType.Gold100:
                IAPmanager.Instance.Buy100Gold();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPmanager.Instance.IsInitialized())
            yield return null;

        string loadedPrice = "";

        switch (itemType)
        {
            case ItemType.Gold50:
                loadedPrice = IAPmanager.Instance.GetProductPriceFromStore(IAPmanager.Instance.gold50);
                break;

            case ItemType.Gold100:
                loadedPrice = IAPmanager.Instance.GetProductPriceFromStore(IAPmanager.Instance.gold100);
                break;
        }

        PriceText.text = defaultText + " " + loadedPrice;
    }
}
