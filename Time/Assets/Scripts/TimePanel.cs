using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
using System.Threading;
using Unity.Notifications.Android;

public class TimePanel : MonoBehaviour
{
    public Text dayOfWeek;
    public Text today;
    public Text timeNow;

    public GameObject mainPanel;
    public GameObject timePanel;

    void Update()
    {
        DateTime dt = DateTime.Now;
        
        if (Language.lang == "rus")
        {
            string dOw = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(dt.DayOfWeek);
            dOw = char.ToUpper(dOw[0]) + dOw.Substring(1);
            CultureInfo culture = new CultureInfo("ru-ru");
            dayOfWeek.text = dOw;
            today.text = dt.ToString("D", culture);
            timeNow.text = dt.ToString("T", culture);
        }
        else if (Language.lang == "eng")
        {
            string dOw = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetDayName(dt.DayOfWeek);
            dOw = char.ToUpper(dOw[0]) + dOw.Substring(1);
            dayOfWeek.text = dOw;
            CultureInfo culture = new CultureInfo("en-US");
            today.text = dt.ToString("M", culture) +", " + dt.Year;
            timeNow.text = dt.ToString("T", culture);
        }
        
    }

    public void CloseTimePanel()
    {
        mainPanel.SetActive(true);
        timePanel.SetActive(false);
    }

}
