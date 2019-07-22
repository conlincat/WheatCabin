using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCtrl : MonoBehaviour {

    
    public float pulseSpeed = 1.5f;
    public float noiseSize = 1.0f;
    public float maxWidth = 0.5f;
    public float minWidth = 0.5f;   
    private LineRenderer lRenderer;   
    private PreFrameRaycast raycast;   //光线投射
    public Material blue_material;
    public  Material red_material;
    public Material hui_material;
    public GameObject xiaoqiu,xiaoqiu1;
    private Renderer renderer1,renderer2;
    private bool CH = false;
    void Start()
    {
        lRenderer = gameObject.GetComponent(typeof(LineRenderer)) as LineRenderer;
        raycast = gameObject.GetComponent(typeof(PreFrameRaycast)) as PreFrameRaycast;
        red_material = lRenderer.material;
        renderer1 = xiaoqiu.GetComponent<Renderer>();
        renderer2 = xiaoqiu1.GetComponent<Renderer>();
       

    }
    // Update is called once per frame
    void Update()
    {
        lRenderer.SetPosition(0, this.gameObject.transform.position);
        float aniFactor = Mathf.PingPong(Time.time * pulseSpeed, 1.0f);
        aniFactor = Mathf.Max(minWidth, aniFactor) * maxWidth;
        //设置光线的宽
        lRenderer.SetWidth(aniFactor, aniFactor);
        //光线的起点，枪口的地方

        if (raycast == null)
        {
            Debug.Log("raycast is null");
            return;
        }
        //获取光线的碰撞信息
        //RaycastHit hitInfo = raycast.GetHitInfo();
        RaycastHit hitInfo;
        Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 2.5f);
        
            //光线碰撞到物体
            if (hitInfo.transform)
            {
                if (hitInfo.transform.name == "jieshouqi")
                {
                    renderer1.material = blue_material;
                    renderer2.material = hui_material;
                    CH = true;
                }
                else if (hitInfo.transform.name == ("linezong"))
                {
                    renderer1.material = hui_material;
                    renderer2.material = hui_material;
                }
                else if (hitInfo.transform.tag == "CU" && CH)
                {
                    //renderer1.material = blue_material;
                    renderer2.material = blue_material;
                }
            lRenderer.SetPosition(1, hitInfo.point);

        }
        
        else
        {
            //float maxDist = 2.5f;
            ////当光线没有碰撞到物体，终点就是枪口前方最大距离处
            //lRenderer.SetPosition(1, this.transform.forward * maxDist);
        }
        


    }

}
