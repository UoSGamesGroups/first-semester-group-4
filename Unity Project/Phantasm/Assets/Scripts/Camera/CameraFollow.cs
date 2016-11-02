using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    private Vector3 velocity;

    public float leftBoundary, rightBoundary;
    public float dampTime;

    private void FixedUpdate ()
    {
	    var point = GetComponent<Camera>().WorldToViewportPoint(target.position);
	    var delta = new Vector3(target.position.x, target.position.y + 2.0f, target.position.z) -
	                    GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
	    var destination = GetComponent<Transform>().position + delta;

	    var nextPosition = Vector3.SmoothDamp(GetComponent<Transform>().position, destination,
	        ref velocity, dampTime);

        if (nextPosition.x >= leftBoundary && nextPosition.x <= rightBoundary)
        {
            GetComponent<Transform>().position = nextPosition;
        }

	}

}
