using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MoveState : MoveState
{

    private Enemy2 enemy; 
    public E2_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy; 
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
      else  if(isDetectingWall || !isDetectingLedge)
        {

            enemy.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
