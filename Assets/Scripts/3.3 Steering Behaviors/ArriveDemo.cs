using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class ArriveDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Arrive arrive;
        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            // Apply agents' kinematics to the steer algorithm
            arrive.UpdateKinematics(character.kinematic, target.kinematic);

            character.steering = arrive.GetSteering();
            character.kinematic.UpdateOrientationBasedOnCurrentvelocity();
            character.DoUpdate(arrive.maxSpeed);
        }
    }
}
