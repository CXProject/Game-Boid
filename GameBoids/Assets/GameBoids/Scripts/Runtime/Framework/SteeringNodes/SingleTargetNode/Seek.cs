using System;
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// close to target
    /// </summary>
    [AddComponentMenu("GameBoids/SteeringNode/Seek")]
    public class Seek : SingleTargetNode
    {
        public override Vector3 CalculateForce()
        {
            var dis = TargetPos - BoidsObject.Position;
            if (dis.sqrMagnitude <= ClosedDistance * ClosedDistance)
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

