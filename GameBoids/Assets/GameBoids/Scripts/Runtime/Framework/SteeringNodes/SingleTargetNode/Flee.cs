using System;
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// keep away from target
    /// </summary>
    [AddComponentMenu("GameBoids/SteeringNode/Flee")]
    public class Flee : SingleTargetNode
    {
        public override Vector3 CalculateForce()
        {
            var dis = TargetPos - BoidsObject.Position;
            if (ClosedDistance * ClosedDistance <= dis.sqrMagnitude)
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
                Gizmos.DrawWireSphere(TargetPos, ClosedDistance);
            if (BoidsObject != null)
                Gizmos.DrawLine(BoidsObject.Position, TargetPos);
            
        }
#endif
    }
}

