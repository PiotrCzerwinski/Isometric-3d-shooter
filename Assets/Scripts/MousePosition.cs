using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    public Transform player;
    private Vector3 cursorPosition;
    float playerAngle;
    public float rotationSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /* Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
         Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
         float rayLength;

         if (groundPlane.Raycast(cameraRay, out rayLength))
         {
             Vector3 pointToLook = cameraRay.GetPoint(rayLength);
             Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

             player.transform.LookAt(new Vector3(pointToLook.x, 1.011f, pointToLook.z));
         }*/

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            cursorPosition = transform.position = raycastHit.point;
            player.transform.LookAt(new Vector3(cursorPosition.x, 1f, cursorPosition.z));
        }
    }
}
