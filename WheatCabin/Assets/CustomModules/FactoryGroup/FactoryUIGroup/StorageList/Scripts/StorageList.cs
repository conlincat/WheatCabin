using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Factory.UI {
    public class StorageList : MonoBehaviour
    {
        [SerializeField] GameObject[] Models;// 纯模型
        [SerializeField] GameObject[] Images;//纯图片

        public GameObject StorageListItemContent;
        public Transform Canvas;
        public MoveSystem MoveSystem;
        public ControllerList controllerList;        

        private UISystem UISystem;
        private void Start()
        {
            Initialization();
        }

        private void Update()
        {
            
        }

        //外部设置UISystem
        public void SetUISystem(UISystem UISystem)
        {
            this.UISystem = UISystem;
        }

        private void Initialization()
        {
            for (int index = 0; index < Images.Length; index++)
            {
                GameObject storageListItem = Instantiate(Images[index], StorageListItemContent.transform);
                

                StorageListItem SLI = storageListItem.AddComponent<StorageListItem>();
                SLI.Model = Models[index];//临时变量
                SLI.Image = Images[index];
                SLI.Canvas = Canvas;
                SLI.View = gameObject;
                SLI.MoveSystem = this.MoveSystem;

            }
            
        }
    }
}


