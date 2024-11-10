using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components.ComponentsData
{

    [Serializable]
    public class AttackSprits : AttackData
    {
        [field: SerializeField] public PhaseSprites[] PhaseSprites { get; private set; }
    }

    [Serializable]
    public struct PhaseSprites
    {
        [field:SerializeField] public AttackPhases Phase { get; private set; }
        [field: SerializeField] public Sprite[] Sprites { get; private set;  }

    }
}