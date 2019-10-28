using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManger : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    // Start is called before the first frame update

    private Transform playerTransform;

    private ArrayList groundList = new ArrayList();

    private float spawnZ = 0.0f;
    private float groundLength = 7.6f;
    private int amnTilesOnScreen = 3;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        System.Random random = new System.Random();
        int x = random.Next(groundPrefabs.Length);
        for (int i = 0; i < amnTilesOnScreen; i++)
        { 
            // Blank ground
            SpawnGround(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        System.Random random = new System.Random();
        int x = random.Next(1,groundPrefabs.Length);
        if (playerTransform.position.z > (spawnZ - amnTilesOnScreen * groundLength))
        {
            SpawnGround(x);
        }
        if(groundList.Count > 20)
        {
            for(int i = 0; i < 5; i++)
            {
                DestroyGround(i);
            }
        }
    }

    private void SpawnGround(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(groundPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLength;
        groundList.Add(go);

    }

    private void DestroyGround(int index)
    {
        Destroy((Object)groundList[index]);
        groundList.RemoveAt(index);
    }
}
