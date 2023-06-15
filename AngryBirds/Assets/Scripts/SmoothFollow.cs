using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
     public Transform target;             
    public float smoothSpeed = 0.125f;   
    public float zoomAmount = 2f;        
    public float zoomSpeed = 5f;         

    private Camera cam;
    private float originalSize;
    private bool zoomed = false;         
    void Start()
    {
        cam = GetComponent<Camera>();
        originalSize = cam.orthographicSize;
    }

    void LateUpdate()
    {
       
        Vector3 desiredPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        
        if (Input.GetMouseButtonDown(0) && !zoomed)
        {
            ZoomCamera();
        }
    }

    void ZoomCamera()
    {
       
        float targetSize = originalSize / zoomAmount;

        
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);

        zoomed = true;  
    }
}


