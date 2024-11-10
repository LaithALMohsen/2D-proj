using Assets._Scripts.Weapons.Components.ComponentsData;
using Laith.Weapons.Components;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{
    public class Movement : WeaponComponents<MovementData, AttackMovement>
    {

        private CoreSystem.Movement coreMovement;
        private CoreSystem.Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

      
        private void HandleStartMovement()
        {
          
            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);


        }

        private void HandleStopMovement()
        {

            CoreMovement.SetVelocityZero();
        }

     
        protected override void Start()
        {
            base.Start();

            eventHandler.OnStartMovement += HandleStartMovement;
            eventHandler.OnStopMovement += HandleStartMovement;
        }

        protected override  void OnDestroy()
        {
            base.OnDestroy();

            eventHandler.OnStartMovement -= HandleStartMovement;
            eventHandler.OnStopMovement -= HandleStartMovement;
        }

    }
}