using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Bot : MonoBehaviour
{


    //Color -------------------------
    public SkinnedMeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor = ColorType.Red;
    public bool isKnocked = false;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(ren, currentColor);

    }
    public IEnumerator KnockDown()
    {
        isKnocked = true;
        Debug.Log("Bot : Ouch");
        yield return new WaitForSeconds(2f);
        isKnocked = false;

    }
    
    void ChangeColor(SkinnedMeshRenderer ren, ColorType color)
    {
        ren.material = colorData.GetColor(color);
        currentColor = color;
    }

}

