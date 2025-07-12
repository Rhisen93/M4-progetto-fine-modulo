using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float Speed = 5f;
    Rigidbody _rb;
    Camera mainCamera;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = mainCamera.transform.forward * vertical + mainCamera.transform.right * horizontal;
        direction.y = 0f;
        direction.Normalize();

        _rb.MovePosition(_rb.position + direction * Speed * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }
     }
}
