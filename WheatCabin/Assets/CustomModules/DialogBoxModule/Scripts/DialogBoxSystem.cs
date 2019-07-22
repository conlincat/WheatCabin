using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DialogBoxSystem : ComponentSystem {

    private Dictionary<string, GameObject> m_Members;
    private int m_Count;
    public struct Filter
    {

        public DialogBoxComponent dialogBoxComponent;
    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        foreach (var entity in GetEntities<Filter>())
        {
            m_Members.Add(entity.dialogBoxComponent.name, entity.dialogBoxComponent.gameObject);
        }
    }

    protected override void OnUpdate()
    {
        
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();
    }

    //自定义控制函数

    public void SetMemberActive(bool isActive,params string[] memberName)
    {
        foreach(var name in memberName)
        {
            if (m_Members[name]&&!m_Members[name].activeSelf)
            {
                m_Members[name].SetActive(isActive);
            }
        }
    }


}
