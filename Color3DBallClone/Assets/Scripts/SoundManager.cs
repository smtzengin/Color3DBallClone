using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource blowUpSource;
    public AudioSource completedSource;
    public AudioSource objectHitSource;


    public AudioClip buttonClip;
    public AudioClip blowUpClip;
    public AudioClip completedClip;
    public AudioClip objectHitClip;


    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip);
    }
    public void BlowUpSound()
    {
        blowUpSource.PlayOneShot(blowUpClip);
    }
    public void CompletedSound()
    {
        completedSource.PlayOneShot(completedClip);
    }
    public void ObjectHitSound()
    {
        objectHitSource.PlayOneShot(objectHitClip);
    }
}
