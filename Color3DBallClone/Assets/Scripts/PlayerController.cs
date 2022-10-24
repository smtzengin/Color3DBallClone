using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CameraShake camShake;
    public GameObject vectorBack;
    public GameObject vectorForward;
    public UIManager uiManager;
    public SoundManager sounds;
    
    private Touch _touch;

    [Range(0.3f,2f)]
    public float speedModifier;

    public float forwardSpeed;

    private Rigidbody rb;

    public GameObject[] FractureItems;

    private bool speedBallForward = false;
    private bool firstTouchControl = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if(Variables.firstTouch == 1 && speedBallForward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime); 
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime+5);
        }



        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if(_touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uiManager.FirstTouch();
                        firstTouchControl = true;
                    }
                   
                }    
            }

            else if(_touch.phase == TouchPhase.Moved)
            {

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // parmaðýmýz canvas elemanlarý üzerinde deðil ise
                {
                    rb.velocity = new Vector3(_touch.deltaPosition.x * speedModifier,
                           transform.position.y,
                           _touch.deltaPosition.y * speedModifier);

                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uiManager.FirstTouch();
                        firstTouchControl = true;
                    }

                }
            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
        {

            camShake.CameraShakesCall();
            uiManager.StartCoroutine("WhiteEffect");   

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            sounds.BlowUpSound();
            if(PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
            }
            else if (PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("olmaz...");
            }

            
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                
            }
            StartCoroutine("TimeScaleControl");
             
        }
    }

    public IEnumerator TimeScaleControl()
    {
        speedBallForward = true;
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(0.6f);
        uiManager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }
   
   
}
