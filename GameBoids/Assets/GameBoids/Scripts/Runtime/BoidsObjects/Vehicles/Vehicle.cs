using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// 交通工具
    /// </summary>
    public class Vehicle : MovingEntity
    {
        [Min(0f)]
        public float DynamicFriction;
        [Min(0f)]
        public float StaticFriction;

        public const float MinSpeed = 0.001f;

        public ISteeringBehavior SteeringBehavior { get; set; }

        private void Awake()
        {
            SteeringBehavior = transform.GetComponent<ISteeringBehavior>();
            if (SteeringBehavior != null)
                SteeringBehavior.BoidsObject = this;
        }

        private void FixedUpdate()
        {
            Force = SteeringBehavior.GetForce();
            Vector3 friction = Vector3.zero;
            //判断摩擦力
            if (Velocity.sqrMagnitude > MinSpeed)
            {
                //运动状态下加上动摩擦力
                friction -= Velocity.normalized * DynamicFriction;
            }
            else 
            {
                if (Force.sqrMagnitude <= StaticFriction * StaticFriction)//静止状态小于静摩擦力时直接返回
                    return;
                else
                    friction -= Force.normalized * StaticFriction;
            }
            Vector3 acceleration = (Force + friction) / Mass;
            Velocity += acceleration * Time.fixedDeltaTime;
            var pos = transform.position;
            pos += Velocity * Time.fixedDeltaTime;
            transform.position = pos;
            //LogUtil.Log(Velocity.sqrMagnitude);
            if (Velocity.sqrMagnitude > MinSpeed)
            {
            //调整朝向,只有在速度比较大的时候更新朝向，避免抖动
                transform.forward = Velocity.normalized;
            }
        }
    }
}
