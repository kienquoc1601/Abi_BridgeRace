using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    
    public void OnEnter(Character t)
    {
        
    }

    public void OnExecute(Character t)
    {
        if(t.brickCount > 10)
        {
            t.ChangeState(new AttackState());
        }
        if(t.brickPool.Count > 0)
        {
            int ran = Random.Range(0, t.brickPool.Count);
            t.movePos = t.brickPool[ran];
            t.ChangeState(new PatrolState());
            
        }
        
        
    }

    public void OnExit(Character t)
    {

    }

}
