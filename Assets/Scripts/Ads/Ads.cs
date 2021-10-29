using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    private string gameId = "3929863", type = "video";
    private bool testMode = false;
    private static int countLoses = 0;

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, testMode);
            countLoses++;
            if (countLoses % 2 == 0)
            {
                Advertisement.Show(type);
            }
        }
    }
}

