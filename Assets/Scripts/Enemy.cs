using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    public float movementSpeed = 3f;
    [SerializeField]
    public float health = 3f;

    private MeshRenderer meshRenderer;
    private Color originalColor;

    public float minDistance = 2f;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) >= minDistance) {
            moveToPlayer();
        }
    }

    public void moveToPlayer() {
        transform.LookAt(target.position);

        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime));
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
            StartCoroutine(changeColor());
        }
    }

    private IEnumerator changeColor()
    {
        meshRenderer.material.color = Color.yellow;
        // yield says: return to main thread, renderer the frame
        // and continue from here in the next frame
        // WaitForseconds .. does exactly this
        yield return new WaitForSeconds(0.2f);

        meshRenderer.material.color = originalColor;
    }
}
