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
            //���������ٶȣ������������뻯����µ���Ŀ��λ��������ٶȣ����Ǵ������嵽Ŀ�����������СΪ�����������ٶ�
            var expSpeed = dis.normalized * BoidsObject.MaxSpeed;
            //�����ٶȼ����ٶ���Ϊ���ص���
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

