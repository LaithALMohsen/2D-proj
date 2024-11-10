using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{
    public class AttackData 
    {

        [SerializeField, HideInInspector] private string name;

        public void SetAttackName(int i) => name = $"Attack {i}";

    }
}