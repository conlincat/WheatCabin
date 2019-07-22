using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;

public class TimerSystem : ComponentSystem {

    public float totalSecond = 0;

    public struct Filter {
        public Text dateText;
        public TimerComponent timerComponent;
    }

    protected override void OnUpdate()
    {
        totalSecond += Time.deltaTime;
        string dateString = getDateString();
        foreach(var entity in GetEntities<Filter>())
        {
            entity.dateText.text = dateString;
        }
    }

    public float getTotalSecond()
    {
        return totalSecond;
    }

    public string getDateString()
    {
        string dateString="None";
        string dateDays = ((int)(totalSecond / 86400)).ToString();
        string dateHours = ((int)(totalSecond % 86400 / 3600)).ToString();
        string dateMinute = ((int)(totalSecond % 3600 / 60)).ToString();
        string dateSecond = ((int)(totalSecond % 60)).ToString();
        dateString = dateDays + "天 " + dateHours + "时 " + dateMinute + "分 " + dateSecond + "秒";
        return dateString;
    }
}
