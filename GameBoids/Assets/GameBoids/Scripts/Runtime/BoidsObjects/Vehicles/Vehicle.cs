using UnityEngine;

namespace GameBoids
{
    /// <summary>
    /// ��ͨ����
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
            //�ж�Ħ����
            if (Velocity.sqrMagnitude > MinSpeed)
            {
                //�˶�״̬�¼��϶�Ħ����
                friction -= Velocity.normalized * DynamicFriction;
            }
            else 
            {
                if (Force.sqrMagnitude <= StaticFriction * StaticFriction)//��ֹ״̬С�ھ�Ħ����ʱֱ�ӷ���
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
            //��������,ֻ�����ٶȱȽϴ��ʱ����³��򣬱��ⶶ��
                transform.forward = Velocity.normalized;
            }
        }
    }
}
