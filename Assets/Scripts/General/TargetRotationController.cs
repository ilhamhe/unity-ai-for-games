using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilhamhe.UnityAIForGames
{
    public class TargetRotationController : MonoBehaviour
    {
        public Agent target;
        public float maxRotation;

        private void Update()
        {
            target.kinematic.rotation = Input.GetAxis("Horizontal") * -maxRotation;
            target.DoUpdate();
        }

    }
}
