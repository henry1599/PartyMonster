using System.Collections;
using System.Collections.Generic;
using PartyMonster.Interface;
using UnityEngine;

namespace PartyMonster
{
    [System.Serializable]
    public abstract class Equipment : MonoBehaviour, IEquiptable
    {
        protected Transform attachedToTransform;
        public abstract void Attach(GameObject playerEquipmentPlacement);
        public abstract void Detach(GameObject playerEquipmentPlacement);
    }
}
