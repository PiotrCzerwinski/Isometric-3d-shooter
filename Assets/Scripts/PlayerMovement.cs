using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    [SerializeField]
    private float movementSpeed = 10.0f;
    private Vector3 forward, right;
    private GameObject cursor;
    private float distanceToGround;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cursor = GameObject.Find("MouseTarget");
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        distanceToGround = controller.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.y = 0;
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        if (heading != Vector3.zero)
        {
            controller.Move(heading * Time.deltaTime * movementSpeed);
            //controller.SimpleMove(heading * movementSpeed);
            animator.SetFloat("speed", controller.velocity.magnitude);
        }

        if (!isGrounded())
        {
            Vector3 temp = transform.position;
            temp.y = 0.05f;
            transform.position = temp;
        }

        animator.SetFloat("speed", controller.velocity.magnitude);
        //Vector3 lookingDirection = cursor.transform.position - transform.position;
        //float angle = Mathf.Atan2(lookingDirection.z, lookingDirection.x) * Mathf.Rad2Deg;
        //float shootingAngle = Mathf.Atan2(lookingDirection.z - cursor.transform.position.z, lookingDirection.x - cursor.transform.position.x) * Mathf.Rad2Deg -90f;
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        //transform.rotation = Quaternion.Euler(0, shootingAngle, 0);
    }

    bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.05f);
    }
}
