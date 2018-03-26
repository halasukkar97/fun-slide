using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSwipe : MonoBehaviour {

    [Range(1, 36)]
    [Header("Controllers")]
    public int PanCount;
    [Range(0,650)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Header("other Objects")]
    public GameObject panPrefab;

    private GameObject[] instPans;
    private Vector2[] pansPos;

    private RectTransform contentRect;
    private Vector2 conteentVector2;


    private int selectedPandID;
    public bool isScrolling;

	// Use this for initialization
	void Start () {

        contentRect = GetComponent<RectTransform>();

        instPans = new GameObject[PanCount];
        pansPos = new Vector2[PanCount];
        for (int i = 0; i < PanCount; i++)
        {
            instPans[i] = Instantiate(panPrefab, transform, false);
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x + panOffset,
                instPans[i].transform.localPosition.y);

            //instPans[i].panel1.text = TaskPanelList[i].title;

            pansPos[i] = -instPans[i].transform.localPosition;
        }
	}


    private void FixedUpdate()
    {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < PanCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if(distance< nearestPos)
            {
                nearestPos = distance;
                selectedPandID = i;
            }
        }

        conteentVector2.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPandID].x,snapSpeed*Time.fixedDeltaTime);
  
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;


    }

}



//class TaskPanel
//{

//    string title;
//    string mainText;

//}