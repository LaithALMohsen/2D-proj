using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CoreSystem;
public class PlayerLedgeClimbState : PlayerState
{

    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }


    private Movement movement;
    private CollisionSenses collisionSenses;
    private Vector2 detectedPos;
    private Vector2 corenerPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private Vector2 workSpace;



    private bool isHanging;
    private bool isClimbing;
    private bool jumpInput;
    private bool isTouchingCeiling;


    private int xInput;
    private int yInput;
         
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        isHanging = true;
        player.Anim.SetBool("ClimbLedge", false);
    }

    public override void Enter()
    {
        base.Enter();

       Movement?.SetVelocityZero();
        player.transform.position = detectedPos;


       
       corenerPos = DetermineCornerPosition();

        startPos.Set(corenerPos.x - (Movement.FacingDirection * playerData.startOffset.x), corenerPos.y - playerData.startOffset.y);
        stopPos.Set(corenerPos.x + (Movement.FacingDirection * playerData.stopOffset.x), corenerPos.y + playerData.stopOffset.y);


        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();
        isHanging = false;

        if (isClimbing)
        {

            player.transform.position = stopPos;
            isClimbing = false; 
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isTouchingCeiling)
            {

                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);

            }
          
        }
        else {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;


            Movement?.SetVelocityZero();
            player.transform.position = startPos;



            if (xInput == Movement?.FacingDirection && isHanging && !isClimbing)
            {

                CheckForSpace();
                isClimbing = true;
                player.Anim.SetBool("ClimbLedge", true);

            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {

                stateMachine.ChangeState(player.InAirState);
            }
            else if (jumpInput && !isClimbing)
            {
                player.WallJumpState.DetermineWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }

        }


    }

    public void SetDetectedPostion(Vector2 pos) => detectedPos = pos;

    private void CheckForSpace()
    {
        isTouchingCeiling = Physics2D.Raycast(corenerPos + (Vector2.up * 0.015f) + (Vector2.right * Movement.FacingDirection * 0.015f),Vector2.up,playerData.standColliderHeight, CollisionSenses.WhatIsGround);
        player.Anim.SetBool("isTouchingCeiling", isTouchingCeiling);
    }

    private Vector2 DetermineCornerPosition()
    {

        RaycastHit2D xHit = Physics2D.Raycast(CollisionSenses.WallCheck.position, Vector2.right * Movement.FacingDirection, CollisionSenses.WallCheckDistance,CollisionSenses.WhatIsGround);
        float xDist = xHit.distance;
        workSpace.Set((xDist + 0.015f) * Movement.FacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(CollisionSenses.LedgeCheckHorizontal.position + (Vector3)(workSpace), Vector2.down, CollisionSenses.LedgeCheckHorizontal.position.y -CollisionSenses.WallCheck.position.y + 0.015f, CollisionSenses.WhatIsGround);
        float yDist = yHit.distance;

        workSpace.Set(CollisionSenses.WallCheck.position.x + (xDist *Movement.FacingDirection), CollisionSenses.LedgeCheckHorizontal.position.y - yDist);

        return workSpace;
    }
}
