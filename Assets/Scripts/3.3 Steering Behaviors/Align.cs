using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class Align
    {
        [Header("Kinematics")]
        public Kinematic character;
        public Kinematic target;

        [Header("Properties")]
        public float maxRotation;
        public float maxAngularAcceleration;

        public float targetRadius;
        public float slowRadius;

        public float timeToTarget;

        public virtual void UpdateKinematics(Kinematic character, Kinematic target)
        {
            this.character = character;
            this.target = target;
        }

        public virtual SteeringOutput GetSteering()
        {
            // Create the structure to hold our output
            SteeringOutput steering = new SteeringOutput();

            // Get the naive direction to the target
            float rotation = target.orientation - character.orientation;

            // Map the result to the (-pi, pi) interval
            rotation = MapRotation(rotation);
            float rotationSize = Mathf.Abs(rotation);

            // Check if we are there
            if (rotationSize < targetRadius)
            {
                steering.angular = 0;
            }

            float targetRotation = 0;
            // If we are outside the slowRadius, then use maximum rotation
            if(rotationSize > slowRadius)
            {
                targetRotation = maxRotation;
            }
            else
            {
                // Otherwise calculate a scaled rotation
                targetRotation = maxRotation * rotationSize / slowRadius;
            }
            
            // The final target rotation combines speed and direction
            if(rotationSize > 0)
                targetRotation *= rotation / rotationSize;
            
            // Acceleration tries to get to the target rotation
            steering.angular = targetRotation - character.rotation;
            steering.angular /= timeToTarget;

            // Check if the acceleration is too great
            float angularAcceleration = Mathf.Abs(steering.angular);
            if (angularAcceleration > maxAngularAcceleration)
            {
                steering.angular /= angularAcceleration;
                steering.angular *= maxAngularAcceleration;
            }

            // Output the steering
            steering.linear = Vector2.zero;
            return steering;
        }

        // If there's better mapping algorithm please let me know
        private float MapRotation(float rotation)
        {
            while (rotation < -Mathf.PI) rotation += 2 * Mathf.PI;
            while (rotation > Mathf.PI) rotation -= 2 * Mathf.PI;
            return rotation;
        }
    }
}
