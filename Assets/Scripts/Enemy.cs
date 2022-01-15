using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private GameObject gameManager;

    private Rigidbody rb;
    private GameObject target;
    [SerializeField]
    public float movementSpeed = 0.5f;
    [SerializeField]
    public float health = 3f;
    private Vector3 forward;
    [SerializeField]
    public float minDistance = 2f;

    private float distanceToGround;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.transform.position) >= minDistance)
            moveToPlayer();

        if (!isGrounded())
        {
            Vector3 temp = this.transform.position;
            temp.y = 0.05f;
            transform.position = temp;
        }
    }

    public void moveToPlayer() {

        Vector3 playerPosition = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        rb.MovePosition(playerPosition);
        transform.LookAt(target.transform);
    }

    public void takeDamage() {

        if (health == 0)
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameSystem>().enemiesCount--;

            
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
