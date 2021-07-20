using UnityEngine;

namespace GameBoids
{
    public abstract class SingleTargetNode : SteeringNode
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
        public float ClosedDistance;
    }
}

