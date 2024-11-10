using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Assets.CoreSystem
{

    public class Movement : CoreComponent
    {


        public Rigidbody2D Rb { get; private set; }

        public int FacingDirection { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }


        public bool CanSetVelocity { get; set; }

        private Vector2 workSpace;



        protected override void Awake()
        {
            base.Awake();

            Rb = GetComponentInParent<Rigidbody2D>();


            FacingDirection = 1;
            CanSetVelocity = true;

        }
        public override void LogicUpdate()
        {
            CurrentVelocity = Rb.velocity;
        }




        #region Set Functions


        public void SetVelocityZero()
        {

            workSpace = Vector2.zero;

            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {

            angle.Normalize();
            workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workSpace = direction * velocity;
            SetFinalVelocity();

        }
        public void SetVelocityx(float velocity)
        {
            workSpace.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();

        }
        public void SetVelocityY(float velocity)
        {

            workSpace.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();

        }

        private void SetFinalVelocity()
        {
            if (CanSetVelocity)
            {
                Rb.velocity = workSpace;
                CurrentVelocity = workSpace;

            }

        }

        public void checkIfshouldFlip(int xinput)
        {
            if (xinput != 0 && xinput != FacingDirection)
            {
                Flip();

            }

        }
        public void Flip()
        {
            FacingDirection *= -1;
            Rb.transform.Rotate(0.0f, 180f, 0, 0f);

        }

        #endregion
    }
}