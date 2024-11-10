using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{
    public class KnockBackData : ComponentData<AttackKnockBack>
    {
        protected override void SetComponentDependency()
        {
            ComponintDependency = typeof(KnockBack);
        }
    }
}