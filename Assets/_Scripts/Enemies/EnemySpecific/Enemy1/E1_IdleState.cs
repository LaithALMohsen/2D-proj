using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enmey;


    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_IdleState stateData,Enemy1 enmey) : base(entity, stateMachine, animBoolName,stateData)
    {
        this.enmey = enmey;


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
            stateMachine.ChangeState(enmey.playerDetectedState);

        }


       else if (isIdleTimeOver)
        {

            stateMachine.ChangeState(enmey.moveSate);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
