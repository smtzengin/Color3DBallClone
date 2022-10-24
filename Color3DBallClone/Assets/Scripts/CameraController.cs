using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    
    [SerializeField] float smoothness = 0.3f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothness);
    }



}
