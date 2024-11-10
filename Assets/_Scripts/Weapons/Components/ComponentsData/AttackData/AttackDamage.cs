using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{


    [Serializable]
    public class AttackDamage : AttackData
    {
        [field : SerializeField] public float Amount { get; private set;  }




    }
}