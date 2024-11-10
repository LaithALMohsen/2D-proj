using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{

    [Serializable]
    public class AttackMovement : AttackData
    {
       [field: SerializeField] public Vector2 Direction { get; private set; }
       [field: SerializeField] public float Velocity { get; private set; }
    
    }
}