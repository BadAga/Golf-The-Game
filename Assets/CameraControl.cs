using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 500.0f;
    public float movementSpeed = 5.0f;

    void Update()
    {
        CamMovement();
        CamRotation();
    }

    private void CamMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement along the camera's right and forward vectors
        Vector3 movement = (transform.right * horizontalInput + transform.forward * verticalInput) * movementSpeed * Time.deltaTime;
        transform.position += movement;
    }

    private void CamRotation()
    {
        float rotationInput = Input.GetAxis("Rotation");

        // Rotation around the camera's up vector
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
