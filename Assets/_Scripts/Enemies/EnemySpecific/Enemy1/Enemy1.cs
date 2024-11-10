using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveSate moveSate { get; private set; }

    public E1_PlayerDetectedState playerDetectedState { get; private set;  }

    public E1_ChagreState chargeState { get; private set;  }

    public E1_LookForPlayerState lookForPlayerState { get; private set; }

    public E1_MeleAttackState meleAttackState { get; private set; }

    public E1_StunState stunState { get; private set;  }
    public E1_DeadState deadState { get; private set; }
          



    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleAttack meleAttackStateData;
    [SerializeField]
    private Transform meleAttackPosition;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;


    public override void Awake()
    {
        base.Awake();

        moveSate = new E1_MoveSate(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "playerDetected",playerDetectedData, this);
        chargeState = new E1_ChagreState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleAttackState = new E1_MeleAttackState(this, stateMachine, "meleAttack", meleAttackPosition, meleAttackStateData,this);
        stunState = new E1_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "dead", deadStateData, this);

        stats.Poise.OnCurrentValueZero += HandlePoiseZero;
    }

    protected void HandlePoiseZero()
    {


        stateMachine.ChangeState(stunState);
    }
    private void Start()
    {
        stateMachine.Initialized(moveSate);
        
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
