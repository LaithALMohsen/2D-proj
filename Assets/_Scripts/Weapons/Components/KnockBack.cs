using Assets._Scripts.Weapons.Components.ComponentsData;
using Laith.Weapons.Components;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{
    public class KnockBack :WeaponComponents<KnockBackData, AttackKnockBack>
    {
        private ActionHitBox hitBox;

        private CoreSystem.Movement movement;
        protected void HandleDetectCollider2D(Collider2D[] colliders)
        {

            foreach (var item in colliders)
            {
                if(item.TryGetComponent(out IKnockBackable knockBackable))
                {


                    knockBackable.KnockBack(currentAttackData.Angle, currentAttackData.Strength, movement.FacingDirection);
                }
            }

        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;

            movement = Core.GetCoreComponent<CoreSystem.Movement>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }

    }
}