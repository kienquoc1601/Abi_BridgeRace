using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : GameUnit
{
    public MeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor = ColorType.Invisible;

    public void OnInit()
    {
        ren = GetComponent<MeshRenderer>();
        ren.material = colorData.GetColor(ColorType.Invisible);
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
    public void BuildStair(ColorType color)
    {
        ren.material = colorData.GetColor(color);
        currentColor = color;
    }

}
