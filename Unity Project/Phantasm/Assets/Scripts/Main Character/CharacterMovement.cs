using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public float speed, jumpPower;
    private Vector2 velocity;

    public LayerMask lyrGround;
    public Transform feet;

    public KeyCode keyLeft, keyLeftAlt;
    public KeyCode keyRight, keyRightAlt;
    public KeyCode keyJump, keyJumpAlt;

    public bool grounded;

    private void handleInput()
    {
        if (Input.GetKey(keyLeft) || Input.GetKey(keyLeftAlt))
        {
            velocity.x = -speed;
        }
        else if (Input.GetKey(keyRight) || Input.GetKey(keyRightAlt))
        {
            velocity.x = speed;
        }
        else {
            velocity.x = 0;
        }

        if ((Input.GetKeyDown(keyJump) || Input.GetKeyDown(keyJumpAlt)) && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    private void Update ()
    {
	    grounded = Physics2D.OverlapCircle(feet.position, 0.5f, lyrGround);

        handleInput();

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, GetComponent<Rigidbody2D>().velocity.y + velocity.y);

        velocity = Vector2.zero;
    }

}
