using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{

    public enum ItemType
    {
        Gold50,
        Gold100,
        NoAds
    }

    public ItemType itemType;

    public Text priceText;

    private string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void clickBuy()
    {
        switch (itemType)
        {
            case ItemType.Gold50:
                IAPmanager.Instance.Buy50Gold();
                break;

            case ItemType.Gold100:
                IAPmanager.Instance.Buy100Gold();
                break;

            case ItemType.NoAds:
                IAPmanager.Instance.BuyNoAds();
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
                loadedPrice = IAPmanager.Instance.getProductPriceFromStore(IAPmanager.Instance.GOLD_50);
                    break;

                case ItemType.Gold100:
                loadedPrice = IAPmanager.Instance.getProductPriceFromStore(IAPmanager.Instance.GOLD_100);
                    break;

                case ItemType.NoAds:
                loadedPrice = IAPmanager.Instance.getProductPriceFromStore(IAPmanager.Instance.NO_ADS);
                    break;
            }
        priceText.text = defaultText + " " + loadedPrice;
    }
}
