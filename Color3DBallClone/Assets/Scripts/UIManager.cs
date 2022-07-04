using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public SoundManager sounds;
    public Image whiteEffectImage;
    private int effectControl;
    public Animator anim;
    public GameObject Player;
    public GameObject finishLine;

    private bool isRadialShine;

    //Buttons

    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject LayoutBg;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iad;
    public GameObject information;


    public GameObject introHand;
    public GameObject toptopMoveTxt;
    public GameObject noAdsButton;
    public GameObject shopButton;
    public Text coinText;

    public GameObject restartScreen;

    //FinishScreen
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject completeImage;
    public GameObject radialShine;
    public GameObject coin;
    public GameObject rewardedButton;
    public GameObject noButton;
    public GameObject achievedCoin;
    public GameObject nextLevel;
    public Text achievedCoinText;

    //Level

    public Image fillRateImage;



    private void Start()
    {
        if(PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if(PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        
         if(PlayerPrefs.GetInt("NoAds") == 1)
        {
            NoAdsRemove();
        }


        if (PlayerPrefs.GetInt("Sound")==1)
        {
            soundOff.gameObject.SetActive(false);
            soundOn.gameObject.SetActive(true);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOff.gameObject.SetActive(false);
            vibrationOn.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.gameObject.SetActive(false);
            vibrationOff.gameObject.SetActive(true);
        }

        coinTextUpdate();
    }


    private void Update()
    {
        if (radialShine == true)
        {
            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 40f * Time.deltaTime));
        }

        fillRateImage.fillAmount = ((Player.transform.position.z*100) / (finishLine.transform.position.z))/100;
    }

    public void FirstTouch()
    {
        introHand.SetActive(false);
        toptopMoveTxt.SetActive(false);
        noAdsButton.SetActive(false);
        shopButton.SetActive(false);
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        soundOn.SetActive(false);
        soundOff.SetActive(false);
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(false);
        iad.SetActive(false);
        information.SetActive(false);
        
    }

    public void NoAdsRemove()
    {
        noAdsButton.SetActive(false);
    }


    public void coinTextUpdate()
    {
        coinText.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        restartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void NextScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.3f;
        isRadialShine = true;
        finishScreen.gameObject.SetActive(true);
        blackBackground.gameObject.SetActive(true);
        sounds.CompletedSound();
        yield return new WaitForSecondsRealtime(0.5f);
        completeImage.gameObject.SetActive(true);
        radialShine.gameObject.SetActive(true);
        coin.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        rewardedButton.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        noButton.gameObject.SetActive(true);

    }


    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedCoinText.gameObject.SetActive(true);
        rewardedButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        
        for (int i = 0; i <= 400; i += 4)
        {
            achievedCoinText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
        

       
        
        

        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);

       

    }

    public void Privacy_Policy()
    {
        Application.OpenURL("https://github.com/smtzengin");
    }


    //Button functions
    

    public void SettingsOpen()
    {
        settingsOpen.gameObject.SetActive(false);
        settingsClose.gameObject.SetActive(true);
        anim.SetTrigger("openTrigger");
    }
    public void SettingsClose()
    {
        settingsClose.gameObject.SetActive(false);
        settingsOpen.gameObject.SetActive(true);  
        anim.SetTrigger("closeTrigger");

    }


    public void SoundOn()
    {
        soundOn.gameObject.SetActive(false);
        soundOff.gameObject.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
        
    }

    public void SoundOff()
    {
        soundOff.gameObject.SetActive(false);
        soundOn.gameObject.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void VibrationOn()
    {
        vibrationOn.gameObject.SetActive(false);
        vibrationOff.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void VibrationOff()
    {
        vibrationOff.gameObject.SetActive(false);
        vibrationOn.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }










    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);

        while (effectControl == 0) 
        {
            yield return new WaitForSeconds(0.001f);

            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);

            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r,whiteEffectImage.color.g,whiteEffectImage.color.b,1f))
            {
                effectControl = 1;
            }
        }

        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.1f);

            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);

            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 0f))
            {
                
                effectControl = 2;
            }
        }

        if(effectControl == 2)
        {
            Debug.Log("Kontrol bitti.");
        }


    }
}
