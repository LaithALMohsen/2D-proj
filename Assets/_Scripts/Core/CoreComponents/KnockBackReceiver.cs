using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.CoreSystem
{




    public class KnockBackReceiver : CoreComponent, IKnockBackable
    {
       

      

        [SerializeField] private float maxKnockBackTime = 0.2f;


        private bool isKnockBackActive;
        private float KnockBackStartTime;

        private CoreComp<Movement> movement;
        private CoreComp<CollisionSenses> collisionSenses;

        public override void LogicUpdate()
        {
            CheckKnockBack();
        }

       

        public void KnockBack(Vector2 angle, float strength, int direction)
        {
            movement.Comp?.SetVelocity(strength, angle, direction);

            movement.Comp.CanSetVelocity = false;

            isKnockBackActive = true;
            KnockBackStartTime = Time.time;
        }

        private void CheckKnockBack()
        {
            if (isKnockBackActive && ((movement.Comp?.CurrentVelocity.y <= 0.01f && collisionSenses.Comp.Ground) || Time.time >= KnockBackStartTime + maxKnockBackTime))
            {

                isKnockBackActive = false;
                movement.Comp.CanSetVelocity = true;
            }


        }

        protected override void Awake()
        {
            base.Awake();
            movement = new CoreComp<Movement>(core);
            collisionSenses = new CoreComp<CollisionSenses>(core);
        }
    }
}
