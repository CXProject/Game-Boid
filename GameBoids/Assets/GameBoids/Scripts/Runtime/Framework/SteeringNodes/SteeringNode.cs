using System;
using UnityEngine;

namespace GameBoids
{
    public abstract class SteeringNode : MonoBehaviour, ISteeringNode
    {
        public MovingEntity BoidsObject { get; set; }
        public bool Active 
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }
        public abstract Vector3 CalculateForce();

    }
}

