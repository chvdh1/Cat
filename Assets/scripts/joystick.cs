using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class joystick : MonoBehaviour
{
    public datamanager data;
    public GameObject bigsmall;
    public GameObject small;
    public GameObject big;
    Vector3 stickfirstpos;
    public Vector3 joyvec;
    float stickradius;
    public Vector3 depos;
    public bool moving;

    public static joystick Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        RawImage rawsmall = small.GetComponent<RawImage>();
        RawImage rawbig = big.GetComponent<RawImage>();
        rawbig.color = new Color(0.4f, 0.4f, 0.4f, 0);
        rawsmall.color = new Color(1, 1, 1, 0);
        stickradius = big.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        if (!data.moveset)
            bigsmall.SetActive(false);

    }

    public void pointdown()
    {
        big.SetActive(true);
        small.SetActive(true);
        RawImage rawsmall = small.GetComponent<RawImage>();
        RawImage rawbig = big.GetComponent<RawImage>();
        rawbig.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
        rawsmall.color = new Color(1, 1, 1, 1f);
        big.transform.position = Input.mousePosition;
        small.transform.position = Input.mousePosition;
        stickfirstpos = Input.mousePosition;
    }
    public void drag(BaseEventData baseEventData)
    {
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            Vector3 dragpos = pointerEventData.position;
            joyvec = (dragpos - stickfirstpos).normalized;

            float stickdis = Vector3.Distance(dragpos, stickfirstpos);

            if (stickdis < stickradius)
            {
                small.transform.position = stickfirstpos + joyvec * stickdis;
            }
            else
                small.transform.position = stickfirstpos + joyvec * stickradius;
    }
    public void drop()
    {
        RawImage rawsmall = small.GetComponent<RawImage>();
        RawImage rawbig = big.GetComponent<RawImage>();
        rawbig.color = new Color(0.4f, 0.4f, 0.4f, 0);
        rawsmall.color = new Color(1, 1, 1, 1);
        big.transform.position = depos;
        small.transform.position = depos;
        stickfirstpos = depos;
        joyvec = Vector3.zero;
        big.SetActive(false);
        small.SetActive(false);
    }

}
