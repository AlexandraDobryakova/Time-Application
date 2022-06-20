using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject timePanel;
    public GameObject switchPanel;
    public GameObject timerPanel;

    public void ButtonTime()
    {
        mainPanel.SetActive(false);
        timePanel.SetActive(true);
    }
    public void ButtonSwitch()
    {
        mainPanel.SetActive(false);
        switchPanel.SetActive(true);
    }
    public void ButtonTimer()
    {
        mainPanel.SetActive(false);
        timerPanel.SetActive(true);
    }

}
