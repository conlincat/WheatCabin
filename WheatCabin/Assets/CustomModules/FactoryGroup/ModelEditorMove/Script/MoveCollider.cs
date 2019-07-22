using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider : MonoBehaviour {

    public MoveSystem MoveSystem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ModelCollider"|| other.gameObject.tag == "Wall")
        {
            MoveSystem.SetMoveEnter(gameObject.transform.position);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ModelCollider" || other.gameObject.tag == "Wall")
        {
            MoveSystem.SetMoveStay();
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "ModelCollider" || other.gameObject.tag == "Wall")
        {
            MoveSystem.SetMoveExit(gameObject.transform.position);
        }
            
    }
}
