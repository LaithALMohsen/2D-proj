using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{

    [Serializable]
    public class AttackPoiseDamage : AttackData

    {
        [field: SerializeField]public float Amount { get; private set; }



    }
}