using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerList : MonoBehaviour {

    public ControllerListItem controllerListItem;
    public Transform Content;
    public GameObject panel_caidan;
    private float Y_Shu = 0, jishu;
    private float Loukou = 419f;
    private bool di = true;
    private Text text;


    void Start()
    {
        text = controllerListItem.gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = 0.ToString(); ;
        jishu = 0;
    }
    public void CreateControllerPlane(GameObject Model)
    {
        jishu++;
            GameObject obj = Instantiate(controllerListItem.gameObject, Content);
            obj.GetComponent<ControllerListItem>().Initialization(Model);
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
}
