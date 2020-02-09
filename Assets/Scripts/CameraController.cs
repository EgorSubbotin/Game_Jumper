using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerCntroller thePlayer;
    Vector3 lastPlayerPosition;
    float distanceToMove;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerCntroller>();
        lastPlayerPosition = thePlayer.transform.position;
    }    
    void Update()
    {
        distanceToMove= thePlayer.transform.position.x- lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x+ distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }
}
