using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] wavePrefabs;
    // Start is called before the first frame update

    private Transform playerTransform;
    private float waveLength = 19.0f * 10;
    private float spawnZ = 0.0f;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z > spawnZ)
        {
            SpawnWave();
        }
    }

    private void SpawnWave(int prefabIndex = -1)
    {
        GameObject wave;
        wave = Instantiate(wavePrefabs[0]) as GameObject;
        wave.transform.SetParent(transform);
        wave.transform.position = new Vector3(0, -10, spawnZ);
        spawnZ += waveLength;
      

    }

}
