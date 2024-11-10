using Assets._Scripts.Weapons.Components.ComponentsData;
using Laith.Weapons.Components;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{
    public class WeaponSpriteData : ComponentData<AttackSprits>
    {
    

        protected override void SetComponentDependency()
        {
           
            ComponintDependency = typeof(weaponSprite); 
        }
    }
}