using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float bottomClamp = -30f;
    [SerializeField] float topClamp = 60f;
    [SerializeField] int cameraAngle = 2;

    float yaw;
    float pitch;

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, bottomClamp, topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desideredPosition = target.position + rotation * offset;
        transform.position = desideredPosition;
        transform.LookAt(target.position + Vector3.up * cameraAngle);
    }
}
