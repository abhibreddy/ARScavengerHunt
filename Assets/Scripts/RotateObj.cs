using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotationSpeed = 10f; 

    void Update()
    {
        // Makes the object revolve horizontally
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
