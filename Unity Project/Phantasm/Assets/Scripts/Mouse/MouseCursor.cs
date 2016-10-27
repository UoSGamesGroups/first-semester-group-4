using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{

    public bool showCursor;

    private void Start ()
    {
	    Cursor.visible = false;
        GetComponent<SpriteRenderer>().enabled = showCursor;
    }

    private void Update ()
    {
        if (showCursor)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            GetComponent<Transform>().position = mousePosition;
        }
    }



}
