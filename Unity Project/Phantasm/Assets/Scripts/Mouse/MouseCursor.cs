using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{

    private void Start ()
    {
	    Cursor.visible = false;
	}

    private void Update ()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
	    GetComponent<Transform>().position = mousePosition;
	}

}
