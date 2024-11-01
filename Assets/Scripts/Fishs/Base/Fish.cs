using System;
using ItemSystem.ScriptableObjects;
using UnityEngine;

namespace Fishs.Base
{
    public abstract class Fish : MonoBehaviour
    {
        [SerializeField] protected FishItem fishItem;
        [SerializeField] protected Rigidbody rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            gameObject.transform.localScale = new Vector3(fishItem.Scale,fishItem.Scale,fishItem.Scale);
        }

        public FishItem FishItem => fishItem;
        
    }
}
