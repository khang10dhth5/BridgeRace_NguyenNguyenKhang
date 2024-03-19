using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public int countBrick;
    public NavMeshAgent navMesh;

    [HideInInspector] public Transform target;

    private IState currentState;
    public override void Start()
    {
        base.Start();
        Onit();
    }
    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public override void Onit()
    {
        base.Onit();
        currentState = new IdleState();
    }
    public void StopMoving()
    {
        ChangeAmin(AminState.idle.ToString());
    }
    public void CollectBrick()
    {
        ChangeAmin(AminState.run.ToString());
        if(currentStage.GetBrick(colorType)!=null)
        {
            navMesh.SetDestination(currentStage.GetBrick(colorType).position);
        }
        else
        {
            ChangeState(new IdleState());
        }
    }
    public void ChangeState(IState newState)
    {
       if (currentState != null)
       {
          currentState.OnExit(this);
       }
       currentState = newState;
       if (currentState != null)
       {
          currentState.OnEnter(this);
       }
    }

}
