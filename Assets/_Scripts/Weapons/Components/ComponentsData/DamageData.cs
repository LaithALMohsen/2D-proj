using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{
    public class DamageData : ComponentData<AttackDamage>
    {
      
        protected override void SetComponentDependency()
        {
          
            ComponintDependency = typeof(Damage);
        }
    }
}