using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    float m_rAngle = 0f;
    float m_uAngle = 0f;

    [SerializeField]
    private float KeyCodeMoveMultiplier = 5f;
    [SerializeField]
    private float ScrollWheelMoveMultiplier = 80f;
    [SerializeField]
    private float RotateMultiplier = 40f;

    public void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal")* KeyCodeMoveMultiplier * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical")* KeyCodeMoveMultiplier * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * ScrollWheelMoveMultiplier * Time.deltaTime);
        if(Input.GetMouseButton(1))
            transform.rotation = Quaternion.AngleAxis(m_rAngle += Input.GetAxis("Mouse X") * RotateMultiplier *
                Time.deltaTime, Vector3.up) * Quaternion.AngleAxis(m_uAngle += Input.GetAxis("Mouse Y") * RotateMultiplier *
                Time.deltaTime, Vector3.left);


    }
}
