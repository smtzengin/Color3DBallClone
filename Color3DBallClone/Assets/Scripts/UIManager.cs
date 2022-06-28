using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectControl;
    public Animator anim;

    //Buttons

    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;


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
    }

    public void SoundOff()
    {
        soundOff.gameObject.SetActive(false);
        soundOn.gameObject.SetActive(true);       
    }
    public void VibrationOn()
    {
        vibrationOn.gameObject.SetActive(false);
        vibrationOff.gameObject.SetActive(true);
    }

    public void VibrationOff()
    {
        vibrationOff.gameObject.SetActive(false);
        vibrationOn.gameObject.SetActive(true);       
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
