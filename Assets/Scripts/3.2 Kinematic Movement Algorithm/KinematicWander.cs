using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class KinematicWander : MonoBehaviour
    {
        [Header("References")]
        public Agent character;

        [Header("Properties")]
        public float maxSpeed;
        public float maxRotation;
        public float changeRotationRate;

        private KinematicSteeringOutput steering;

        private void Awake()
        {
            steering = new KinematicSteeringOutput();
            character.Initialize();
        }

        private void Update()
        {
            UpdateSteering();
            character.kinematic.velocity = steering.velocity;
            character.kinematic.rotation = steering.rotation;
            character.DoUpdate();

        }

        private void UpdateSteering()
        {
            // Get velocity from the vector form of the orientation
            steering.velocity = maxSpeed * character.kinematic.GetOrientationVector();

            // Change our orientation randomly
            steering.rotation = RandomBinomial() * maxRotation;
        }

        // Return random value from -1 to 1
        private float RandomBinomial()
        {
            return Random.Range(-1f, 1f);
        }
    }
}
