using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtef : MonoBehaviour
{
    public int cps;
    public GameObject endcursor;
    string targetmsg;
    Text magtxt;
    int index;

    public void setmsg(string msg)
    {
        targetmsg = msg;
        efstart();

    }

    void efstart()
    {
        magtxt.text = "";
        index = 0;
        endcursor.SetActive(false);
        StartCoroutine(efing());
    }
    IEnumerator efing()
    {
        while (magtxt.text != targetmsg)
        {
            magtxt.text += targetmsg[index];
            index++;
            yield return new WaitForSeconds(1/ cps);
        }
        yield return new WaitForSeconds(1 / cps);
        efend();
    }
    void efend()
    {
        endcursor.SetActive(true);
    }
}
