using System;
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// keep away from target
    /// </summary>
    [AddComponentMenu("GameBoids/SteeringNode/Flee")]
    public class Flee : SteeringNode
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
        public float MinDistance;
        public override Vector3 CalculateForce()
        {
            var dis = TargetPos - BoidsObject.Position;
            if (MinDistance * MinDistance <= dis.sqrMagnitude)
                return Vector3.zero;
            //���������ٶȣ������������뻯����µ���Ŀ��λ��������ٶȣ����Ǵ������嵽Ŀ�����������СΪ�����������ٶ�
            var expSpeed = (TargetPos - BoidsObject.Position).normalized * BoidsObject.MaxSpeed;
            //�����ٶȼ����ٶ���Ϊ���ص���
            return BoidsObject.Velocity - expSpeed ;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(TargetPos, MinDistance);
            if (BoidsObject != null)
                Gizmos.DrawLine(BoidsObject.Position, TargetPos);
            
        }
#endif
    }
}

