using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TianJia_List : MonoBehaviour {
    public GameObject panel_caidan;
    public GameObject prefab;
    public Transform content;
    private float Y_Shu=0,jishu;
    private float Loukou = 419f;
    private bool di=true;
    private Text text;
	// Use this for initialization
	void Start () {
        text = prefab.transform.GetChild(0).GetComponent<Text>();
        text.text = 0.ToString(); ;
        jishu = 0;
    }
	public void TinaJia_Start()
    {
        jishu++;
        GameObject go = Instantiate(prefab, content);
        text.text = jishu.ToString();
        if (di)
        {
            Y_Shu += 60;
            Loukou -= 30;
            panel_caidan.GetComponent<RectTransform>().localPosition = new Vector2(-649f, Loukou);
            panel_caidan.GetComponent<RectTransform>().sizeDelta = new Vector2(460.4f, Y_Shu);
            
        }
        if (Y_Shu == 960)
        {
            di = false;
        }

    }
	// Update is called once per frame
	void Update () {
       
    }
}
