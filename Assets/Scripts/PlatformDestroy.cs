using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{  
    GameObject platformDestructionPoint;   
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }    
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Debug.Log(platformDestructionPoint.transform.position.x);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
