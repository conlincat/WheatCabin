using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSystem : MonoBehaviour {

    public string TargetCameraName = "Main Camera";
    public UISystem UISystem;
    public GameObject Mesh;
    public ControllerList controllerList;

    private GameObject m_ImageClone;
    private RectTransform m_RectTransform;
    private RectTransform m_CanvasRectTransform;
    private RectTransform m_ViewRectTransform;
    private Image m_ImageDisplay;
    private Ray m_MouseRay;
    private RaycastHit m_MouseRayHit;
    private Camera m_TargetCamera;
    private GameObject m_Model;
    private GameObject m_Collider;
    private MeshRenderer m_MeshRenderer;
    private bool FirstCreat = false;
    private bool isMove=true;
    private Dictionary<GameObject, GameObject> ModelColliderPairList = new Dictionary<GameObject, GameObject>();
    private Dictionary<GameObject, Vector3> ModelPositionList = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> ModelRotationList = new Dictionary<GameObject, Quaternion>();
    private GameObject m_Mesh;
    private Vector3 m_EnterPosition;
    private Vector3 m_ExitPosition;

    private void Start()
    {
        m_TargetCamera = GameObject.Find(TargetCameraName).GetComponent<Camera>();  
    }

    private void Update()
    {
        
        if (!UISystem.isPlay)
        {
            foreach(var item in ModelColliderPairList)
            {
                item.Value.SetActive(true);
                item.Value.transform.position = item.Key.transform.position;
                item.Key.GetComponent<Rigidbody>().isKinematic = true;
                if(ModelPositionList.ContainsKey(item.Key))
                item.Key.transform.position = ModelPositionList[item.Key];
                if(ModelRotationList.ContainsKey(item.Key))
                item.Key.transform.rotation = ModelRotationList[item.Key];
            }
            if (Input.GetMouseButton(0) && m_ImageClone)
            {
                m_RectTransform.anchoredPosition =
                    new Vector2(Input.mousePosition.x, Input.mousePosition.y) - m_CanvasRectTransform.anchoredPosition;
                if (m_RectTransform.anchoredPosition.x < m_ViewRectTransform.anchoredPosition.x - 0.5f * m_ViewRectTransform.sizeDelta.x - m_CanvasRectTransform.anchoredPosition.x
                || m_RectTransform.anchoredPosition.x > m_ViewRectTransform.anchoredPosition.x + 0.5f * m_ViewRectTransform.sizeDelta.x - m_CanvasRectTransform.anchoredPosition.x
                || m_RectTransform.anchoredPosition.y < m_ViewRectTransform.anchoredPosition.y - 0.5f * m_ViewRectTransform.sizeDelta.y - m_CanvasRectTransform.anchoredPosition.y
                || m_RectTransform.anchoredPosition.y > m_ViewRectTransform.anchoredPosition.y + 0.5f * m_ViewRectTransform.sizeDelta.y - m_CanvasRectTransform.anchoredPosition.y
                )
                {
                    m_ImageDisplay.enabled = false;
                    if(m_Model)
                    m_Model.SetActive(true);

                }
                else
                {
                    m_ImageDisplay.enabled = true;
                    if(m_Model)
                    m_Model.SetActive(false);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(m_ImageClone);
                m_Model = null;
                m_Mesh.SetActive(false);
            }
            
        }
        else
        {
            foreach(var item in ModelColliderPairList)
            {
                item.Value.SetActive(false);
            }
        }
    }

    public void ToMouseRayHit()
    {
        
        m_MouseRay = m_TargetCamera.ScreenPointToRay(Input.mousePosition);
        LayerMask lm = 1 << 8;
        Physics.Raycast(m_MouseRay, out m_MouseRayHit, 100f, lm);
        Vector3 MRHP = new Vector3();
           MRHP= m_MouseRayHit.point;

        if (isMove)
        {
            if (m_MouseRayHit.point != Vector3.zero)
            {
                m_Model.transform.position = Vector3.Lerp(m_Model.transform.position,
            new Vector3(MRHP.x - MRHP.x % 0.31f+0.1f, MRHP.y, MRHP.z- MRHP.z % 0.31f+0.1f), 0.1f);

            }
            m_Collider.transform.position = Vector3.Lerp(m_Model.transform.position,
            new Vector3(MRHP.x - MRHP.x % 0.31f + 0.1f, MRHP.y, MRHP.z - MRHP.z % 0.31f + 0.1f), 0.1f);
        }
        else
        {
            m_Model.transform.position = m_EnterPosition;
            m_Collider.transform.position = m_MouseRayHit.point;
        }

        
        m_Mesh.SetActive(true);
        

    }

    private void FixedUpdate()
    {
        if (!UISystem.isPlay&&m_Model)
        {
            if (Input.GetMouseButton(0))
            {

                if (Input.GetKey(KeyCode.V))
                    VerticalMove();
                else if (Input.GetKeyUp(KeyCode.X) )
                    ModelRotate("x");
                else if (Input.GetKeyUp(KeyCode.Y) )
                    ModelRotate("y");
                else if (Input.GetKeyUp(KeyCode.Z) )
                    ModelRotate("z");
                else if (m_Model)
                    ToMouseRayHit();
            }
            ModelPositionList[m_Model] = m_Model.transform.position;
            ModelRotationList[m_Model] = m_Model.transform.rotation;
        }
        

    }

    //旋转函数
    public void ModelRotate(string Command)
    {
        if (Command == "x")
        {
            m_Model.transform.rotation = m_Model.transform.rotation * 
                (new Quaternion(Mathf.Sqrt(2f)/2f,0,0,Mathf.Sqrt(2f)/2f));
        }
        else if (Command == "z")
        {
            m_Model.transform.rotation = m_Model.transform.rotation*
                (new Quaternion(0, 0, Mathf.Sqrt(2f) / 2f, Mathf.Sqrt(2f) / 2f));
        }
        else if (Command == "y")
        {
            m_Model.transform.rotation = m_Model.transform.rotation *
                (new Quaternion(0, Mathf.Sqrt(2f) / 2f, 0, Mathf.Sqrt(2f) / 2f));
        }
    }

    public void VerticalMove()
    {
        Vector3 MTP = new Vector3();
        MTP= m_Model.transform.position;
        if (isMove)
        {
            m_Model.transform.position = Vector3.Lerp(MTP, new Vector3(MTP.x,
            MTP.y + 5 * Input.GetAxis("Mouse Y") - (MTP.y + 5 * Input.GetAxis("Mouse Y")) % 0.2f), 0.1f);

        }
        else
        {
            m_Collider.transform.position = Vector3.Lerp(MTP, new Vector3(MTP.x,
            MTP.y + 5 * Input.GetAxis("Mouse Y") - (MTP.y + 5 * Input.GetAxis("Mouse Y")) % 0.2f), 0.1f);
        }  
    }

    //对外部函数

    //创建一个模型
    public void CreateModel(GameObject originalModel)
    {
        m_Model = Instantiate(originalModel);
        if(!m_Model.GetComponent<FactoryPhysicsDrag>())
        controllerList.CreateControllerPlane(m_Model);
        m_Collider = Instantiate(originalModel);
        if (!m_Mesh)
        m_Mesh = Instantiate(this.Mesh);
        //m_Mesh.transform.position = new Vector3(m_Mesh.transform.position.x, m_Mesh.transform.position.y+0.2f, m_Mesh.transform.position.z);
        ModelColliderPairList.Add(m_Model, m_Collider);
        m_Collider.tag = "ModelCollider";
        m_Collider.GetComponent<Collider>().isTrigger = true;
        for (int index = 0; index < m_Collider.transform.childCount; index++)
        {
            Destroy(m_Collider.transform.GetChild(index).gameObject);
        }
        m_Collider.layer = 11;
        m_Collider.AddComponent<MoveCollider>().MoveSystem = this;
        m_Model.AddComponent<ModelClickCheck>().MoveSystem = this;
    }

    //创建一张图片
    public void CreateImage(GameObject Image,Transform Canvas,GameObject View)
    {
        if (!m_ImageClone)
        {
            m_ImageClone = Instantiate(Image, Canvas);
            m_RectTransform = m_ImageClone.GetComponent<RectTransform>();
            m_ImageDisplay = m_ImageClone.GetComponent<Image>();
            m_CanvasRectTransform = Canvas.GetComponent<RectTransform>();
            m_ViewRectTransform = View.GetComponent<RectTransform>();
        }
    }

    public void RefreshModel(GameObject Model)
    {
            m_Model = Model;
            m_Collider = ModelColliderPairList[Model];
    }

    //是否物体位置更新
    public void SetMoveEnter(Vector3 enterPosition)
    {
        m_EnterPosition = enterPosition;
    }

    public void SetMoveExit(Vector3 exitPosition)
    {
        this.isMove = true;
        m_EnterPosition = exitPosition;
    }

    public void SetMoveStay()
    {
        this.isMove = false;
    }
}
