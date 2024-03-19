using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDesState : IState
{
    public void OnEnter(Enemy enemy)
    {

    }
    public void OnExecute(Enemy enemy)
    {
        if(enemy.brickStack.Count>0)
        {
            enemy.navMesh.SetDestination(Map.Instance.finishPoint.position);
        }
        else
        {
            enemy.ChangeState(new CollectState());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
