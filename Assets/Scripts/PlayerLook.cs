using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public float mouseSensitivity = 100;

    private float pitch;
    private float yaw;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        pitch += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        while (yaw < 0f)
        {
            yaw += 360f;
        }
        while (yaw >= 360f)
        {
            yaw -= 360f;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
