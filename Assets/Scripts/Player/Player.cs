using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    

    //Color -------------------------
    public SkinnedMeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor = ColorType.Blue;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SkinnedMeshRenderer>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ChangeColor(ren,ColorType.Red);
            
        }
    }

    void ChangeColor(SkinnedMeshRenderer ren , ColorType color) 
    {
        ren.material = colorData.GetColor(color);
        currentColor = color;
    }
    void ChangeRandomColor(SkinnedMeshRenderer ren)
    {
        int i = Random.Range(1, 7);
        
        ren.material = colorData.GetColor((ColorType)i);
        currentColor = (ColorType)i;
    }



}
