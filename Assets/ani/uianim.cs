using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uianim : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject mesh;
    public GameObject[] sprite;
    public GameManager gm;
    public datamanager data;
    public int chapter;
    public int one;

    private void Awake()
    {
        chapter = 0;
    }
    public void activet()
    {
        gameObject.SetActive(true);
    }
    public void spritein()
    {
        if (one > 1)
            return;
        one++;
        mesh.SetActive(true);
        for (int i=0;i< sprite.Length;i++)
        {
            SpriteRenderer spriteRenderer = sprite[i].GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 1);
            sprite[i].SetActive(true);
        }
    }
    public void activef()
    {
        one = 0;
        gameObject.SetActive(false);
    }
    public void objactivef()
    {
        one = 0;
        for(int i = 0; i< obj.Length;i++)
        {
            if(obj[i] != null)
                obj[i].SetActive(false);
        }
           
    }
    public void objactivetrue()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null && !obj[i].activeSelf)
                obj[i].SetActive(true);
        }
    }
    public void allstop()
    {
        Time.timeScale = 0;
    }
    public void allgo()
    {
        Time.timeScale = 1;
    }
    public void clearUI()
    {
        if(gm.stage != 20)
            gm.compensation();
    }
    public void mainfadeout()
    {
        gm.StartCoroutine(gm.stagestart());
    }
    public void stageplus()
    {
        gm.enemyperint = 10;
        if (gm.stage == 5 || gm.stage == 10)
            gm.stageenemyint = 50;
        else if (gm.stage == 15 || gm.stage == 20)
            gm.stageenemyint = 100;
        else if (gm.stage < 20)
            gm.stageenemyint = gm.stage * gm.enemyperint;
        if (data.chapterindex != chapter && data.chapterindex != 0 &&!gm.mainonly)
        {
            chapter = data.chapterindex;
            gm.StartCoroutine(gm.maingetbuff());
            gm.mainonly = true;
        }
        gm.stageper.SetActive(true);
        gm.stageperanim.SetTrigger("dogo");
        gm.stagean.SetActive(true);
        gm.chapternametxt[0].text = gm.chaptername[data.chapterindex];
        gm.stageanim.SetTrigger("stagestart");
        gm.stage1txt.text = (data.chapterindex-1) + " - " + (gm.stage);
        gm.stage1pertxt.text = "stage" + (data.chapterindex - 1) + " - " + (gm.stage);
        gm.stagepertxt.text = gm.enemydeadint.ToString() + " / " + gm.stageenemyint.ToString();
        gm.pl.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        
    }
    public void imrepos()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].transform.position = new Vector2(-50,-100);
        }
    }
    public void moonin()
    {

    }






}
