using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class FleeDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Flee flee;

        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            // Apply agents' kinematics to the steer algorithm
            flee.UpdateKinematics(character.kinematic, target.kinematic);

            character.steering = flee.GetSteering();
            character.kinematic.UpdateOrientationBasedOnCurrentvelocity();
            character.DoUpdate(flee.maxSpeed);
        }

    }
}
