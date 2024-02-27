using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public float rotationSpeed = 30f; 
    public float rotationRange = 15f; 

    private void Update()
    {
        // Calculate the rotation step based on time and speed
        float rotationStep = rotationSpeed * Time.deltaTime;

        // Rotate the spotlight around its own pivot
        transform.Rotate(Vector3.up, rotationStep);

        // Keep the rotation within the specified range
        float currentRotation = transform.localRotation.eulerAngles.y;

        if (currentRotation > rotationRange)
        {
            // Reverse the rotation direction if exceeding the positive range
            rotationSpeed = Mathf.Abs(rotationSpeed) * -1;
        }
        else if (currentRotation < 0 - rotationRange)
        {
            // Reverse the rotation direction if exceeding the negative range
            rotationSpeed = Mathf.Abs(rotationSpeed);
        }
    }
}
