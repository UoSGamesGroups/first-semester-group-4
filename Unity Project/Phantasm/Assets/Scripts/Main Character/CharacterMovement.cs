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

    public bool grounded, walking;

    private void handleInput()
    {
        if (Input.GetKey(keyLeft) || Input.GetKey(keyLeftAlt))
        {
            velocity.x = -speed;
            walking = true;
        }
        else if (Input.GetKey(keyRight) || Input.GetKey(keyRightAlt))
        {
            velocity.x = speed;
            walking = true;
        }
        else {
            velocity.x = 0;
            walking = false;
        }

        if ((Input.GetKeyDown(keyJump) || Input.GetKeyDown(keyJumpAlt)) && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    private void Update ()
    {
	    grounded = Physics2D.OverlapCircle(feet.position, 0.5f, lyrGround);
        GetComponent<Animator>().SetBool("Jumping", !grounded);
        GetComponent<Animator>().SetBool("Walking", walking);


        handleInput();

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, GetComponent<Rigidbody2D>().velocity.y + velocity.y);

        velocity = Vector2.zero;
    }

}
