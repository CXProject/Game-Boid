using System.Collections.Generic;
using UnityEngine;

namespace GameBoids
{
    [DisallowMultipleComponent]
    [AddComponentMenu("GameBoids/SteeringBehavior")]
    public class SteeringBehavior : MonoBehaviour, ISteeringBehavior
    {
        public MovingEntity BoidsObject { get; set; }
        public List<SteeringNode> NodeList;

        private void Start()
        {
            foreach (var node in NodeList)
            {
                node.BoidsObject = BoidsObject;
            }
        }

        public Vector3 GetForce()
        {
            var allForce = Vector3.zero;
            foreach (var node in NodeList)
            {
                allForce += node.CalculateForce();
            }
            return allForce;
        }
    }
}


