using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;
    public float distanceBetwenCoins;
    public void SpawnCoins(Vector3 startPosition )
    {
        float count = Random.Range(1, 4);

            if (count == 1)
        {
            GameObject coin1 = coinPool.GetPooledObject();
            coin1.transform.position = startPosition;
            coin1.SetActive(true);
        }
        if (count == 2)
        {
            GameObject coin2 = coinPool.GetPooledObject();
            coin2.transform.position = new Vector3(startPosition.x - distanceBetwenCoins, startPosition.y, startPosition.z);
            coin2.SetActive(true);
            GameObject coin3 = coinPool.GetPooledObject();
            coin3.transform.position = new Vector3(startPosition.x + distanceBetwenCoins, startPosition.y, startPosition.z);
            coin3.SetActive(true);
        }
        if (count == 3)
        {
            GameObject coin1 = coinPool.GetPooledObject();
            coin1.transform.position = startPosition;
            coin1.SetActive(true);            
            GameObject coin2 = coinPool.GetPooledObject();
            coin2.transform.position = new Vector3(startPosition.x - distanceBetwenCoins, startPosition.y, startPosition.z);
            coin2.SetActive(true);
            GameObject coin3 = coinPool.GetPooledObject();
            coin3.transform.position = new Vector3(startPosition.x + distanceBetwenCoins, startPosition.y, startPosition.z);
            coin3.SetActive(true);
        }      
    }
}
