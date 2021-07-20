using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// arrive to target
    /// </summary>
    [AddComponentMenu("GameBoids/SteeringNode/Arrive")]
    public class Arrive : SingleTargetNode
    {
        [Range(1f,3f)]
        [Tooltip("减速因子")]
        public float Deceleration = 1f;

        public override Vector3 CalculateForce()
        {
            var desiredVelocity = Vector3.zero;
            var toTarget = TargetPos - BoidsObject.Position;
            //计算距离
            var dist = toTarget.magnitude;
            if (dist > 0)
            {
                //给定预期减速度，计算能达到目标位置所需的速度
                //确保speed小于maxspeed
                var speed = Mathf.Min(dist / Deceleration, BoidsObject.MaxSpeed);
                //计算减速度
                desiredVelocity = toTarget * speed / dist;
            }
            return desiredVelocity;
        }
    }
}


