using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CoreSystem;
public class StunState : State
{
    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }


    private Movement movement;
    private CollisionSenses collisionSenses;
    protected D_StunState stateData ;


    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovmentStopped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;

    public StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData ;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = CollisionSenses.Ground;
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        isMovmentStopped = false; 
      Movement?.SetVelocity(stateData.stunKnockbackSpeed, stateData.stunKnockbackAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetStunResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime  + stateData.stunTime)
        {
            isStunTimeOver = true;

        }
        if(isGrounded && Time.time >= startTime + stateData.stunKnockbackTime && !isMovmentStopped)
        {
            isMovmentStopped = true; 
           Movement?.SetVelocityx(0f);
        }
    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
