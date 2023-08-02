using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let camera follow target
namespace Cainos.CustomizablePixelCharacter
{
    public class CameraFollow : Singleton<CameraFollow>
    {
        public Transform target;
        public float lerpSpeed = 1.0f;
        public Vector3 offset;
        public bool onLerp = true;
        private float camZ;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;
            camZ = transform.position.z;
            transform.position = target.transform.position;
            transform.Translate(0, 0, camZ);
        }

        private void LateUpdate()
        {
            if (target == null) return;
            Vector3 camPos = transform.position;
            targetPos = target.position + offset;

            if (onLerp) camPos = Vector3.Lerp(camPos, targetPos, lerpSpeed * Time.smoothDeltaTime);
            else camPos = targetPos;

            camPos.z = camZ;
            transform.position = camPos;
        }

    }
}
