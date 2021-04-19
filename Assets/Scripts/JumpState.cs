using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour, ActionState
{
    Rigidbody2D rb2d;
    public float jumpForce = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Action()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }
}
