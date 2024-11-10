using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{
    [Serializable]
    public class AttackActionHitBox : AttackData
    {

        public bool Debug;
        [field: SerializeField] public Rect HitBox { get; private set; }
     
    }
}