using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class E2_DodgeState : DodgeState
{
  private   Enemy2 enemy; 
    public E2_DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DodgeState dodgeState, Enemy2 enemy) : base(entity, stateMachine, animBoolName, dodgeState)
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
        if (isDodgeOver)
        {
            if(isPlayerisMaxAgroRange && performCloseRangeAction)
            {

                stateMachine.ChangeState(enemy.meleAttackState);
            }
            else if (isPlayerisMaxAgroRange && !performCloseRangeAction)
            {

                stateMachine.ChangeState(enemy.rangeAttackState);
            }
            else if (!isPlayerisMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
           
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
