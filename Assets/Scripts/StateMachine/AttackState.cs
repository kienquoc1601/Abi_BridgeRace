using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Character>
{
    public void OnEnter(Character t)
    {
        //Debug.Log("asdsada");
        
        GameObject g = GameObject.Find("PlatformTrigger" + t.currentGrid);
        if (g != null)
        {
            t.movePos = g.transform;
            t.MoveToward(g.transform);
        }
        else
        {
            t.movePos = GameObject.Find("FinishLine").transform;
            t.MoveToward(GameObject.Find("FinishLine").transform);
        }
    }

    public void OnExecute(Character t)
    {
        
    }

    public void OnExit(Character t)
    {
        
        
    }

}
