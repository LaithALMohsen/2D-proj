using Assets._Scripts.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Scripts.Weapons
{
    public class AnimationEventHandler : MonoBehaviour
    {


        public event Action OnFinish;

        public event Action OnStartMovement;

        public event Action OnStopMovement;

        public event Action OnAttackAction;

        public event Action<AttackPhases> OnEnterAttackPhase;

        private void AnimationFinishedTrigger() => OnFinish?.Invoke();

        private void StartMovementTrigger() => OnStartMovement?.Invoke();
        private void StopMovementTrigger() => OnStopMovement?.Invoke();

        private void AttacActionTrigger() => OnAttackAction?.Invoke();

        private void EnterAttackPhase(AttackPhases phase) => OnEnterAttackPhase?.Invoke(phase);





    }



}