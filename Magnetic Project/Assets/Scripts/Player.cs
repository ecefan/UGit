using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _runspeed = 1f;
    public CharControl2D charControl;
    public Joystick joystick;
    private float horizontalMove = 0f;
    private bool _isGrounded = false;



    private void Update()
    {
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = _runspeed;
        } else if(joystick.Horizontal <= -.2f) {
            horizontalMove = -_runspeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        if(joystick.Vertical >= 0.9f && _isGrounded == true)
        {

            charControl.Jump();
            _isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        charControl.Move(horizontalMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Magnet"))
        {
            _isGrounded = true;
        }
    }



}
