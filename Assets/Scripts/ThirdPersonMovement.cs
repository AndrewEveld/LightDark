using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // https://www.youtube.com/watch?v=4HpC--2iowE&t=543s
    // https://www.youtube.com/watch?v=vdOFUFMiPDU

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Animator animator;
    public LayerMask groundLayer;
    public float jumpForce = 7f;
    public float gravity = 20f;
    public Transform cam;


    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isRunning", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(direction * speed * Time.deltaTime);
            
        } else
        {
            animator.SetBool("isRunning", false);
        }
        if (!IsGrounded())
        {
            direction.y -= gravity * Time.deltaTime;

        }
        //else if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    direction.y = jumpForce;
        //}
        controller.Move(direction.normalized * speed * Time.deltaTime);


    }

    private bool IsGrounded()
    {
        return controller.isGrounded;
    }
}
