using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyMonster.Interface
{
    public interface IEquiptable
    {
        public void Attach(GameObject playerEquipmentPlacement);
        public void Detach(GameObject playerEquipmentPlacement);
    }
}
