using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class PursueDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Pursue pursue;

        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            pursue.UpdateKinematics(character.kinematic, target.kinematic);
            character.steering = pursue.GetSteering();
            character.kinematic.UpdateOrientationBasedOnCurrentvelocity();
            character.DoUpdate(pursue.maxSpeed);
        }
    }
}
