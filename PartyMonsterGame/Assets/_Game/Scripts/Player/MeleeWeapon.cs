using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyMonster
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] protected float attackForce;
        [SerializeField] protected Transform attackPoint;
        public Transform AttackPoint => this.attackPoint;
        public float AttackForce => this.attackForce;
    }
}
