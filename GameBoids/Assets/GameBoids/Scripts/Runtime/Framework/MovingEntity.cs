using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// 移动能力
    /// </summary>
    public abstract class MovingEntity : MonoBehaviour
    {
        private Vector3 m_Velocity;
        /// <summary>
        /// 速度
        /// </summary>
        public Vector3 Velocity
        {
            get => m_Velocity;
            protected set => m_Velocity = Vector3.ClampMagnitude(value, MaxSpeed);
        }

        private Vector3 m_Force;

        public Vector3 Force
        {
            get => m_Force;
            protected set => m_Force = Vector3.ClampMagnitude(value, MaxForce);
        }

        [Min(0.1f)]
        public float Mass;

        public Vector3 Position => transform.position;

        /// <summary>
        /// 最大速度
        /// </summary>
        public float MaxSpeed;
        /// <summary>
        /// 最大角速度
        /// </summary>
        public float MaxTurnRate;
        /// <summary>
        /// 实体能产生的最大力
        /// </summary>
        public float MaxForce;
# if UNITY_EDITOR
        [Space(10f)]
        public uint gizmoRate = 10;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * gizmoRate);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Velocity * gizmoRate);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + Force * gizmoRate);
        }
#endif
    }
}


