using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public Stair stairPrefab;
    public Transform stairParent;
    public List<Stair> stairs = new List<Stair>();
    public int stack = 1;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < stack; i++)
        {
            Vector3 pos = new Vector3(0, 0, i * -0.5f);
            SimplePool.Spawn<Stair>(PoolType.Stair,pos , Quaternion.identity, stairParent).OnInit();
            
        }
        
    }
}
 