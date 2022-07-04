using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public AdManager adManager;

    private void Start()
    {
        CoinCalculator(0);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("finishLine"))
        {
            CoinCalculator(100);

            if(PlayerPrefs.GetInt("NoAds") == 0)
            {
                adManager.RequestInterstitial();
            }
            adManager.RequestRewardedAd();
            uiManager.coinTextUpdate();
            
            uiManager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }


    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
            
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 0);
        }
        
    }
}
