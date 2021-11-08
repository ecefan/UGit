using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharachterController : MonoBehaviour
{

    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private AudioClip jumpSound;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;
    private float jumpTimer;
    private bool jumpPressed;
    private float jumpGracePeriod = 0.2f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalInput = 1;

        //FaceForward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //IsGrounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {   
            //Add Gravity
            velocity.y += gravity * Time.deltaTime;
        }


        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);


        //Jump
        jumpPressed = Input.GetMouseButtonDown(0);

        if (jumpPressed)
        {
            jumpTimer = Time.time;
        }
        if(isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            if(jumpSound != null)
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position, 0.5f);
            }
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpTimer = -1;
        }
        //Vertical Velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
