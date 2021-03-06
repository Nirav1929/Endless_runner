using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; 
    private Transform platerTransform;
private float spawnz = 0.0f;
    private float tileLength = 10.0f;
    private int TilesOnScreen = 10;
    private float safeZone = 20.0f;
    private int lastPrefab = 0;

    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    private void Start()
    {
        activeTiles = new List<GameObject>();
        platerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i=0; i<TilesOnScreen; i++)
        {
            if (i<3)
                SpawnTile(0);
            else
            
                SpawnTile();
        }       
    }

    // Update is called once per frame
    private void Update()
    {
        if (platerTransform.position.z - safeZone> (spawnz - 7 * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate (tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent (transform);

        go.transform.position =  Vector3.Scale(Vector3.one,  new Vector3(16.1f, 0.0f, spawnz));
        spawnz += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy (activeTiles[0]);
        activeTiles.RemoveAt(0);  
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefab;
        while (randomIndex == lastPrefab)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefab = randomIndex;
        return randomIndex;
    }
}
