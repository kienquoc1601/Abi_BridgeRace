using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : GameUnit
{
    public MeshRenderer ren;
    public ColorData colorData;
    public ColorType currentColor;
    // Start is called before the first frame update
    public void OnInit()
    {
        ren = GetComponent<MeshRenderer>();
        ChangeRandomColor(ren);
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    void ChangeRandomColor(MeshRenderer ren)
    {
        int i = Random.Range(1, 7);
        ren.material = colorData.GetColor((ColorType)i);
        currentColor = (ColorType)i;
    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.tag == "Player")
        {        
            if (other.GetComponent<Player>().currentColor == currentColor)
            {
                Debug.Log("aaa");
                ren.material = colorData.GetColor(ColorType.Invisible);
                currentColor = ColorType.Invisible;
            }
        }
    }
}
