using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    public Button ButtonPlay;
    public Button ButtonStop;
    private UISystem UISystem;


	// Use this for initialization
	void Start () {
        Initialization();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //按钮事件
    public void ForPlayButton()
    {
        UISystem.isPlay = true;
        ButtonStop.gameObject.SetActive(true);
        ButtonPlay.gameObject.SetActive(false);

    }

    public void ForStopButton()
    {
        UISystem.isPlay = false;
        ButtonPlay.gameObject.SetActive(true);
        ButtonStop.gameObject.SetActive(false);
    }

    //初始化函数
    private void Initialization()
    {
        ButtonPlay.onClick.AddListener(ForPlayButton);
        ButtonStop.onClick.AddListener(ForStopButton);
        UISystem.isPlay = false;
        ButtonPlay.gameObject.SetActive(true);
        ButtonStop.gameObject.SetActive(false);
    }

    public void SetUISystem(UISystem UISystem)
    {
        this.UISystem = UISystem;
    }
}
