using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class SeekDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Seek seek;

        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            // Apply agents' kinematics to the steer algorithm
            seek.UpdateKinematics(character.kinematic, target.kinematic);

            character.steering = seek.GetSteering();
            character.kinematic.UpdateOrientationBasedOnCurrentvelocity();
            character.DoUpdate(seek.maxSpeed);
        }
    }
}
