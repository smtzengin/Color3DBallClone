using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CameraShake camShake;
    public GameObject vectorBack;
    public GameObject vectorForward;
    public UIManager uiManager;

    private Touch _touch;

    [Range(0.5f,2f)]
    public float speedModifier;

    public float forwardSpeed;

    private Rigidbody rb;

    public GameObject[] FractureItems;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if(Variables.firstTouch == 1)
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
                Variables.firstTouch = 1;
            }

            else if(_touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(_touch.deltaPosition.x * speedModifier, 
                                           transform.position.y, 
                                           _touch.deltaPosition.y * speedModifier);
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

            
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                
            }

        }
    }

   
}
