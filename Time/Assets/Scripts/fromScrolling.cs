using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fromScrolling : MonoBehaviour
{
    public SnapScrolling hs;
    public SnapScrolling ms;
    public SnapScrolling ss;
    public int hour;
    public int min;
    public int sec;

     private void Update()
    {
        if (!TimerPanel.alreadyWork)
        {
            TimerPanel.sec = ss.selectedPanID;
            TimerPanel.min = ms.selectedPanID;
            TimerPanel.hour = hs.selectedPanID;
        }
        
    }
}
