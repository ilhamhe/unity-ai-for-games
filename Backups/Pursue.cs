using UnityEngine;

namespace ilhamhe.ai4games
{
    [System.Serializable]
    public class Pursue : Seek
    {
        public float maxPrediction;
        public Kinematic pursueTarget;

        public override SteeringOutput GetSteering()
        {
            // 1. Calculate the target to delegate to seek
            // Work out the distance to target
            Vector2 direction = pursueTarget.position - character.position;
            float distance = direction.magnitude;

            // Work out our current speed
            float speed = character.velocity.magnitude;

            float prediction;
            // Check if speed is too small to give a reasonable prediction time
            if (speed <= distance / maxPrediction)
            {
                prediction = maxPrediction;
            }
            else
            {
                prediction = distance / speed;
            }

            // Put the target together
            target = pursueTarget;
            target.position += pursueTarget.velocity * prediction;

            // 2. Delegate to seek
            return base.GetSteering();
        }

        public override void UpdateKinematics(Kinematic character, Kinematic target)
        {
            // Update the target kinematic with the Pursue Target's kinematic instead
            pursueTarget = target;
            base.character = character;
        }
    }
}
