using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Tham chiếu đến transform của "Camera Target"
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Để camera luôn nhìn vào "Camera Target"
    }
}
