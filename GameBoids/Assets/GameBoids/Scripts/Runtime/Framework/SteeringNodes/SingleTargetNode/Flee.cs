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
            //计算理想速度，智能体在理想化情况下到达目标位置所需的速度，它是从智能体到目标的向量，大小为智能体的最大速度
            var expSpeed = (TargetPos - BoidsObject.Position).normalized * BoidsObject.MaxSpeed;
            //理想速度减现速度作为返回的力
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

