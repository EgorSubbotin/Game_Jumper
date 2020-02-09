using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //public GameObject thePlatform;
    public Transform generationPoint;
    float distanceBetwen;      
    public float distanceBetwenMin;
    public float distanceBetwenMax;

    public ObjectPooler[] theObjectPoolers;
   // public GameObject[] thePlatforms;
    int platformSelector;
    float[] platformWidths;

    float minHeight;
    public Transform maxHeightPoint;
    float maxHeight;
    public float maxHeightChange;
    float HeightChange;

    CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths=new float [theObjectPoolers.Length];
        for (int i=0;i< theObjectPoolers.Length; i++)
        {
            platformWidths[i] = theObjectPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
           
            distanceBetwen = Random.Range(distanceBetwenMin, distanceBetwenMax);
            platformSelector = Random.Range(0, theObjectPoolers.Length);
            HeightChange=transform.position.y+ Random.Range(maxHeightChange,-maxHeightChange);
            if (HeightChange> maxHeight)
            {
                HeightChange = maxHeight;
            }
            else if (HeightChange < minHeight)
            {
                HeightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])/2 + distanceBetwen, HeightChange, transform.position.z);
            // Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPoolers[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if (Random.Range(0,100) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]) / 2 , transform.position.y, transform.position.z);

        }
    }

}
