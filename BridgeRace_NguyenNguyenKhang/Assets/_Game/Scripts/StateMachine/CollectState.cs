using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : IState
{

    public void OnEnter(Enemy enemy)
    {

    }
    public void OnExecute(Enemy enemy)
    { 
        if (enemy.brickStack.Count<6)
        {
            enemy.CollectBrick();
           
        }
        else
        {
            enemy.ChangeState(new MoveDesState());
        }

    }
    public void OnExit(Enemy enemy)
    {

    }
}
