using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    [System.Serializable]
    public struct Kinematic
    {
        public Vector2 position;
        public float orientation;
        public Vector2 velocity;
        public float rotation;

        public void Update(SteeringOutput steering, float time)
        {
            // Update the position and orientation
            position += velocity * time;
            orientation += rotation * time;

            // and the velocity and rotation
            velocity += steering.linear * time;
            orientation += steering.angular * time;
        }

        public void Update(SteeringOutput steering, float maxSpeed, float time)
        {
            // Update the position and orientation
            position += velocity * time;
            orientation += rotation * time;

            // and the velocity and rotation
            velocity += steering.linear * time;
            orientation += steering.angular * time;

            // Check for speeding and clip
            if (velocity.magnitude > maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
        }

        public void UpdateOrientation(Vector2 velocity)
        {
            if (velocity.magnitude > 0)
            {
                orientation = Mathf.Atan2(-velocity.x, velocity.y);
            }
        }

        public void UpdateOrientationBasedOnCurrentvelocity()
        {
            if (velocity.magnitude > 0)
            {
                orientation = Mathf.Atan2(-velocity.x, velocity.y);
            }
        }

        public static float GetNewOrientation(float currentOrientation, Vector2 velocity)
        {
            if (velocity.magnitude > 0)
            {
                float newOrientation = Mathf.Atan2(-velocity.x, velocity.y);
                return newOrientation;
            }
            else
            {
                return currentOrientation;
            }
        }

        public Vector2 GetOrientationVector()
        {
            // Radian to Vector2
            return new Vector2(-Mathf.Sin(orientation), Mathf.Cos(orientation));
        }
    }
}
