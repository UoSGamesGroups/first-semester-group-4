using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public List<Transform> path;
    public bool looping;
    public bool active;
    
    private int current;

	private void FixedUpdate ()
	{
	    if (path.Count <= 0) return;
	    Vector2 currentPosition = GetComponent<Transform>().position;
	    Vector2 targetPosition = path[current].position;
	    if (currentPosition == targetPosition && active)
	    {
	        if (current + 1 < path.Count)
	        {
	            current++;
	        }
            else if (looping)
	        {
	            current = 0;
	        }
	    }
	    GetComponent<Transform>().position = Vector2.MoveTowards(currentPosition, targetPosition, speed*Time.deltaTime);
	}

}
