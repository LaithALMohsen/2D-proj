using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Assets.CoreSystem;
public class Entity : MonoBehaviour
{
    protected Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }


    private Movement movement;

    public D_entity entityData;


    public FiniteStateMachine stateMachine;
  
    public Animator anim { get; private set; }


    public AnimationToStateMachin atsm { get; private set; }

    public int lastDamageDirection { get; private set; }

    public Core Core { get; private set; }


    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;

    private Vector2 velocityWorkSpace;

    private float currentHealth;
    private float currentStunResistance;
    private float lastDamageTime;

    protected bool IsStunned;
    protected bool isDead;


    protected Stats stats;
  

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        stats = Core.GetCoreComponent<Stats>();
        currentHealth = entityData.maxHealth;
        currentStunResistance = entityData.stunResistance;

       
    
        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachin>();

        stateMachine = new FiniteStateMachine();


    }

    public virtual void Update()
    {

        Core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();

        anim.SetFloat("yVelocity", Movement.Rb.velocity.y);
        if (Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {

            ResetStunResistance();
        }

    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    
    }
  
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position,transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);

    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {

        return Physics2D.Raycast(playerCheck.position,transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);


    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position,transform.right, entityData.closeRangeActionDistance , entityData.whatIsPlayer);
    }
    public virtual void DamageHop(float velocity)
    {
        velocityWorkSpace.Set(Movement.Rb.velocity.x, velocity);
       Movement.Rb.velocity = velocityWorkSpace;

    }

    public virtual void ResetStunResistance()
    {

        IsStunned = false;
        currentStunResistance = entityData.stunResistance;
    }
    


    public virtual void OnDrawGizmos()
    {

        if(Core != null)
        {

            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * entityData.wallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);

        }

    }
}

