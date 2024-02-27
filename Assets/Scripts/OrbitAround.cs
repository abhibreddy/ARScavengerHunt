using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform centerOfRotation; 
    public float rotationSpeed = 30f; 
    public float distanceFromCenter = 5f; 
    public float initialAngle = 0f; 

    void Start()
    {
        // Apply initial rotation based on the initial angle
        transform.RotateAround(centerOfRotation.position, Vector3.up, initialAngle);
    }

    void Update()
    {
        // Rotate around the center of rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Calculate the position relative to the center of rotation
        Vector3 offset = transform.forward * distanceFromCenter;

        // Set the position relative to the center of rotation
        transform.position = centerOfRotation.position + offset;
    }
}
