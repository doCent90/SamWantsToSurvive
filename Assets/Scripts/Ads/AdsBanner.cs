using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsBanner : MonoBehaviour
{
    private string gameId = "3929863", type = "banner";
    private bool testMode = false;


    private void Start()
    {   
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(showBannerAds());
            Advertisement.Initialize(gameId, testMode);
        }        
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StopCoroutine(showBannerAds());
        }
    }

    IEnumerator showBannerAds()
    {
        while (!Advertisement.IsReady(type))
        {
            yield return new WaitForSeconds(1f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(type);
    }
}

