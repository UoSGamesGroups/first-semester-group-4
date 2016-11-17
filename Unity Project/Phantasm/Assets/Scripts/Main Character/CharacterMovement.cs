using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public KeyCode keyLeft, keyLeftAlt;
    public KeyCode keyRight, keyRightAlt;
    public KeyCode keyJump, keyJumpAlt;

    public LayerMask layerGround;
    public Transform playersFeet;

    public float walkSpeed;
    public float jumpPower;

    private Vector3 startScale;

    private enum direction
    {
        left,
        right
    }

    private void Start()
    {
       var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
       GetComponent<Transform>().position = globalState.respawnPoint;
       startScale = GetComponent<Transform>().localScale;
    }

    private void Update()
    {
        handleInput();
        animate();
    }

    private void handleInput()
    {
        if ((Input.GetKeyDown(keyJump) || Input.GetKeyDown(keyJumpAlt)) && isGrounded())
        {
            jump();
        }
        if (Input.GetKey(keyLeft) || Input.GetKey(keyLeftAlt))
        {
            walk(direction.left);
        }
        else if (Input.GetKey(keyRight) || Input.GetKey(keyRightAlt))
        {
            walk(direction.right);
        }
        else
        {
            stopWalking();
        }
    }

    private void walk(direction direction)
    {
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;
        switch (direction)
        {
            case direction.left:
                flipSprite(direction.left);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-walkSpeed * Time.deltaTime, currentVelocity.y);
                break;
            case direction.right:
                flipSprite(direction.right);
                GetComponent<Rigidbody2D>().velocity = new Vector2(walkSpeed * Time.deltaTime, currentVelocity.y);
                break;
        }
    }

    private void flipSprite(direction direction)
    {
        switch (direction)
        {
            case direction.left:
                GetComponent<Transform>().localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
                break;
            case direction.right:
                GetComponent<Transform>().localScale = new Vector3(startScale.x, startScale.y, startScale.z);
                break;
        }
    }


    private void stopWalking()
    {
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, currentVelocity.y);
    }

    private void jump()
    {
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(currentVelocity.x, currentVelocity.y + jumpPower * Time.deltaTime);
    }

    private void animate()
    {
        GetComponent<Animator>().SetBool("Jumping", !isGrounded());
        GetComponent<Animator>().SetBool("Walking", isWalking());
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(playersFeet.position, 0.1f, layerGround);
    }

    private bool isWalking()
    {
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;
        return currentVelocity.x >= 0.1f || currentVelocity.x <= -0.1f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            GetComponent<Transform>().parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            GetComponent<Transform>().parent = null;
        }
    }

}
