using System.Collections.Generic;
using UnityEngine;

public class GridSpawnPrefab : MonoBehaviour
{

    public List<Brick> bricks = new List<Brick>();
    private List<ColorType> colorPool = new List<ColorType>();
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 startPos;
    public Vector3 gridOrigin = Vector3.zero;
    public int group;

    //timer
    public float timer = 0f;
    public float updateTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        colorPool.Add(ColorType.Invisible);
        startPos = this.gameObject.transform.position;
        SpawnGrid();
        RandomizeGridColor();

    }
    private void Update()
    {
        timer +=  Time.deltaTime; 
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log(colorPool.ToString());
            //Debug.Log(colorPool.Count);
            UpdateGridColor();
        }
        if(timer >= updateTime)
        {
            
            UpdateGridColor();
            timer = 0;
        }
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + startPos;
                SpawnByIndex(spawnPosition, Quaternion.identity, 0);
                
            }
        }
    }
    void RandomizeGridColor()
    {
        for(int i = 0; i < bricks.Count; i++)
        {
            
            if (bricks[i].currentColor == ColorType.Invisible)
            {
                bricks[i].ChangeRandomColor(colorPool);
            }
            
        }
    }
    void UpdateGridColor()
    {
        for (int i = 0; i < bricks.Count; i++)
        {
            int ran = Random.Range(0, 10);
            if (bricks[i].currentColor == ColorType.Invisible)
            {
                if(ran <= 3)
                {
                    bricks[i].ChangeRandomColor(colorPool);
                }
                
            }

        }
    }
    // Update is called once per frame
    void SpawnByIndex(Vector3 pos, Quaternion rotation, int index)
    {
        Brick brick = SimplePool.Spawn<Brick>(PoolType.Brick, pos, rotation);
        brick.OnInit();
        bricks.Add(brick);
    }
    public List<Brick> GetAllBrickByColor(ColorType color)
    {
        List<Brick> colorBricks = new List<Brick>();
        for(int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].currentColor == color)
            {
                colorBricks.Add(bricks[i]);
            }
        }
        return colorBricks;
    }
    public List<Transform> GetAllBrickTranformByColor(ColorType color)
    {
        List<Transform> colorBricks = new List<Transform>();
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].currentColor == color)
            {
                colorBricks.Add(bricks[i].transform);
            }
        }
        return colorBricks;
    }
    public void AddColorToPool(ColorType color)
    {
        if (!colorPool.Contains(color))
        {
            colorPool.Add(color);
        }
        
    }
}
