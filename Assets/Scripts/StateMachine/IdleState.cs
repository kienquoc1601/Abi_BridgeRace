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
        Debug.Log("idle");
        if (t.brickCount > 30)
        {
            t.currentGrid++;
            t.ChangeState(new AttackState());
        }
        else if (t.brickPool.Count > 0)
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
