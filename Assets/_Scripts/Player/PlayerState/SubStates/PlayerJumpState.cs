using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAblityState
{

    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft -= playerData.amountOfJump; 
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        Movement?.SetVelocityY(playerData.jumpVelocity);

        isAblityDone = true;

        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();
    }

    public bool canJump()
    {

        if(amountOfJumpsLeft > 0 )
        {

            return true; 
        }
        else
        {
            return false; 
        }
    }
    public void ResetAmountOfJumpsLaft() => amountOfJumpsLeft = playerData.amountOfJump;

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
