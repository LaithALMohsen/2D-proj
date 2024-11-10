using Assets._Scripts.Weapons.Components;
using Assets._Scripts.Weapons.Components.ComponentsData;
using System.Collections;
using UnityEngine;
using System;

namespace Assets._Scripts.Weapons
{
    public class PoiseDamageData : ComponentData<AttackPoiseDamage>
    {
        protected override void SetComponentDependency()
        {
            ComponintDependency = typeof(PoiseDamage);



        }
    }
}