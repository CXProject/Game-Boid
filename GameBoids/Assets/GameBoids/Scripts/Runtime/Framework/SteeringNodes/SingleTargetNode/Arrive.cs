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
        [Tooltip("��������")]
        public float Deceleration = 1f;

        public override Vector3 CalculateForce()
        {
            var desiredVelocity = Vector3.zero;
            var toTarget = TargetPos - BoidsObject.Position;
            //�������
            var dist = toTarget.magnitude;
            if (dist > 0)
            {
                //����Ԥ�ڼ��ٶȣ������ܴﵽĿ��λ��������ٶ�
                //ȷ��speedС��maxspeed
                var speed = Mathf.Min(dist / Deceleration, BoidsObject.MaxSpeed);
                //������ٶ�
                desiredVelocity = toTarget * speed / dist;
            }
            return desiredVelocity;
        }
    }
}


