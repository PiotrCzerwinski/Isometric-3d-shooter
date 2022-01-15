using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    private Camera cam;
    [SerializeField]
    public Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
        cam = gameObject.GetComponentInChildren(typeof(Camera)) as Camera;
        cam.transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
        
    }
}
