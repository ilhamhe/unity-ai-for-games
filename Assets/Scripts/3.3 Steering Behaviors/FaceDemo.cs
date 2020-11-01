using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class FaceDemo : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Data")]
        public Face face;

        private void Awake()
        {
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            face.UpdateKinematics(character.kinematic, target.kinematic);
            character.steering = face.GetSteering();
            character.DoUpdate();
        }
    }
}
