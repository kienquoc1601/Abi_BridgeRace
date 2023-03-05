using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : GameUnit
{
    public MeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor;
    //private List<ColorType> colorPool = new List<ColorType>();
    // Start is called before the first frame update
    public void OnInit()
    {
        InvisibleState();
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public void ChangeRandomColor(List<ColorType> colorPool)
    {
        
        int i = Random.Range(0, colorPool.Count);
        ren.material = colorData.GetColor(colorPool[i]);
        currentColor = colorPool[i];
    }
    public void InvisibleState()
    {
        ren.material = colorData.GetColor(ColorType.Invisible);
        currentColor = ColorType.Invisible;
    }
    //public void PickUp()
    //{
    //    ren.material = colorData.GetColor(ColorType.Invisible);
    //    currentColor = ColorType.Invisible;
    //}

}
