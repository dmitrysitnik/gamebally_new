using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject[] items;
    public float startWait;
    public float spawnWait;
    public Vector3 spawnPosition;
    private GameObject item;
    // Use this for initialization
    void Start () {
       // GameObject gameObject = GameObject.FindGameObjectWithTag("ground");
        transform.localScale = SetScaleGround();
        StartCoroutine(SpawnItem());
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    Vector3 SetScaleGround()
    {
        float randomSize = Random.Range(20.0f, 45.0f);
        return new Vector3(randomSize, 0.1f, randomSize);
    }

    Vector3 GetSpawnPosition()
    {
        bool isRight = false;
        float randomAxiesX = Random.Range(-transform.localScale.x, transform.localScale.x);
        float randomAxiesZ = Random.Range(-transform.localScale.z, transform.localScale.z);
        while (!isRight)
        {
           isRight =  (Mathf.Pow(randomAxiesX, 2) + Mathf.Pow(randomAxiesZ, 2)) <= Mathf.Pow(transform.localScale.x / 2, 2 );
            if (!isRight)
            {
                randomAxiesX = Random.Range(-transform.localScale.x, transform.localScale.x);
                randomAxiesZ = Random.Range(-transform.localScale.z, transform.localScale.z);
            }
        }
        return new Vector3(randomAxiesX, 0.7f, randomAxiesZ );
    }

    IEnumerator SpawnItem()
    {

        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 1; i<11; i++)
            { 
                spawnPosition = GetSpawnPosition();
                item = PickUpItem();
                Instantiate(item , spawnPosition, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(spawnWait);
        }
         
        }

    public static IEnumerator Win()
    {
        yield return new WaitForSeconds(10.0f);
        PlayerController.RestartLevel();
    }

    

   public GameObject PickUpItem ()
    {
        GameObject item = items[Random.Range(0,items.Length)];
        return item;
    }

    
}
