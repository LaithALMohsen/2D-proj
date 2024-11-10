using Assets._Scripts.interFaces;
using Assets._Scripts.Weapons.Components.ComponentsData;
using Laith.Weapons.Components;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{
    public class PoiseDamage :WeaponComponents<PoiseDamageData,AttackPoiseDamage>
    {
        private ActionHitBox hitBox;

        private void HandleDetectCollider2D(Collider2D[] colliders)
        {

            foreach (var item in colliders)
            {
                if(item.TryGetComponent(out IPoiseDamageable poiseDamageable))
                {


                    poiseDamageable.DamagePoise(currentAttackData.Amount);

                }


            }

        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();

            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;

        }
    }
}