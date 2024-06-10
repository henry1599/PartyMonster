using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace PartyMonster
{
    public class WeaponHolder : MonoBehaviourDependencies
    {
        [SerializeField] eHand hand;
        [ReadOnly, SerializeField] Weapon weapon;
        [SerializeField] Rigidbody rb;
        public eHand Hand => this.hand;
        public Weapon CurrentWeapon => this.weapon;
        public Rigidbody Rb
        {
            get
            {
                if (this.weapon == null)
                    return this.rb;
                return this.weapon.Rb;
            }
        }
        public Transform AttackPoint
        {
            get
            {
                if (this.weapon == null)
                    return transform;
                return (this.weapon as MeleeWeapon)?.AttackPoint ?? transform;
            }
        }
        public float AttackForce
        {
            get 
            {
                if (this.weapon == null)
                    return this.dependencies.controller.punchForce;
                return (this.weapon as MeleeWeapon)?.AttackForce ?? this.dependencies.controller.punchForce;
            }
        }
        void Awake()
        {
            this.rb = GetComponent<Rigidbody>();
        }
        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }
    }
}
