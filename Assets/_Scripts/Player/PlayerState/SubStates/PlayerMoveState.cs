using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        Movement?.checkIfshouldFlip(xinput);


        Movement?.SetVelocityx(playerData.movementVelocity * xinput);

        if (!isExitingState)
        {

            if(xinput == 0 )
            {

                stateMachine.ChangeState(player.IdleState);
            }
            else if (yInput == -1)
            {

                stateMachine.ChangeState(player.CrouchMoveState);
            }

        }

    }

    public override void physicsUpdate()
    {
        base.physicsUpdate();
    }
}
