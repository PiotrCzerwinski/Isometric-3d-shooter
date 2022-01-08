using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    [SerializeField]
    public float movementSpeed = 0.5f;
    [SerializeField]
    public float health = 3f;
    private Vector3 forward;

    public float minDistance = 2f;

    private float distanceToGround;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Vector3.Distance(transform.position, target.transform.position) >= minDistance)
         {
             moveToPlayer();
         }*/
        //moveToPlayer();
    }
    private void FixedUpdate()
    {
        moveToPlayer();

        if (!isGrounded())
        {
            Vector3 temp = this.transform.position;
            temp.y = 0.2f;
            transform.position = temp;
        }
    }

    public void moveToPlayer() {

        Vector3 playerPosition = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        //rb.velocity += transform.forward * movementSpeed;
        rb.MovePosition(playerPosition);
        transform.LookAt(target.transform);
    }

    public void takeDamage() {

        if (health == 0)
        {
            Destroy(gameObject);
            
        }
        else {
            health--;
            Debug.Log("Taking damage");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage();
            
        }
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
}
