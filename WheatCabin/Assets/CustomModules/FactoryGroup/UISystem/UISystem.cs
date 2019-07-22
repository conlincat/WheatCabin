using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour {

    public PlayButton PlayButton;
    public Factory.UI.StorageList StorageList;

    //指示变量
    public bool isPlay;
    private bool StorageDirect;

    private void Awake()
    {
        Initialization();
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPlay && !StorageDirect)
        {
            StorageDirect = true;
            StorageList.gameObject.SetActive(true);
        }
        else if (isPlay && StorageDirect)
        {
            StorageDirect = false;
            StorageList.gameObject.SetActive(false);
        }
    }

    private void Initialization()
    {
        PlayButton.SetUISystem(this);
        StorageList.SetUISystem(this);
    }
}
