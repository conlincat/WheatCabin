using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPhysicsDrag : MonoBehaviour {

    public string UISystemName="UISystem";
    private UISystem UISystem;

    private Ray MouseRay;
    private RaycastHit rayInfo;
    private Camera mainCamera;
    private GameObject whitePoint;
    private GameObject dragPoint;
    private Rigidbody selfRb;
    private float objectDepth;

    //识别的时间间隔
    public float interval = 0.5f;

    private bool dragFlag = false;
    private bool isdrag = false;

    private void Awake()
    {
        UISystem = GameObject.Find("UISystem").GetComponent<UISystem>();
    }

    void Start () {
        selfRb = GetComponent<Rigidbody>();

        whitePoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Destroy(whitePoint.GetComponent<Collider>());
        Destroy(whitePoint.GetComponent<MeshRenderer>());

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        if (UISystem.isPlay)
        {
            if (Input.GetMouseButton(0))
            {
                
                MouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                LayerMask lm = 1 << 10;
                Physics.Raycast(MouseRay, out rayInfo, 100f,lm);

                if (!dragFlag && rayInfo.collider && rayInfo.collider.tag == "ModelOriginCollider" && 
                    Input.GetMouseButtonDown(0)&&rayInfo.collider.gameObject==gameObject)
                {
                    dragPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(dragPoint.GetComponent<Collider>());
                    Destroy(dragPoint.GetComponent<MeshRenderer>());
                    dragPoint.transform.SetParent(transform);

                    dragPoint.transform.position = rayInfo.point;

                    objectDepth = mainCamera.WorldToScreenPoint(rayInfo.point).z;
                    //selfRb.AddForceAtPosition(9.81f * Vector3.up*selfRb.mass, redPoint.transform.position, ForceMode.Acceleration);
                    dragFlag = true;
                    selfRb.isKinematic = false;
                }


                if (dragFlag)
                {
                    Vector3 MouseCoordinate = Input.mousePosition;
                    Vector3 ObjectCoordinate = mainCamera.WorldToScreenPoint(transform.position);
                    MouseCoordinate.z = objectDepth;
                    Vector3 UpdateCoordinate = mainCamera.ScreenToWorldPoint(MouseCoordinate);
                    Vector3 direction = UpdateCoordinate - dragPoint.transform.position;
                    //Vector3 directionForce = new Vector3(direction.x * 6f / Mathf.Pow(interval, 3f) - selfRb.velocity.x * 3 / interval,
                    //    direction.y * 6f / Mathf.Pow(interval, 3f) - selfRb.velocity.y * 3 / interval,
                    //    direction.z * 6f / Mathf.Pow(interval, 3f) - selfRb.velocity.z * 3 / interval);
                    selfRb.AddForceAtPosition(9f * Vector3.up, dragPoint.transform.position, ForceMode.Acceleration);
                    Vector3 directionForce = new Vector3(direction.x * 2f / Mathf.Pow(interval, 2f) - selfRb.velocity.x / interval,
                        direction.y * 2f / Mathf.Pow(interval, 2f) - selfRb.velocity.y / interval,
                        direction.z * 2f / Mathf.Pow(interval, 2f) - selfRb.velocity.z / interval);


                    selfRb.AddForceAtPosition(directionForce, dragPoint.transform.position, ForceMode.Acceleration);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(dragPoint);
                dragFlag = false;
            }
            if (dragFlag)
                WhitePointUpdate();
        }
	}


    private void WhitePointUpdate()
    {
        Vector3 MouseCoordinate = Input.mousePosition;
        Vector3 ObjectCoordinate = mainCamera.WorldToScreenPoint(transform.position);
        MouseCoordinate.z = ObjectCoordinate.z;
        whitePoint.transform.position = mainCamera.ScreenToWorldPoint(MouseCoordinate);
    }

}
