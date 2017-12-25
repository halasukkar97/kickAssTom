using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAdvertisement : MonoBehaviour {

    private static BannerView BANNER;

    void Start()
    {
        //start with requesting and showig the banner
        Debug.Log("add start");
        _RequestBanner();
        Debug.Log("RequestBanner");
        ShowBanner();
    }

    private void _RequestBanner()
    {
        Debug.Log("requesting banner");
        string adUnitId = "ca-app-pub-4553071372947424/4809203358";

        // Create a 320x50 banner at the top of the screen.
        BANNER = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        // .AddTestDevice("16E28B558CE4395071320F7F3BC2CC3F")  // My test device.   
       .AddTestDevice("F4DBA59107F1CE4F5495CD7021D08150") //my phone
        .Build();
        // Load the banner with the request.
        BANNER.LoadAd(request);
    }
   
    //function to hide banner
    public void RemoveBanner()
    {
        BANNER.Hide();
    }

    //function to show Banner
    public void ShowBanner()
    {
        BANNER.Show();
    }
}
