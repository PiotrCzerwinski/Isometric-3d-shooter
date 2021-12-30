using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{   
    
    private GameObject target;
    [SerializeField]
    public float movementSpeed = 3f;
    [SerializeField]
    public float health = 3f;

    public float minDistance = 2f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) >= minDistance) {
            moveToPlayer();
        }
    }

    public void moveToPlayer() {

        transform.LookAt(target.transform.position);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
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
