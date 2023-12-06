using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public void Awake()
    {
        Advertisement.Initialize("5490661", true, this);
    }


    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (Advertisement.isInitialized)
            Advertisement.Show("Rewarded_Android", this);
    }

    

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("FailedToLoad");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Complete");
        GameManager.Instance.AddDiamondFromAds(100);
        var diamondCount = GameManager.Instance.Player.AmountOfDiamonds;
        UIManager.Instance.UpdateGemCount(diamondCount);
        UIManager.Instance.OpenShop(diamondCount);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Init Complete");
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Failed");
    }

    public void LoadRewardedAd()
    {
        if (Advertisement.isInitialized)
            Advertisement.Load("Rewarded_Android", this);
    }
}
