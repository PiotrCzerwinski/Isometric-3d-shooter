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

}
