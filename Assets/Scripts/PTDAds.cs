using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class PTDAds
{

    string adUnitId = "ca-app-pub-5838986938071394/2684071660";
    string fullAdUnitId = "ca-app-pub-5838986938071394/9648935264";
    InterstitialAd interstitialAds;
    BannerView bannerView;

    static PTDAds ads;

    public static PTDAds GetInstance()
    {
        if (ads == null)
            ads = new PTDAds();

        return ads;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RequestBannerAds()
    {
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public void RequestInterstitialAds()
    {
        interstitialAds = new InterstitialAd(fullAdUnitId);
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        interstitialAds.LoadAd(request);
    }

    public void RemoveBannerAds()
    {
        bannerView.Hide();
    }

    public void ShowIntersitialAds()
    {
        if (interstitialAds.IsLoaded())
            interstitialAds.Show();
        else
            RequestInterstitialAds();
    }

}
