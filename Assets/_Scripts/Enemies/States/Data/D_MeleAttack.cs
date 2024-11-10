using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleAttackStateStateData", menuName = "Data/State Data/Mele Attack State")]
public class D_MeleAttack : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;

    public Vector2 KnockbackAngle = Vector2.one;
    public float KnockbackStrength = 10f;

    public LayerMask whatisPlayer; 
}
