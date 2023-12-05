using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loding : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] enemyobj;
    public GameObject[] ldingdobj;
    public Animator an;
    public Animator fadean;
    public GameObject back;
    public GameObject gamebt;

    private void Start()
    {
        StartCoroutine(anstart());
    }
    IEnumerator anstart()
    {
        yield return new WaitForSeconds(1);
        an.SetTrigger("st");
        yield return new WaitForSeconds(0.2f);
        fadean.SetTrigger("fadein");
        
    }
    public void fadeout()
    {
        fadean.SetTrigger("fadeout");
    }
    public void lodingstart()
    {
        fadean.SetTrigger("fadein");
        back.SetActive(true);
        StartCoroutine(spown());
        
        for(int  i = 0; i < ldingdobj.Length;i++)
        {
            ldingdobj[i].SetActive(true);
        }
    }
    IEnumerator spown()
    {
        for (int i = 0; i < enemyobj.Length; i++)
        {
            int ran = Random.Range(0, 7);
            ldenemy ld = enemyobj[i].GetComponent<ldenemy>();
            SpriteRenderer sprit = enemyobj[i].GetComponent<SpriteRenderer>();
            ld.sp = Random.Range(3, 8);
            ld.sc = Random.Range(2, 5);
            enemyobj[i].transform.localScale = new Vector2(ld.sc, ld.sc);
            enemyobj[i].transform.position = pos[ran].position;
            if (ran == 3)
                sprit.sortingOrder = 10;
            else if (ran == 4)
                sprit.sortingOrder = 11;
            else if (ran == 5)
                sprit.sortingOrder = 12;
            else if (ran == 6)
                sprit.sortingOrder = 13;
            else
                sprit.sortingOrder = 0;
           int qt = Random.Range(1, 3);
            yield return new WaitForSeconds(qt + 0.1f);
        }
    }
    public void lbstart()
    {
        fadean.SetTrigger("fadeout");
        gamebt.SetActive(false);
        StartCoroutine(start());
    }
    IEnumerator start()
    {
        yield return new WaitForSecondsRealtime(1.1f);
        SceneManager.LoadScene(1);
    }

}
