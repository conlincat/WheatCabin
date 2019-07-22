using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerRoll : MonoBehaviour {

    public bool rollFlag = false;
    public string UISystemName = "UISystem";
    public bool delaySignal = false;

    public Rigidbody[] rollers;

    private UISystem UISystem;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        UISystem = GameObject.Find(UISystemName).GetComponent<UISystem>();
        if (tag == "ModelCollider")
        {
            Destroy(this);
        }
        
	}
	
	// Update is called once per frame
	void Update () {


        if (UISystem.isPlay && !delaySignal)
        {
            delaySignal = true;
            //rollFlag = true;
        }
        else if (!UISystem.isPlay && delaySignal)
        {
            delaySignal = false;
            //rollFlag = false;
        }
        if (rollFlag&&delaySignal)
        {
            foreach (var roller in rollers)
            {
                roller.AddTorque(Vector3.back*10f, ForceMode.VelocityChange);
            }
        }
        else
        {
            foreach (var roller in rollers)
            {
                roller.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            }
        }
	}
}
