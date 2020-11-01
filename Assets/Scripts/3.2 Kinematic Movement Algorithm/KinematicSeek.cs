using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class KinematicSeek : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Properties")]
        public float maxSpeed;

        private KinematicSteeringOutput steering;

        private void Awake()
        {
            steering = new KinematicSteeringOutput();
            character.Initialize();
            target.Initialize();
        }

        private void Update()
        {
            UpdateSteering();
            character.kinematic.velocity = steering.velocity;
            character.DoUpdate();
        }

        public void UpdateSteering()
        {
            // Get the direction to the target
            steering.velocity = target.kinematic.position - character.kinematic.position;

            // The velocity is along this direction, at full speed
            steering.velocity.Normalize();
            steering.velocity *= maxSpeed;

            // Face in the direction we want to move
            character.kinematic.UpdateOrientation(steering.velocity);

            // Output the steering
            steering.rotation = 0;
        }
    }
}
