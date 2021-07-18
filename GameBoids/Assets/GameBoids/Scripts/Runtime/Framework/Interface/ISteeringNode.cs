using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// 操控行为节点接口
    /// </summary>
    public interface ISteeringNode
    {
        public MovingEntity BoidsObject { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// 计算的操控力
        /// </summary>
        /// <returns></returns>
        public Vector3 CalculateForce();
    }
}

