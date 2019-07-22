using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Factory.UI
{
    
    public class StorageListItem : MonoBehaviour, IPointerDownHandler
    {
        public GameObject Model;
        public GameObject Image;
        public Transform Canvas;
        public GameObject View;
        public MoveSystem MoveSystem;


        private RectTransform m_RectTransform;
        private RectTransform m_CanvasRectTransform;
        private RectTransform m_ViewRectTransform;
        private Image m_ImageDisplay;
        private Ray m_MouseRay;
        private RaycastHit m_MouseRayHit;
        private MeshRenderer m_MeshRenderer;
        private bool FirstCreat=false;

        private void Start()
        {
            m_CanvasRectTransform = Canvas.GetComponent<RectTransform>();
            m_ViewRectTransform = View.GetComponent<RectTransform>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            
            this.MoveSystem.CreateImage(Image,Canvas,View);
            this.MoveSystem.CreateModel(Model);
        }

        private void Update()
        {
            
        }
    }
}

