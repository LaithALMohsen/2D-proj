using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{

    [Serializable]
    public class AttackKnockBack : AttackData
    {
        [field: SerializeField] public Vector2 Angle { get; private set; }
        [field: SerializeField] public float Strength { get; private set; }
       
    }
}