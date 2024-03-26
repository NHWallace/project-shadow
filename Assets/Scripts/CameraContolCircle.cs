using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // The target object the camera will focus on
    public float maxVerticalAngle = 45.0f; // Maximum vertical angle
    public float maxHorizontalAngle = 45.0f; // Maximum horizontal angle
    public float sensitivity = 2.0f; // Sensitivity of mouse movement

    private float currentVerticalAngle = 0.0f; // Current vertical angle
    private float currentHorizontalAngle = 0.0f; // Current horizontal angle

    void Update()
    {
        // Get input from the mouse
        float horizontalInput = Input.GetAxis("Mouse X") * sensitivity;
        float verticalInput = Input.GetAxis("Mouse Y") * sensitivity;

        // Update the current angles based on input
        currentHorizontalAngle += horizontalInput;
        currentVerticalAngle -= verticalInput;

        // Clamp the angles to the specified range
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -maxVerticalAngle, maxVerticalAngle);
        currentHorizontalAngle = Mathf.Clamp(currentHorizontalAngle, -maxHorizontalAngle, maxHorizontalAngle);

        // Calculate the new rotation of the camera
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        Quaternion verticalRotation = Quaternion.AngleAxis(currentVerticalAngle, Vector3.right);
        Quaternion horizontalRotation = Quaternion.AngleAxis(currentHorizontalAngle, Vector3.up);

        // Combine the rotations
        Quaternion finalRotation = targetRotation * horizontalRotation * verticalRotation;

        // Apply the rotation to the camera
        transform.rotation = finalRotation;
    }
}
