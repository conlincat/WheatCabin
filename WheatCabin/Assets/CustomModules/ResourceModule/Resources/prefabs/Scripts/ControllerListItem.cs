using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerListItem : MonoBehaviour {

    private RollerRoll m_RollerRoll;
    private GameObject Model;
    private string m_Name;
    public Button btn;
    private UnityEngine.UI.Text Text;




    public void Initialization(GameObject Model)
    {
        if (Model.GetComponent<RollerRoll>())
        {
            m_RollerRoll = Model.GetComponent<RollerRoll>();
            btn.onClick.AddListener(RollerRollSwitch);
        }
        this.Text = btn.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
    }

    //For RollerRoll Switch
    public void RollerRollSwitch()
    {
        if (m_RollerRoll.rollFlag && m_RollerRoll.delaySignal)
        {
            m_RollerRoll.rollFlag = false;
            //Text.text=""
        }
        
        else if(!m_RollerRoll.rollFlag&&m_RollerRoll.delaySignal)
            m_RollerRoll.rollFlag = true;
    }

}
