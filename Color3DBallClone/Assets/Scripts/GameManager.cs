using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    private void Start()
    {
        CoinCalculator(0);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("finishLine"))
        {
            CoinCalculator(100);
            uiManager.coinTextUpdate();
            
            uiManager.FinishScreen();
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
