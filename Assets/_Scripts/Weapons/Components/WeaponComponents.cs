using _Scripts.Weapons;
using Assets._Scripts.Weapons.Components;
using Assets._Scripts.Weapons.Components.ComponentsData;

using Assets.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Laith.Weapons.Components
{

    public abstract class WeaponComponents : MonoBehaviour
    {



        protected Weapon weapon;


        //TODO: Fix this when finishing weapon data 
        //protected AnimationEventHandler EventHandler => weapon.EventHandler;
        protected AnimationEventHandler eventHandler ;
        protected Core Core => weapon.Core;


        protected bool isAttackActive;

        public virtual void Init()
        {


        }
             

        protected virtual void Awake()
        {


            weapon = GetComponent<Weapon>();

            eventHandler = GetComponentInChildren<AnimationEventHandler>();

        }
        protected virtual void Start()
        {

            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;

        }


        protected virtual void HandleEnter()
        {

            isAttackActive = true; 
        }

        protected virtual void HandleExit()
        {


            isAttackActive = false; 
        }

        
        protected virtual void OnDestroy()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;


        }

       
    }

   public abstract  class WeaponComponents<T1, T2> : WeaponComponents where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;
        protected T2 currentAttackData;


        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
        }

        public override void Init()
        {
            base.Init();

            data = weapon.Data.GetData<T1>();
        }


    }
   
}

