using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdMob : MonoBehaviour {

    private static BannerView banner;

    void Start()
    {
        Debug.Log("add start");
        RequestBanner();
        Debug.Log("RequestBanner");
        AddBanner();
    }

    private void RequestBanner()
    {
        Debug.Log("requesting banner");
        string adUnitId = "ca-app-pub-4553071372947424/4809203358";
      
        // Create a 320x50 banner at the top of the screen.
        banner = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        // .AddTestDevice("16E28B558CE4395071320F7F3BC2CC3F")  // My test device.   
       .AddTestDevice("F4DBA59107F1CE4F5495CD7021D08150") //my phone
        .Build();
        // Load the banner with the request.
        banner.LoadAd(request);
    }
   
    public void RemoveBanner()
    {
        banner.Hide();
    }

    public void AddBanner()
    {
        banner.Show();
    }
}
