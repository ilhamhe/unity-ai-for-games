using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class Arrive
    {
        [Header("Kinematics")]
        public Kinematic character;
        public Kinematic target;

        [Header("Properties")]
        public float maxSpeed;
        public float maxAcceleration;
        public float targetRadius;
        public float slowRadius;
        public float timeToTarget;

        public virtual void UpdateKinematics(Kinematic character, Kinematic target)
        {
            this.character = character;
            this.target = target;
        }

        public SteeringOutput GetSteering()
        {
            // Create the structure to hold our output
            SteeringOutput steering = new SteeringOutput();

            Vector2 direction = target.position - character.position;
            float distance = direction.magnitude;

            // Check if we are there
            if (distance < targetRadius)
            {
                // We can't return null on struct
                steering.linear = Vector2.zero;
            }

            float targetSpeed;
            // If we are outside the slowRadius, then go max speed
            if(distance > slowRadius)
            {
                targetSpeed = maxSpeed;
            }
            else
            {
                // Otherwise calculate a scaled speed
                targetSpeed = maxSpeed * distance / slowRadius;
            }

            // The target velocity combines speed and direction
            Vector2 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            // Acceleration tries to get to the target velocity
            steering.linear = targetVelocity - character.velocity;
            steering.linear /= timeToTarget;

            // Check if the acceleration is too fast
            if(steering.linear.magnitude > maxAcceleration) {
                steering.linear.Normalize();
                steering.linear *= maxAcceleration;
            }

            // Output the steering
            steering.angular = 0;
            return steering;
        }
    }
}
