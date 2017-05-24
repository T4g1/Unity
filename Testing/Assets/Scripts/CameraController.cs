using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1;
    public float sensitivity = 1;
    public float minFov;
    public float maxFov;

    private void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float zoom = Input.GetAxisRaw("Mouse ScrollWheel");

        Vector3 movement = new Vector3(transform.forward.x * vertical, 0f, transform.forward.z * vertical);
        movement += new Vector3(transform.right.x * horizontal, 0f, transform.right.z * horizontal);
        movement.Normalize();

        transform.position += movement * speed * Time.deltaTime;

        float fov = Camera.main.fieldOfView;

        fov += zoom * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);

        Camera.main.fieldOfView = fov;
    }
}
