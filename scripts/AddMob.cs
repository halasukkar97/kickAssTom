using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AddMob : MonoBehaviour {

    private static BannerView banner;

    void Start()
    {
        Debug.Log("add start");
        RequestBanner();
        AddBanner();
    }

    private void RequestBanner()
    {
        Debug.Log("requesting banner");
        //#if UNITY_ANDROID
        //string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
        //#else
        string adUnitId = "ca-app-pub-4553071372947424/4809203358";
        //#endif

        // Create a 320x50 banner at the top of the screen.
         banner = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       // .AddTestDevice("16E28B558CE4395071320F7F3BC2CC3F")  // My test device.   
       .AddTestDevice("C08886AC18E0187C9E2CFC90AB3C3129")
         .Build();

        // Load the banner with the request.
        banner.LoadAd(request);
    }

    public void RemoveBanner()
    {
        banner.Hide();
        //banner = null;
    }

    public void AddBanner()
    {
        banner.Show();
    }
}
