using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class Agent : MonoBehaviour
    {
        public Kinematic kinematic;
        public SteeringOutput steering;

        public void Initialize()
        {
            // Initialize kinematic based on actual Transform component
            kinematic.position = transform.position;
            kinematic.orientation = transform.eulerAngles.z * Mathf.Deg2Rad;
        }

        public void DoUpdate()
        {
            kinematic.Update(steering, Time.deltaTime);
            UpdateTransform();
        }

        public void DoUpdate(float maxSpeed)
        {
            kinematic.Update(steering, maxSpeed, Time.deltaTime);
            UpdateTransform();
        }

        private void UpdateTransform()
        {
            // Updating Transform component
            transform.position = kinematic.position;
            transform.rotation = Quaternion.Euler(0, 0, kinematic.orientation * Mathf.Rad2Deg);
        }
    }
}
