using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelClickCheck : MonoBehaviour {

    public MoveSystem MoveSystem;
    public string TargetCameraName="Main Camera";

    private Ray m_MouseRay;
    private RaycastHit m_MouseRayHit;
    private Camera m_TargetCamera;

    private void Start()
    {
        m_TargetCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_MouseRay = m_TargetCamera.ScreenPointToRay(Input.mousePosition);
            LayerMask lm = 1 << 10;
            Physics.Raycast(m_MouseRay, out m_MouseRayHit, 100f, lm);
            if (m_MouseRayHit.collider)
                if (m_MouseRayHit.collider.gameObject.tag == "ModelOriginCollider")
                {
                    MoveSystem.RefreshModel(m_MouseRayHit.collider.gameObject);
                }
        }
        
    }

}
