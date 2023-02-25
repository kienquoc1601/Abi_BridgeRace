using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawnPrefab : MonoBehaviour
{

    public GameObject[] prefabList;
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }
    void SpawnGrid()
    {
        for(int x=0;x < gridX; x++)
        {
            for(int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                SpawnByIndex(spawnPosition, Quaternion.identity, 0 );
                //SimplePool.Spawn<Brick>(PoolType.Brick, spawnPosition, Quaternion.identity).OnInit();
            }
        }
    }
    // Update is called once per frame
    void SpawnByIndex(Vector3 pos , Quaternion rotation , int index)
    {
        //GameObject clone = Instantiate(prefabList[index], pos, rotation);
        SimplePool.Spawn<Brick>(PoolType.Brick, pos, rotation).OnInit();
        
    }
}
