using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    

    //Color -------------------------
    public SkinnedMeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor = ColorType.Red;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(ren, currentColor);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor(SkinnedMeshRenderer ren , ColorType color) 
    {
        ren.material = colorData.GetColor(color);
        currentColor = color;
    }
    



}
