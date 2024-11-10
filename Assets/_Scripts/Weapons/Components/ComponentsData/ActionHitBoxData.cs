using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{

    
    public class ActionHitBoxData : ComponentData<AttackActionHitBox>
    {
        [field : SerializeField] public LayerMask DetectableLayers { get; private set; }


     

        protected override void SetComponentDependency()
        {
            
            ComponintDependency = typeof(ActionHitBox);
        }
    }
}