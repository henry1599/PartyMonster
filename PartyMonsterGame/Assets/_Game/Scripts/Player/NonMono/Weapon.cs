using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace PartyMonster
{
    public enum eWeaponType
    {
        Melee = 0,
        Ranged
    }
    [System.Serializable]
    public class Weapon : Equipment
    {
        [SerializeField] protected eWeaponType weaponType;
        [SerializeField] protected float damage;
        [SerializeField] protected Transform handle;
        [ReadOnly, SerializeField] protected Rigidbody rb;
        [ReadOnly, SerializeField] protected Collider col;
        public Rigidbody Rb => this.rb;
        public eWeaponType WeaponType => this.weaponType;
        public float Damage => this.damage;
        public Transform Handle => this.handle;
        public Collider Col => this.col;
        void Awake()
        {
            this.rb = GetComponent<Rigidbody>();
            this.col = GetComponent<Collider>();
        }
        public override void Attach(GameObject playerEquipmentPlacement)
        {
            // this.rb.isKinematic = true;
            this.col.enabled = false;
            gameObject.transform.SetParent(playerEquipmentPlacement.transform);
            gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        public override void Detach(GameObject playerEquipmentPlacement)
        {
            // this.rb.isKinematic = false;
            this.col.enabled = true;
            gameObject.transform.SetParent(null);
        }
    }
}
