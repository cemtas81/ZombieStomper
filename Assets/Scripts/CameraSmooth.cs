using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.10f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // transform.LookAt(target);
    }
}
