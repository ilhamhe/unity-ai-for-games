using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class Seek
    {
        [Header("Kinematics")]
        public Kinematic character;
        public Kinematic target;

        [Header("Properties")]
        public float maxSpeed;
        public float maxAcceleration;

        public virtual void UpdateKinematics(Kinematic character, Kinematic target)
        {
            this.character = character;
            this.target = target;
        }

        public virtual SteeringOutput GetSteering()
        {
            // Create the structure to hold our output
            SteeringOutput steering = new SteeringOutput();

            // Get the direction to the target
            steering.linear = target.position - character.position;

            // The velocity is along this direction, at full speed
            steering.linear.Normalize();
            steering.linear *= maxAcceleration;

            // Output the steering
            steering.angular = 0;
            return steering;
        }
    }

}
