
using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// 操控行为接口
    /// </summary>
    public interface ISteeringBehavior
    {
        public MovingEntity BoidsObject { get; set; }
        /// <summary>
        /// 计算所有被激活的操控行为的操控力总和
        /// </summary>
        /// <returns></returns>
        public Vector3 GetForce();
    }
}
