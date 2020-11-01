using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public class KinematicArrive : MonoBehaviour
    {
        [Header("References")]
        public Agent character;
        public Agent target;

        [Header("Properties")]
        public float maxSpeed;
        public float radius;
        public float timeToTarget;

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

            if(steering.velocity.magnitude < 0)
            {
                steering.velocity = Vector2.zero;
            }

            // We need to move to our target, we’d like to get there in timeToTarget seconds
            steering.velocity /= timeToTarget;

            //If this is too fast, clip it to the max speed
            if (steering.velocity.magnitude > maxSpeed)
            {
                steering.velocity.Normalize();
                steering.velocity *= maxSpeed;
            }
            
            // Face in the direction we want to move
            character.kinematic.UpdateOrientation(steering.velocity);

            // Output the steering
            steering.rotation = 0;
        }
    }
}
