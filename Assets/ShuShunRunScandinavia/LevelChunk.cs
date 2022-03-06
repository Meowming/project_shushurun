using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour
{
    public float chunkWidth = 50f;
    public Transform[] buildingLocations;
    public Transform[] obstacleLocations;
    public Transform[] billboardLocations;

    public GameObject[] buildingPrefabs;
    public GameObject[] obstaclePrefabs;
    public GameObject[] billboardPrefabs;

    public void GenerateChunk()
    {
        foreach (Transform building in buildingLocations)
        {
            Instantiate(buildingPrefabs[Random.Range(0, buildingPrefabs.Length - 1)],building.transform.position,building.transform.rotation,this.transform);
        }
    }
    public void OnDrawGizmos()
    {
        if (buildingLocations == null)
        {
            return;
        }
        foreach (Transform building in buildingLocations)
        {
            Vector3 buildingSize = new Vector3(10f, 3f, 6f);
            Gizmos.DrawWireCube(building.transform.position, buildingSize);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
