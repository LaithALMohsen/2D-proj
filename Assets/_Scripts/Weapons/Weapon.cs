using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laith.Utilities;

using Assets.Weapons;
using Assets.CoreSystem;

namespace _Scripts.Weapons
{
public class Weapon : MonoBehaviour
{
        [SerializeField] private float attackCounterResetCoolDown;
        public WeaponDataSO Data { get; private set;  }




        public int CurrentAttackCounter 
        {
            get => currentAttackCounter;
            private set
            {

                if(value >= Data.NumberOfAttacks)
                {

                    currentAttackCounter = 0;
                }else
                {

                    currentAttackCounter = value;
                }
            }
                
                
                
        }


        public event Action OnEnter;

        public event Action OnExit;
        private Animator Anim;
        public  GameObject BaseGameObject { get; private set;  }
        public GameObject WeaponSpriteGameObject { get; private set;  }

        public AnimationEventHandler EventHandler { get; private set; }

        public Core Core { get; private set; }


        private int currentAttackCounter;

        private Timer attackCounterResetTimer;

        public void Enter()
        {

            print($"{transform.name} enter");

            attackCounterResetTimer.StopTimer();

            Anim.SetBool("active", true);
            Anim.SetInteger("counter", CurrentAttackCounter);

            OnEnter?.Invoke();

        }

        public void SetCore(Core core)
        {

            Core = core; 
        }
        public void SetData(WeaponDataSO data)
        {
            Data = data; 


        }
             
        private void Exit()
        {

            Anim.SetBool("active", false);

            CurrentAttackCounter++;

            attackCounterResetTimer.StartTimer();
            OnExit?.Invoke();
            
        }

        private void Awake()
        {
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
            Anim = BaseGameObject.GetComponent<Animator>();
            EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCoolDown);
        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        private void ResetAttackCounter() => CurrentAttackCounter = 0;


        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }


    }

   


}

