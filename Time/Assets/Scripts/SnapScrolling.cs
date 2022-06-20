using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [Range(1, 100)]
    [Header("Controllers")]
    public int panCount;
    [Range(0, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f,5f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Header("Other Objects")]
    public GameObject panPrefab;
    public ScrollRect ScrollRect;

    private GameObject[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;

    private RectTransform contentRect;
    private Vector2 contentVector;


    public int selectedPanID; 
    static public int idScroll; 
    private bool isScrolling;

    public string nameOfScrolling;
    static public string letterStatic;
    
    private void Start()
    {
        
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefab, transform, false);
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i].transform.localPosition.x, 
                instPans[i - 1].transform.localPosition.y - panPrefab.GetComponent<RectTransform>().sizeDelta.y - panOffset);
            pansPos[i] = -instPans[i].transform.localPosition;
        }

        for (int i = 0; i < panCount;i++)
        {
            if (i < 10)
            {
                instPans[i].GetComponent<Text>().text = "0" + i.ToString();
            }
            else
            {
                instPans[i].GetComponent<Text>().text = i.ToString();
            }
            
        }
        letterStatic = nameOfScrolling;
    }

    private void FixedUpdate()
    {
        letterStatic = nameOfScrolling;
        if (contentRect.anchoredPosition.y <= pansPos[0].y && !isScrolling || contentRect.anchoredPosition.y >= pansPos[pansPos.Length-1].y && !isScrolling)
        {
            ScrollRect.inertia = false;
        }
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.y - pansPos[i].y);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
                idScroll = i;
            }
            float scale =Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, 0.5f, 1f);
            pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            instPans[i].transform.localScale = pansScale[i];
        }
        float scrollVelocity = Mathf.Abs(ScrollRect.velocity.y);
        if (scrollVelocity < 400 && !isScrolling)
            ScrollRect.inertia = false;
        if (isScrolling || scrollVelocity > 400) return;
        contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, pansPos[selectedPanID].y, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) ScrollRect.inertia = true;
    }

}
