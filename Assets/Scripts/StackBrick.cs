using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBrick : MonoBehaviour
{
    public MeshRenderer ren;
    public ColorData colorData;
    // Start is called before the first frame update
    public void OnInit()
    {
        ren = GetComponent<MeshRenderer>();
        
    }
    public void OnDespawn()
    {
        //SimplePool.Despawn(this);
    }

    //void ChangeColor(MeshRenderer ren , ColorType colorType)
    //{
    //    int i = Random.Range(1, 7);
    //    ren.material = colorData.GetColor(colorType);
    //}
    
}
