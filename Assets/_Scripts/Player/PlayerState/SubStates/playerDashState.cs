using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDashState : PlayerAblityState
{

    public bool canDash { get; private set;  }
    private bool isHolding;
    private bool dashInputStop;

    private float lastDashTime;


    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 lastAIPos;

    public playerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();


        canDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * Movement.FacingDirection;

        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime;

        player.DashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        if(Movement?.CurrentVelocity.y > 0)
        {

            Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState) 
        {
            player.Anim.SetFloat("yvelocity", Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xvelocity", Mathf.Abs(Movement.CurrentVelocity.x));


            if (isHolding)
            {
                dashDirectionInput = player.InputHandler.DashDirectionInput;
                dashInputStop = player.InputHandler.DashInputStop;

                if(dashDirectionInput != Vector2.zero)
                {

                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }
                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if(dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {

                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                   Movement?.checkIfshouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.Rb.drag = playerData.drag;
                   Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {

                Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
                checkIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.dashTime)
                {

                    player.Rb.drag = 0f;
                    isAblityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }

    private void checkIfShouldPlaceAfterImage()
    {

        if(Vector2.Distance(player.transform.position,lastAIPos) >= playerData.distBetweenAfterImages)
        {

            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        PlayerAfterImgPool.Instance.GetFromPool();
        lastAIPos = player.transform.position;

    }


    public bool CheckIfCanDash()
    {

        return canDash && Time.time >= lastDashTime + playerData.dashCoolDown;
    }
    public void ResetCanDash() => canDash = true;

}
