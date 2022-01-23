using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Animator animator;
    private CharacterController controller;
    [SerializeField]
    private float movementSpeed = 10.0f;
    private Vector3 forward, right;
    private float distanceToGround;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        forward =mainCamera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        distanceToGround = controller.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
      
        Vector3 rightMovement = right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        if (heading != Vector3.zero)
        {
            controller.Move(heading * Time.deltaTime * movementSpeed);
            //controller.SimpleMove(heading * movementSpeed);
            animator.SetFloat("speed", controller.velocity.magnitude);
        }
        //InvokeRepeating("printIsGrounded", 0f, 1f);

        if (!isGrounded())
        {
            Vector3 temp = transform.position;
            temp.y = 0.05f;
            transform.position = temp;
        }

        animator.SetFloat("speed", controller.velocity.magnitude);
    }
    void printIsGrounded()
    {
        Debug.Log(isGrounded());
    }
    bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.05f);
    }
}
