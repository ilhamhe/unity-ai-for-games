using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class AlignDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Align align;

        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            // Apply agents' kinematics to the steer algorithm
            align.UpdateKinematics(character.kinematic, target.kinematic);
            character.steering = align.GetSteering();
            character.DoUpdate();
        }
    }
}
