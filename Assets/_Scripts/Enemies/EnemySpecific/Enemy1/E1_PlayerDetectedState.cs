using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetecteState
{
    private Enemy1 enemy;



    public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData,Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    
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
        if (performCloseRangeAction)
        {

            stateMachine.ChangeState(enemy.meleAttackState);

        }

        else  if (performLongRangeAction)
        {
       
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {

            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

        else if (!isDetectingLedge)
        {
           Movement?.Flip();
            stateMachine.ChangeState(enemy.moveSate);
        }
     
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
