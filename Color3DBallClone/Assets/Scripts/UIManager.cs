using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   

    public Image whiteEffectImage;
    private int effectControl;
    public Animator anim;

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

    public GameObject restartScreen;


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
