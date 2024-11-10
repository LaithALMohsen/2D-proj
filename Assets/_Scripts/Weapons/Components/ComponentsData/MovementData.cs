using Assets._Scripts.Weapons.Components.ComponentsData;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{
    public class MovementData :ComponentData<AttackMovement>
    {
    

        protected override void SetComponentDependency()
        {
            ComponintDependency = typeof(Movement);
           
        }
    }
}