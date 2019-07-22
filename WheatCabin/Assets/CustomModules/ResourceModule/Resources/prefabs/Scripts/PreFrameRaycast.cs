using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFrameRaycast : MonoBehaviour {
    private RaycastHit hitInfo;
    private Transform tr;
   
    private void Awake()
    {
        tr = this.transform;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       hitInfo = new RaycastHit();
        Physics.Raycast(tr.position, tr.forward, out hitInfo,2.5f);
        
       Debug.DrawRay(tr.position, tr.forward, Color.red);
     
    }
    //返回射线的碰撞信息
    public RaycastHit GetHitInfo()
    {
        if (hitInfo.Equals(null))
        {
            Debug.LogWarning("hitInfo is null");
        }
        return hitInfo;
    }
   
}
