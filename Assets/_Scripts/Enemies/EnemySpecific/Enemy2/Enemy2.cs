using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
  public E2_MoveState moveState { get; private set;  }

    public E2_idleState idleState { get; private set; }

    public E2_playerDetectedState playerDetectedState { get; private set; }
    public E2_MeleAttackState meleAttackState { get; private set; }

    public E2_lookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }

    public E2_DeadState deadState { get; private set; }

    public E2_DodgeState dodgeState { get; private set; }

    public E2_RangeAttackState rangeAttackState { get; private set; }


    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleAttack meleAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangeAttackState rangeAttackStateData; 

    [SerializeField]
    private Transform meleAttackPosition;
    [SerializeField]
    private Transform rangeAttackPos; 

   public override void Awake()
    {
        base.Awake();
         
        moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_idleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E2_playerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleAttackState = new E2_MeleAttackState(this, stateMachine, "meleAttack", meleAttackPosition,meleAttackStateData, this);
        lookForPlayerState = new E2_lookForPlayerState(this, stateMachine, "loolForPlayer", lookForPlayerStateData, this);
        stunState = new E2_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E2_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new E2_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangeAttackState = new E2_RangeAttackState(this, stateMachine, "rangeAttack",rangeAttackPos, rangeAttackStateData, this);
        stats.Poise.OnCurrentValueZero += HandlePoiseZero;
    }

    protected void HandlePoiseZero()
    {


        stateMachine.ChangeState(stunState);
    }
    private void Start()
    {
        stateMachine.Initialized(moveState);
        
    }

    private void OnDestroy()
    {
        stats.Poise.OnCurrentValueZero -= HandlePoiseZero;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleAttackPosition.position, meleAttackStateData.attackRadius);
    }
}   
