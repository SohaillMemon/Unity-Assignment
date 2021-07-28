using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
   [SerializeField] float lerpTime;
    [SerializeField] float panthickness = 10f;
    Vector3 newPos;
    [SerializeField] Vector2 maxLimit;
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;
    [SerializeField] float scrollSpeed = 20;

    public Transform cameraTransform;
     Vector3 newzoom;
    [SerializeField] float zoomSpeed = 20f;
    [SerializeField] Vector3 zoomAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        newzoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }


    public void CameraMove()
    {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panthickness)
        {
            newPos += transform.forward * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panthickness)
        {
            newPos -= transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panthickness)
        {
            newPos -= transform.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panthickness)
        {
            newPos += transform.right * movementSpeed * Time.deltaTime;
        }

        float a = Input.GetAxis("Mouse ScrollWheel");
        newzoom += a * zoomAmount *200f* Time.deltaTime;
        newzoom.y = Mathf.Clamp(newzoom.y, 10, 50);
        newzoom.z = Mathf.Clamp(newzoom.z, -50, -10);
        newPos.x = Mathf.Clamp(newPos.x, -maxLimit.x, maxLimit.x);
        newPos.z = Mathf.Clamp(newPos.z, -maxLimit.y, maxLimit.y);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * lerpTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newzoom, Time.deltaTime * zoomSpeed);
    }
}
