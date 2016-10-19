using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float Speed, Jump_Power, Max_Speed;

    private Vector2 Velocity;

    public KeyCode Key_Left, Key_Left_Alt;
    public KeyCode Key_Right, Key_Right_Alt;
    public KeyCode Key_Jump, Key_Jump_Alt;

    public LayerMask Lyr_Ground;
    public Transform Tsf_Feet;

    public bool Grounded;

    void Handle_Input() {

        if (Input.GetKey(Key_Left) || Input.GetKey(Key_Left_Alt)) {
            Velocity.x = -Speed;
        }
        else if (Input.GetKey(Key_Right) || Input.GetKey(Key_Right_Alt)) {
            Velocity.x = Speed;
        }
        else {
            Velocity.x = 0;
        }

        if ((Input.GetKeyDown(Key_Jump) || Input.GetKeyDown(Key_Jump_Alt)) && Grounded) {
            Velocity.y = Jump_Power;
        }


    }

    void Add_Force(Vector2 _Force) {

    }


	void Update () {

	    Grounded = Physics2D.OverlapCircle(Tsf_Feet.position, 1.0f, Lyr_Ground);

        Handle_Input();

        GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity.x, GetComponent<Rigidbody2D>().velocity.y + Velocity.y);

	    Velocity = Vector2.zero;

	}

}
