using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyPadSpawner_Logic : MonoBehaviour
{
    public int maxSpawnCount;
    public int minSpawnCount;
    public float spawnTime = 12f;
    private float spawnTimeModifier = .1f;
    private float spawnTimer = 0f;
    public Transform[] spawnPoints;
    public int[] spawnPointTracker;
    private int spawnPointCount;
    public GameObject lilyPadPrefab;
    public bool RunStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = gameObject.GetComponentsInChildren<Transform>();
        spawnPointCount = spawnPoints.Length;
        spawnPointTracker = new int[spawnPointCount];
    }

    private void OnEnable()
    {
        EventManager.pressedPlay += StartRun;
    }

    private void StartRun()
    {
        RunStarted = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (RunStarted)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > spawnTime * spawnTimeModifier)
            {
                spawnTimer = 0;
                SpawnLilyPads(Random.Range(minSpawnCount, maxSpawnCount));
            }
        }
    }



    private void SpawnLilyPads(int spawnCount)
    {
        int missCounter = 0;
        int spawnPointIndex = 0;
        bool lilyPadSpawned = false;

        for(int i = 0; i<spawnCount; i++)
        {
            lilyPadSpawned = false;
            spawnPointIndex = Random.Range(0, 6);

            var tempObject = Instantiate(lilyPadPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            //Debug.Log("Counter: " + i + ",  SpawnPointIndex: " + spawnPointIndex + ", spawnPoints[spawnPointIndex].position:" + spawnPoints[spawnPointIndex].position);
            /*
            while (!lilyPadSpawned)
            {
                if (spawnPointTracker[spawnPointIndex] == 0)
                {
                    Debug.Log("Counter: " + i + ",  SpawnPointIndex: " + spawnPointIndex);
                    var tempObject = Instantiate(lilyPadPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    spawnPointTracker[spawnPointIndex] = 1;
                    lilyPadSpawned = true;
                }
                else
                {
                    Debug.Log("Miss");
                    if (missCounter > 10)
                    {
                        i = spawnCount + 1;
                    }
                }

            }*/
        }

        //foreach(int j in spawnPointTracker)
        //{
        //    spawnPointTracker[j] = 0;
        //}
    }


}
