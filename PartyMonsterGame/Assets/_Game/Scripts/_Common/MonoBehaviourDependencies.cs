using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using PlayerX;
using UnityEngine;

namespace PartyMonster
{
    public class MonoBehaviourDependencies : MonoBehaviour
    {
        protected PX_Dependencies dependencies
        {
            get
            {
                if (this._dependencies == null)
                    this._dependencies = GetComponent<PX_Dependencies>();
                if (this._dependencies == null)
                    this._dependencies = GetComponentInParent<PX_Dependencies>();
                if (this._dependencies == null)
                    this._dependencies = GetComponentInChildren<PX_Dependencies>();

                return this._dependencies;
            }
        }
        [ReadOnly, SerializeField] private PX_Dependencies _dependencies;
    }
}
