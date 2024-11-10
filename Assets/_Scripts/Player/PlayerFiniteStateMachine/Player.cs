using _Scripts.Weapons;
using Assets.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region  State Varibles
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    public PlayerLandState LandState { get; private set; }

    public PlayerWallClimbState WallClimbeState { get; private set; }

    public PlayerWallGrabState WallGrabState { get; private set; }

    public PlayerWallSlideState WallSlideState { get; private set; }

    public PlayerWallJumpState WallJumpState { get; private set; }

    public PlayerLedgeClimbState LedgeClimbState { get; private set;  }

    public playerDashState DashState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set;  }

    public PlayerCrouchMoveState CrouchMoveState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }
    
    public PlayerAttackState SecondaryAttackState { get; private set;  }    


    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Components


    public Core Core { get; private set; }
    public Animator Anim { get; private set; }

    public PlayerInputHandler InputHandler { get; private set; }

    public Rigidbody2D Rb { get; private set; }

    public Transform DashDirectionIndicator { get; private set; }


    public BoxCollider2D  MovementCollider { get; private set;  }

  

    #endregion

    
    #region Other Variables

    private Vector2 workSpace;


    private Weapon primryWeapon;
    private Weapon secondaryWeapon;


    #endregion


    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        primryWeapon = transform.Find("PrimaryWeapon").GetComponent<Weapon>();
        secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<Weapon>();

        primryWeapon.SetCore(Core);
        secondaryWeapon.SetCore(Core);


        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData,"wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        WallClimbeState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimbe");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
        DashState = new playerDashState(this, StateMachine, playerData, "dashState");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack" , primryWeapon);
       SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack" , secondaryWeapon);



    }

    private void Start()
    {
      

        Anim = GetComponent<Animator>();
        

        InputHandler = GetComponent<PlayerInputHandler>();
        Rb = GetComponent<Rigidbody2D>();

        DashDirectionIndicator = transform.Find("DashDirectionindicator");

        MovementCollider = GetComponent<BoxCollider2D>();
       
     
        StateMachine.Initialize(IdleState);


    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.physicsUpdate();
    }
    #endregion



    
    #region Other Function


    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workSpace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workSpace;
        MovementCollider.offset = center;

    }


    private void AnimatinTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
   
    #endregion
}
