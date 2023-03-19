using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.MoveToward(t.movePos);

    }

    public void OnExecute(Character t)
    {
        if(Vector3.Distance(t.transform.position , t.movePos.position) < 1)
        {
            t.ChangeState(new IdleState());
            
        }
        
    }

    public void OnExit(Character t)
    {

    }

}
