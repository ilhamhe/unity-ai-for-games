using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class Face : Align
    {
        public override SteeringOutput GetSteering()
        {
            // 1. Calculate the target to delegate to align

            // Work out the direction to target
            Vector2 direction = target.position - character.position;

            // Check for a zero direction, and make no change if so
            if (direction.magnitude > 0)
            {
                // Put the target together
                target.UpdateOrientation(direction);
            }

            // 2. Delegate to align
            return base.GetSteering();
        }
    }
}
