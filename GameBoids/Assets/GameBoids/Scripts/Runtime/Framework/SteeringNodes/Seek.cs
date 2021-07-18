using System;
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// close to target
    /// </summary>
    [AddComponentMenu("GameBoids/SteeringNode/Seek")]
    public class Seek : SteeringNode
    {
        public Transform Target;
        [SerializeField]
        private Vector3 m_targetPos;
        public Vector3 TargetPos
        {
            get 
            {
                if (Target != null)
                    return Target.position;
                else
                    return m_targetPos;
            }
            set => m_targetPos = value;
        }
        [Min(0f)]
        public float m_MinDistance;
        public override Vector3 CalculateForce()
        {
            var dis = TargetPos - BoidsObject.Position;
            if (dis.sqrMagnitude <= m_MinDistance * m_MinDistance)
                return Vector3.zero;
            //计算理想速度，智能体在理想化情况下到达目标位置所需的速度，它是从智能体到目标的向量，大小为智能体的最大速度
            var expSpeed = dis.normalized * BoidsObject.MaxSpeed;
            //理想速度减现速度作为返回的力
            return expSpeed - BoidsObject.Velocity;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            if (BoidsObject != null)
                Gizmos.DrawLine(BoidsObject.Position, TargetPos);
        }
#endif
    }
}

