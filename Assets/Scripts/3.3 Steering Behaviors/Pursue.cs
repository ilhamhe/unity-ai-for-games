using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class Pursue : Seek
    {
        public float maxPrediction;

        public override SteeringOutput GetSteering()
        {
            // 1. Calculate the target to delegate to seek
            // Work out the distance to target
            Vector2 direction = target.position - character.position;
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
            target.position += target.velocity * prediction;

            // 2. Delegate to seek
            return base.GetSteering();
        }
    }
}
