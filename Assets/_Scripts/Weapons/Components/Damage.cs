using Assets._Scripts.Weapons.Components;
using Assets._Scripts.Weapons.Components.ComponentsData;
using Laith.Weapons.Components;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts
{
    public class Damage : WeaponComponents<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;
      private void HandleDetectCollider2D(Collider2D[] colliders)
        {


            foreach (var item in colliders)
            {
               if (item.TryGetComponent(out IDamageable damageable))
                {


                    damageable.Damage(currentAttackData.Amount);
                }
            }
        }


        protected override void Start()
        {
            base.Start();

            hitBox
                 = GetComponent<ActionHitBox>();
            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }


       
        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }
    }
}