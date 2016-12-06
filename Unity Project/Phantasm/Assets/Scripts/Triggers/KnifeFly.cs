using UnityEngine;
using System.Collections;
using System;

public class KnifeFly : TriggerAction
{

    public Vector2 direction;
    public float speed;

    private bool isActive;

    public override void execute()
    {
        isActive = true;
    }

    private void Update()
    {
        if(!isActive)
        {
            return;
        }

        GetComponent<Rigidbody2D>().AddForce(direction * speed * Time.deltaTime);
        speed += 1.0f;
    }

}
