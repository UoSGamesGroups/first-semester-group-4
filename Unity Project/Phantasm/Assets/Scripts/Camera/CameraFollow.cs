using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform Target;
    public float Damp_Time;
    private Vector3 Velocity = Vector3.zero;

    public float Left_Boundary, Right_Boundary;

	void FixedUpdate () {

	    Vector3 Point = GetComponent<Camera>().WorldToViewportPoint(Target.position);
	    Vector3 Delta = new Vector3(Target.position.x, 0, Target.position.z) -
	                    GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Point.z));
	    Vector3 Destination = GetComponent<Transform>().position + Delta;

	    Vector3 Next_Position = Vector3.SmoothDamp(GetComponent<Transform>().position, Destination,
	        ref Velocity, Damp_Time);

        if (Next_Position.x >= Left_Boundary && Next_Position.x <= Right_Boundary) {
            GetComponent<Transform>().position = Next_Position;
        }

	}

}
