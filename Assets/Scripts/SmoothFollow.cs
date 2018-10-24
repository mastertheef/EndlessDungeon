﻿using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;
		[SerializeField]
		private float heightDamping;
        [SerializeField]
        private float zoomSpeed = 5f;

        private float minHeight = 5f;
        private float maxHeight = 20f;
        

		// Use this for initialization
		void Start() { }

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedHeight = target.position.y + height;
			var currentHeight = transform.position.y;

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

					

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                height = Mathf.Clamp(height - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, minHeight, maxHeight);
            }
		}
	}
}