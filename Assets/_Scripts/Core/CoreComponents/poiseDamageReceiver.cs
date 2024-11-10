using Assets._Scripts.interFaces;
using Assets.CoreSystem;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts
{
    public class poiseDamageReceiver : CoreComponent, IPoiseDamageable
    {

        private Stats stats;
        public void DamagePoise(float amount)
        {

            stats.Poise.Decrease(amount);

        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }

    }
}