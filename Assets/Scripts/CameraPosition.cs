using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    private Camera cam;
    private float minCameraSize = 3f;
    private float maxCameraSize = 14f;
    private float cameraSize = 4f;
    private float scrollSpeed = 2f;
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
        cameraSize += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraSize = Mathf.Clamp(cameraSize, minCameraSize, maxCameraSize);
        cam.orthographicSize = cameraSize;
    }
}
