using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{

    public string gameId = "3483556";
    public string placementId = "bannerPlacement";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }
        IEnumerator ShowBannerWhenReady()
        {
            while (!Advertisement.IsReady(placementId))
            {
                yield return new WaitForSeconds(0.5f);
            }
            Advertisement.Banner.Show(placementId);
        }    
}