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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            cursorPosition = raycastHit.point;
            cursorPosition.y = player.position.y;
            transform.position = cursorPosition;
            player.LookAt(cursorPosition);
        }
    }
}
