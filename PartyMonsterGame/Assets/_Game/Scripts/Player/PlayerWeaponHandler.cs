using System.Collections;
using System.Collections.Generic;
using HenryDev.Utilities;
using PartyMonster.Interface;
using PlayerX;
using UnityEngine;

namespace PartyMonster
{
    public enum eHand
    {
        Right = 0,
        Left,
    }
    public class PlayerWeaponHandler : MonoBehaviourDependencies
    {
        [SerializeField] float castRange;
        [SerializeField] Transform castPivot;
        [SerializeField] WeaponHolder rightHandHolder;
        [SerializeField] WeaponHolder leftHandHolder;
        public WeaponHolder LeftHandHolder => this.leftHandHolder;
        public WeaponHolder RightHandHolder => this.rightHandHolder;
        (IEquiptable equiptable, GameObject gameObject) currentEquipment;
        private Dictionary<eHand, ConfigurableJoint> weaponJoint = new Dictionary<eHand, ConfigurableJoint>() { { eHand.Left, new() }, { eHand.Right, new() } };
        private Dictionary<eHand, bool> equippedHands = new Dictionary<eHand, bool>() { { eHand.Left, false }, { eHand.Right, false } };
        void Update()
        {
            if (this.dependencies.inputs.Frame.PickupDown)
            {
                HandleInput();
            }
        }
        (IEquiptable equiptable, GameObject gameObject) RaycastEquipment()
        {
            var cols = Physics.OverlapSphere(this.castPivot.position, this.castRange);
            foreach (var col in cols)
            {
                var equipment = col.GetComponent<IEquiptable>();
                if (equipment == null)
                    continue;
                return (equipment, col.gameObject);
            }
            return (null, null);
        }
        void HandleInput()
        {
            if (!this.dependencies.state.isAlive)
                return;
            eHand hand = default(eHand);
            if (this.equippedHands[hand])
            {
                Unequip(hand);
            }
            else
            {
                Equip(hand);
            }
            this.equippedHands[hand] = !this.equippedHands[hand];
        }
        void Equip(eHand hand)
        {
            var handTransform = hand == eHand.Left ? this.leftHandHolder : this.rightHandHolder;
            this.currentEquipment = RaycastEquipment();
            if (this.currentEquipment.equiptable == null || this.currentEquipment.gameObject == null)
                return;
            this.currentEquipment.equiptable.Attach(handTransform.gameObject);
            var weapon = this.currentEquipment.gameObject.GetComponent<Weapon>();

            weaponJoint[hand] = this.currentEquipment.gameObject.SafeAddComponent<ConfigurableJoint>();
									
            weaponJoint[hand].xMotion = ConfigurableJointMotion.Locked;
            weaponJoint[hand].yMotion = ConfigurableJointMotion.Locked;
            weaponJoint[hand].zMotion = ConfigurableJointMotion.Locked;
            
            weaponJoint[hand].angularXMotion = ConfigurableJointMotion.Locked;
            weaponJoint[hand].angularYMotion = ConfigurableJointMotion.Locked;
            weaponJoint[hand].angularZMotion = ConfigurableJointMotion.Locked;
            
            weaponJoint[hand].connectedBody = handTransform.Rb;
            handTransform.SetWeapon(weapon);
        }
        void Unequip(eHand hand)
        {
            var handTransform = hand == eHand.Left ? this.leftHandHolder : this.rightHandHolder;
            Destroy(weaponJoint[hand]);
            handTransform.SetWeapon(null);
            this.currentEquipment.equiptable.Detach(handTransform.gameObject);
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(this.castPivot.position, this.castRange);
        }
    }
}
