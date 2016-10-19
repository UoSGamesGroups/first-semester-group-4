using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

	void Start () {
	    Cursor.visible = false;
	}

	void Update () {

        var Mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Mouse_Position.z = 0;
	    GetComponent<Transform>().position = Mouse_Position;

	}

}
