using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;


public class SwitchPanel : MonoBehaviour
{
    //AndroidNotification notification = new AndroidNotification();

    public GameObject mainPanel;
    public GameObject switchPanel;

    private int sec = 0;
    private int min = 0;
    public Text switchText;
    private int delta = 0;

    public GameObject buttonStart;
    public GameObject buttonStop;
    public GameObject buttonRecet;

    void Start()
    {
        StartCoroutine(TimeFlow());
    }


    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec+= delta;
            switchText.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void StartStop(int delta)
    {
        this.delta = delta;

    }

    public void RecetButton()
    {
        delta = 0;
        buttonRecet.SetActive(false);
        buttonStop.SetActive(false);
        buttonStart.SetActive(true);
        min = 0;
        sec = 0;
        switchText.text = min.ToString("D2") + ":" + sec.ToString("D2");
    }

    public void ButtonsStartAndStop()
    {
        if (delta == 0)
        {
            buttonStop.SetActive(false);
            buttonStart.SetActive(true);
        }
        else
        {
            buttonStop.SetActive(true);
            buttonStart.SetActive(false);
            buttonRecet.SetActive(true);
        }
    }

    public void CloseTimePanel()
    {
        mainPanel.SetActive(true);
        switchPanel.SetActive(false);
    }
}
