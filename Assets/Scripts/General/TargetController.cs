using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class TargetController : MonoBehaviour
    {
        public Agent target;
        public float maxSpeed;

        private void Update()
        {
            target.kinematic.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            target.kinematic.velocity.Normalize();
            target.kinematic.velocity *= maxSpeed;

            target.kinematic.UpdateOrientationBasedOnCurrentvelocity();

            target.DoUpdate();
        }

    }
}
