using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class buttonmanager : MonoBehaviour
{
    public GameManager gm;
    public player pl;
    public datamanager data;

    public GameObject thisobj;
    int min;
    int max;
    public string catlv;
    public string catlvup;
    public float cztime;
    public int posin;
    public int setreposint;
    public Text[] czcounttxt;
    public bool onlycz;
    public int[] czcount;
    public bool fullbuff;
    public bool[] posck;
    public GameObject exit;


    //�κ�� 
    public GameObject btchoise, btchoise1;
    public Image[] stagemovebt;
    public Animator[] moonset;
    public bool ismoon;
    public GameObject[] stageim;
    public int stage;
    public GameObject dataobj;
    public GameObject[] moonobj;
    public Animator moontxt;

    public GameObject[] baceui;
    public GameObject[] ui1;
    public GameObject[] ui11;
    public GameObject[] ui2;
    public int[] only;
    public int[] onlyshop;
    public Image[] shopnpc;
    public Text selcoin;
    public int onlyczweapon;
    public int onlytypeint;
    public GameObject[] ui3;
    public GameObject[] ui4;
    public GameObject[] maincatweaponpos;
    public GameObject[] uiexitbt;
    public GameObject information;
    public GameObject[] informationpos;
    public Text informationtxt;
    public Text[] ui1imformationtxt;
    public Text[] ui2imformationtxt;
    public Text[] ui3imformationtxt;
    public Text[] ui4imformationtxt;

    public GameObject battleinven;
    public GameObject[] menuui;
    public GameObject joystickobj;
    public Text movetxt;
    public Text[] code;
    public InputField adfasdf;
    public bool[] ui1bool;
    public float[] ability;
    public float[] plability;
    public Text[] plui;

    public static buttonmanager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(lobby());
    }
    // �κ��
    IEnumerator lobby()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        if (SceneManager.GetActiveScene().buildIndex == 1)
            gm.fadeanim.SetTrigger("mainin");
        
        StartCoroutine(savedata());
    }
    IEnumerator savedata()
    {
        if (data.uiopening[3])
        {
            moonobj[0].SetActive(false);
            moonobj[1].SetActive(false);
            moonobj[2].SetActive(false);
            moonobj[3].SetActive(true);
        }
        else if (data.uiopening[2])
        {
            moonobj[0].SetActive(false);
            moonobj[1].SetActive(false);
            moonobj[2].SetActive(true);
            moonobj[3].SetActive(false);
        }
        else if (data.uiopening[1])
        {
            moonobj[0].SetActive(false);
            moonobj[1].SetActive(true);
            moonobj[2].SetActive(false);
            moonobj[3].SetActive(false);
        }
        else
        {
            moonobj[0].SetActive(true);
            moonobj[1].SetActive(false);
            moonobj[2].SetActive(false);
            moonobj[3].SetActive(false);
        }
        for (int t = 0; t < data.uiopening.Length; t++)
        {
            if (data.uiopening[t] == true)
                moonobj[t + 7].SetActive(true);
            else
                moonobj[t + 7].SetActive(false);
        }
        for (int t = 1; t < data.uiopening.Length; t++)
        {
            if (data.uiopening[t] == true)
                moonobj[t + 3].SetActive(true);
            else
                moonobj[t + 3].SetActive(false);
        }
        baceui[4].SetActive(true);
        baceui[5].SetActive(true);
        for (int i = 0; i < ui1bool.Length; i++)
        {
            if (data.ui1bool[i])
            {
                ui1bool[i] = true;
                Image image = ui1[i].GetComponent<Image>();
                image.color = new Color(1, 1, 1, 1);
                if (i != 2 && i != 5 && i != 8 && i != 11 && i != 13
                    && i != 15 && i != 17 && i != 19 && i != 21 && i != 24
                    && i != 27 && i != 30 && i != 31 && i != 32)
                {
                    Image image1 = ui1[i + 1].GetComponent<Image>();
                    image1.color = new Color(1, 1, 1, 0.2f);
                }
                else if (i == 32 && !ui1bool[32] && ui1bool[24] && ui1bool[27] && ui1bool[30])
                {
                    Image image1 = ui1[32].GetComponent<Image>();
                    image1.color = new Color(1, 1, 1, 0.2f);
                }
                else if (i == 31 && !ui1bool[31] && ui1bool[24] && ui1bool[27] && ui1bool[30])
                {
                    Image image1 = ui1[31].GetComponent<Image>();
                    image1.color = new Color(1, 1, 1, 0.2f);
                }
                else if (i == 20 && !ui1bool[20] && ui1bool[13] && ui1bool[15])
                {
                    Image image1 = ui1[20].GetComponent<Image>();
                    image1.color = new Color(1, 1, 1, 0.2f);
                }
            }
            else
            { ui1bool[i] = false; }
        }
        only[7] = -1;
        StartCoroutine(qnghkf());
        yield return new WaitForSeconds(0.2f);
    }
    public void nextpage()
    {
        stage = 0;
        btchoise.SetActive(true);
        btchoise1.SetActive(true);
        exit.SetActive(true);
        stageim[stage].SetActive(true);
        for (int o = 0; o < baceui.Length; o++)
            baceui[o].SetActive(false); 
        for (int i = 0; i < stageim.Length; i++)
        {
            if (i == stage)
                stageim[stage].SetActive(true);
            else
                stageim[i].SetActive(false);
        }
    }
    public void nextbt()
    {
        if (stage == stageim.Length - 1)
            return;
        else
        {
            stage++;
            for (int i = 0; i < stageim.Length; i++)
            {
                if (i == stage)
                    stageim[stage].SetActive(true);
                else
                    stageim[i].SetActive(false);
            }
        }
        colorchange();
    }
    public void next1bt()
    {
        if (stage == 0)
            return;
        else
        {
            stage--;
            for (int i = 0; i < stageim.Length; i++)
            {
                if (i == stage)
                    stageim[stage].SetActive(true);
                else
                    stageim[i].SetActive(false);
            }
        }
        colorchange();
    }
    public void colorchange()
    {
        if (stage == 0)
            stagemovebt[0].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        else if (stage == stageim.Length - 1)
            stagemovebt[1].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        else
        {
            stagemovebt[0].color = new Color(1, 1, 1, 1);
            stagemovebt[1].color = new Color(1, 1, 1, 1);
        }
    }
    
    public void exitbt()//�����ư
    {
        uiexitbt[4].SetActive(false);
        gm.setinven[22].SetActive(false);
        gm.nearobj = null;
        gm.wpnearobj = null;
        only[7] = -1;
        onlytypeint = -1;
        if (data.chapterindex == 0)
        {
            if(ismoon)
            {
                baceui[0].SetActive(true);
                baceui[1].SetActive(true);
                baceui[2].SetActive(true);
                baceui[3].SetActive(true);
                baceui[4].SetActive(false);
                baceui[5].SetActive(true);
                baceui[6].SetActive(true);
            }
            else if(!ismoon)
            {
                baceui[0].SetActive(false);
                baceui[1].SetActive(false);
                baceui[2].SetActive(false);
                baceui[3].SetActive(false);
                baceui[4].SetActive(true);
                baceui[5].SetActive(true);
                baceui[6].SetActive(false);
            }
            btchoise.SetActive(false);
            btchoise1.SetActive(false);
            if(only[6] != -1)
                gm.btcat[only[6]].SetActive(false);
            if (only[2] != -1)
                gm.btweapon[only[2]].SetActive(false);
            Time.timeScale = 1;
        }
        else
            battleinven.SetActive(true);

        for(int e = 11; e < gm.setinven.Length;e++)
        {
            gm.setinven[e].SetActive(false);
        }
       

        if (!gm.shop[0].activeSelf && !gm.unknown[2].activeSelf
            && !gm.Evolution[0].activeSelf)
        {
            Time.timeScale = 1;
            baceui[5].SetActive(true);
            for (int t = 0; t < uiexitbt.Length; t++)
            { uiexitbt[t].SetActive(false); }
            for (int a = 0; a < menuui.Length; a++)
            { menuui[a].SetActive(false); }
            gm.inven[12].SetActive(true);
            invenbt();
            information.SetActive(false);
        }
        else
        {
            for (int a = 0; a < menuui.Length; a++)
            { menuui[a].SetActive(false); }
            if (gm.inven[12].activeSelf == true)
                invenbt();
        }
    }
    //����
    public void close()
    {
        gm.fade.SetActive(true);
        gm.fadeanim.SetTrigger("mainout");
        data.chapterindex = 2;
        StartCoroutine(battlepage());
    }
    //��
    public void forest()
    {
        if (data.stage[0])
        {
            gm.fade.SetActive(true);
            gm.fadeanim.SetTrigger("mainout");
            data.chapterindex = 3;
            StartCoroutine(battlepage());
        }
        else
        {
            moontxt.SetTrigger("moontext");
        }
        
    }
    //������ ��
    public void gloomyforest()
    {
        if (data.stage[1])
        {
            gm.fade.SetActive(true);
            gm.fadeanim.SetTrigger("mainout");
            data.chapterindex = 4;
            StartCoroutine(battlepage());
        }
        else
        {
            moontxt.SetTrigger("moontext");
        }
    }
    //����
    public void Cemetry()
    {
        if (data.stage[2])
        {
            gm.fade.SetActive(true);
            gm.fadeanim.SetTrigger("mainout");
            data.chapterindex = 5;
            StartCoroutine(battlepage());
        }
        else
        {
            moontxt.SetTrigger("moontext");
        }
    }
    public GameObject MoonBtn;
    IEnumerator battlepage()
    {
        gm.nearint = -100;
        exitbt();
        for (int i =0;i< baceui.Length-1;i++)
            if (i != baceui.Length - 2)
                baceui[i].SetActive(false);
        MoonBtn.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(data.chapterindex);

    }
    public void moonin()
    {
        if (ismoon)
            return;

        for(int i = 0; i < moonset.Length;i++)
            moonset[i].SetTrigger("moonin");
        baceui[4].SetActive(false);
        ismoon = true;
        StartCoroutine(backbt());
    }
    IEnumerator backbt()
    {
        yield return new WaitForSecondsRealtime(2);
        baceui[6].SetActive(true);
        baceui[0].SetActive(true);
        baceui[1].SetActive(true);
        baceui[2].SetActive(true);
        baceui[3].SetActive(true);
    }
    public void moonout()
    {
        if (!ismoon)
            return;

        for (int i = 0; i < moonset.Length; i++)
            moonset[i].SetTrigger("moonout");
        StartCoroutine(fightbt());
        ismoon = false;
        baceui[6].SetActive(false);
        baceui[0].SetActive(false);
        baceui[1].SetActive(false);
        baceui[2].SetActive(false);
        baceui[3].SetActive(false);
    }
    IEnumerator fightbt()
    {
        yield return new WaitForSecondsRealtime(2);
        baceui[4].SetActive(true);
    }

    public void uione()//xmrtjdƯ��
    {
        if (!data.uiopening[0])
            return;

        uiexitbt[0].SetActive(true);
        uiexitbt[4].SetActive(true);
        ui1imformationtxt[2].text = pl.soul.ToString();
        ui1imformationtxt[0].text =
                "��ȥ����\n" + "�����ϸ�\n" + "��\n" + "������ ��\n" + "�־�!";
        for (int i = 0; i < baceui.Length; i++)
        { baceui[i].SetActive(false); }
        if (gm.inven[12].activeSelf == true)
            invenbt();
    }
    public void uitwo()//����anrl
    {
        if (!data.uiopening[1])
            return;
        uiexitbt[1].SetActive(true);
        uiexitbt[4].SetActive(true);
        if (only[2]!=-1)
            gm.btweapon[only[2]].SetActive(true);
        ui2imformationtxt[2].text = pl.soul.ToString();
        if (only[0] == 0)
        {
            ui2imformationtxt[0].text =
               "�� �̾ƺ�!\n" + "ū ������\n" + "�� �ž�";
            ui2imformationtxt[1].text = "�̱�!";
        }
        else if (only[0] == 1 && ui1bool[31])
        {
            ui2imformationtxt[0].text =
                "�� �� ��\n" + "�̾ƺ���?\n" + "��ȥ�� 200��\n" + "�����ϸ� ��!";
            ui2imformationtxt[1].text =
                "200�����ϰ�\n" + "�� �� ��!";
        }
        else if (only[0] > 1 && ui1bool[31])
        {
            ui2imformationtxt[0].text =
               "�� ������\n" + "�����!\n" + "������\n" + "�� ��!";
            ui2imformationtxt[1].text =
                "����!";
        }
        for (int i = 0; i < baceui.Length; i++)
        { baceui[i].SetActive(false); }
        if (gm.inven[12].activeSelf == true)
            invenbt();
    }
    public void uithree()//����siddl
    {
        if (!data.uiopening[2])
            return;
        uiexitbt[2].SetActive(true);
        uiexitbt[4].SetActive(true);
        if (only[6] != -1)
            gm.btcat[only[6]].SetActive(true);
        ui3imformationtxt[2].text = pl.soul.ToString();
        if (only[5] == 0)
        {
            ui3imformationtxt[0].text =
               "�� � �������\n" + "������ �ñ�����\n" + "�ʾ�?";
            ui3imformationtxt[1].text = "�ñ���!";
        }
        else if (only[5] == 1 && ui1bool[32])
        {
            ui3imformationtxt[0].text =
                "�� �� ��\n" + "Ȯ���غ���?\n" + "��ȥ�� 200��\n" + "�����ϸ� ��!";
            ui3imformationtxt[1].text =
                "200�����ϰ�\n" + "�� �� ��!";
        }
        else if (only[5] > 1 && ui1bool[32])
        {
            ui3imformationtxt[0].text =
               "���ݵ�\n" + "�����!\n�̻ڴ�!\n" + "������\n" + "�� ��!";
            ui3imformationtxt[1].text =
                "���� ��ȸ��!";
        }
        for (int i = 0; i < baceui.Length; i++)
        {
            baceui[i].SetActive(false);
        }
        if (gm.inven[12].activeSelf == true)
            invenbt();
    }
    public void uifour()//����qjvm
    {
        if (!data.uiopening[3])
            return;
        uiexitbt[3].SetActive(true);
        uiexitbt[4].SetActive(true);
        ui4imformationtxt[0].text =
                 "�پ��� ��������\n" + "������ ��������\n���� ����ž�\n" +
                 "ū ������ �� ��\n �𸣰�����\n �ܱⰣ ������\n" +
                 "�Ǵ� ���� �ٰ�!";
        ui4imformationtxt[1].text = "����!!";
        for (int i = 0; i < baceui.Length; i++)
            baceui[i].SetActive(false);
        if (gm.inven[12].activeSelf == true)
            invenbt();
    }
    public void getbuff()//eksrlqjvm�ܱ����
    {
        if (data.mainbool[17] == 0)
        {
            int ran = Random.Range(0, 3);
            if (ran < 1)
            {
                ui4[0].SetActive(true);
                ui4imformationtxt[0].text =
                    "�ܱⰣ\n" + "������ �����\n ��ž�!\n������ �ٳ��!";
                ui4imformationtxt[2].text = "3�а� �������� ġ��Ÿ Ȯ�� 2��";
                data.mainbool[17] = 1;

            }
            else if (ran < 2)
            {
                ui4[1].SetActive(true);
                ui4imformationtxt[0].text =
                    "�ܱⰣ\n" + "�����ϰ�\n�̵��� ��\n �����ž�!\n������ �ٳ��!";
                ui4imformationtxt[2].text = "3�а� �̵��ӵ��� ���ݼӵ� 2��";
                data.mainbool[17] = 2;
            }
            else if (ran < 3)
            {
                ui4[2].SetActive(true);
                ui4imformationtxt[0].text =
                    "�ܱⰣ\n" + "�Ⱦ���������\n�� ���� ȹ���� ��!\n �����ž�!\n������ �ٳ��!";
                ui4imformationtxt[2].text = "3�а� �Ⱦ� ������ Ȯ�淮 2��";
                data.mainbool[17] = 3;
            }
        }
    }
    public void catdraw()//siddl chrlghk���� �ʱ�ȭ
    {
        if (only[5] == 0)
        {
            while (only[6] < 0)
            {
                int ran = Random.Range(0, gm.btcat.Length);
                item item = gm.btcat[ran].GetComponent<item>();
                if (gm.invennum[9] != item.velue)
                {
                    gm.btcat[ran].SetActive(true);
                    gm.btcat[ran].transform.position =
                        maincatweaponpos[1].transform.position;
                    only[6] = item.velue;
                    gm.nearint = item.velue;
                    only[5]++;
                }
            }
            if (!ui1bool[32])
            {
                ui3imformationtxt[0].text =
               "���ݵ�\n" + "�����!\n�̻ڴ�!\n" + "������\n" + "�� ��!";
                ui3imformationtxt[1].text = "���� ��ȸ��!";
            }
            else if (ui1bool[32])
            {
                ui3imformationtxt[0].text =
                 "�� �� ��\n" + "Ȯ���غ���?\n" + "��ȥ�� 200��\n" + "�����ϸ� ��!";
                ui3imformationtxt[1].text = "200�����ϰ�\n" + "�� �� ��!";
            }
        }
        else if (only[5] == 1 && ui1bool[32] && pl.soul >= 200)
        {
            gm.nearint = -100;
            while (only[5] == 1)
            {
                int ran = Random.Range(0, gm.btcat.Length);
                item item = gm.btcat[ran].GetComponent<item>();
                if (gm.invennum[9] != gm.nearint && gm.invennum[9] != ran)
                {
                    gm.btcat[gm.nearint].SetActive(true);
                    gm.btcat[gm.nearint].transform.position =
                        maincatweaponpos[1].transform.position;
                    
                    only[6] = item.velue;
                    gm.nearint = item.velue;

                    ui3imformationtxt[0].text =
                        "���ݵ�\n" + "�����!\n�̻ڴ�!\n" + "������\n" + "�� ��!";
                    ui3imformationtxt[1].text ="���� ��ȸ��!";
                    pl.soul -= 200;
                    ui3imformationtxt[2].text = pl.soul.ToString();

                    only[5]++;
                }
            }
        }
        data.jsondata.Save();
    }
    public void draw()
    {
        if (only[0] == 0)
        {
            only[0]++;
            int ran = Random.Range(0, 36);
            ui2[ran].SetActive(true);
            ui2[ran].transform.position =
                maincatweaponpos[0].transform.position;
            item item = ui2[ran].GetComponent<item>();
            only[2] = item.velue;
            if (!ui1bool[31])
            {
                ui2imformationtxt[0].text =
               "�� ������\n" + "�����!\n" + "������\n" + "�� ��!";
                ui2imformationtxt[1].text ="����!";
            }
            else if (ui1bool[31])
            {
                ui2imformationtxt[0].text =
                "�� �� ��\n" + "�̾ƺ���?\n" + "��ȥ�� 200��\n" + "�����ϸ� ��!";
                ui2imformationtxt[1].text = "200�����ϰ�\n" + "�� �� ��!";
            }

        }
        else if (only[0] == 1 && ui1bool[31] && pl.soul >= 200)
        {
            while (only[0] == 1)
            {
                int ran1 = Random.Range(0, 36);
                item item = ui2[ran1].GetComponent<item>();
                if (data.mainbool[14] != item.velue && only[2] != item.velue)
                {
                    ui2[ran1].SetActive(true);
                    ui2[ran1].transform.position = maincatweaponpos[0].transform.position;
                    ui2imformationtxt[0].text = "�� ������\n" + "�����!\n" + "������\n" + "�� ��!";
                    ui2imformationtxt[1].text = "����!";
                    pl.soul -= 200;
                    only[0]++;
                }
            }
        }
        data.jsondata.Save();
    }//�������ʱ�ȭ
    void inforim()
    {
        item item = gm.nearobj.GetComponent<item>();

        if(item.typeint ==1)
            for (int i = 0; i < 100; i++)
            {
                if (i < gm.imweapon.Length)
                {
                    if (i == item.velue)
                        gm.imweapon[i].SetActive(true);
                    else
                        gm.imweapon[i].SetActive(false);
                }
                if (i < gm.imcat.Length)
                    gm.imcat[i].SetActive(false);
                if (i < gm.imbullet.Length)
                    gm.imbullet[i].SetActive(false);
            }
        else if (item.typeint == 2)
            for (int i = 0; i < 100; i++)
            {
                if (i < gm.imweapon.Length)
                    gm.imweapon[i].SetActive(false);
                if (i < gm.imcat.Length)
                {
                    if (i == item.velue)
                        gm.imcat[i].SetActive(true);
                    else
                        gm.imcat[i].SetActive(false);
                }
                if (i < gm.imbullet.Length)
                    gm.imbullet[i].SetActive(false);
            }
        else if (item.typeint == 3)
            for (int i = 0; i < 100; i++)
            {
                if (i < gm.imweapon.Length)
                    gm.imweapon[i].SetActive(false);
                if (i < gm.imcat.Length)
                    gm.imcat[i].SetActive(false);
                if (i < gm.imbullet.Length)
                {
                    if (i == item.velue)
                        gm.imbullet[i].SetActive(true);
                    else
                        gm.imbullet[i].SetActive(false);
                }
            }
    }
    public void btinformation()//����â
    {
        gm.nearobj = EventSystem.current.currentSelectedGameObject;
        item item = gm.nearobj.GetComponent<item>();
        for (int i = 11; i < gm.setinven.Length; i++)
            gm.setinven[i].SetActive(false);
        informationtxt.text
                      = item.weaponname + "\n" + item.vltype +
                      "\n" + item.weaponinformation.ToString();
        if (gm.nearobj.gameObject.tag == "shotweapon")
        {
            gm.sellweaponbt.SetActive(false);
            gm.wpnearobj = gm.nearobj;
            inforim();
        }
        else if (gm.nearobj.gameObject.tag == "weapon")
        {
            float getcoin = item.thiscoin / 5 * pl.plui[6] * pl.maindata[10];
            selcoin.text = string.Format("{0:n0}", "���� "+(int)getcoin+"+");
            gm.wpnearobj = gm.nearobj;
            for (int ipos = 0;  ipos< informationpos.Length;ipos++)
            {
                for (int i = 0; i < item.wphasset.Length; i++)
                {
                    if (item.wphasset[i] != 0 && !gm.setinven[i + 11].activeSelf)
                    {
                        gm.setinven[i + 11].transform.localScale = new Vector2(0.45f, 0.45f);
                        gm.setinven[i + 11].transform.position = informationpos[ipos].transform.position;
                        gm.setinven[i + 11].SetActive(true);
                        break;
                    }
                }
            }
            inforim();
        }
        else if(gm.nearobj.gameObject.tag == "cat")
        {
            gm.wpnearobj = gm.nearobj;
            if (item.vltype.Equals("���"))
            {
                gm.weapontypecoin = 30;
                catlv = "������, �̵��ӵ�, ����, ���� 100%";
                catlvup = "������ 100% ��120%";
            }

            else if (item.vltype.Equals("����"))
            {
                gm.weapontypecoin = 60;
                catlv = "������, �̵��ӵ�, ����, ���� 120%";
                catlvup = "������ 120% ��150%";
            }
            else if (item.vltype.Equals("����ũ"))
            {
                gm.weapontypecoin = 120;
                catlv = "������, �̵��ӵ�, ����, ���� 150%";
                catlvup = "������ 150% ��200%";
            }
               
            else if (item.vltype.Equals("����"))
            {
                gm.weapontypecoin = 250;
                catlv = "������, �̵��ӵ�, ����, ���� 200%";
            }
              
            for (int e = 11; e < gm.setinven.Length; e++)
                gm.setinven[e].SetActive(false);
            float getchuroo = gm.weapontypecoin* pl.plui[6] * pl.maindata[10];
            selcoin.text = string.Format("{0:n0}", "�� "+(int)getchuroo+"+");
           
           

            if (gm.Evolution[0].activeSelf)
                informationtxt.text
                    = item.weaponname + "\n" + item.vltype +
                    "\n" + item.weaponinformation.ToString() +
                    "\n" + catlv+ "\n"+catlvup;
            else
                informationtxt.text
                  = item.weaponname + "\n" + item.vltype +
                  "\n" + item.weaponinformation.ToString() +
                  "\n" + catlv;
        }
        
        if (only[7] == item.velue && onlytypeint == item.typeint)
        {
            if (!gm.unknown[2].activeSelf && !gm.shop[0].activeSelf && !gm.Evolution[0].activeSelf)
            information.SetActive(false);

            gm.wpnearobj = null;
            only[7] = -1;
            onlytypeint = -1;
            gm.nearobj = null;

            if (!gm.Evolution[0].activeSelf)
                inforsel();
            else
            {
                if ((int)pl.catlv[0] == 0)
                {
                    catlv = "������, �̵��ӵ�, ����, ���� 100%";
                    catlvup = "������ 100% ��120%";
                }

                else if ((int)pl.catlv[0] == 1)
                {
                    catlv = "������, �̵��ӵ�, ����, ���� 120%";
                    catlvup = "������ 120% ��150%";
                }
                else if ((int)pl.catlv[0] == 2)
                {
                    catlv = "������, �̵��ӵ�, ����, ���� 150%";
                    catlvup = "������ 150% ��200%";
                }

                else if ((int)pl.catlv[0] == 3)
                    catlv = "������, �̵��ӵ�, ����, ���� 200%";
                
                for (int e = 11; e < gm.setinven.Length; e++)
                    gm.setinven[e].SetActive(false);

                for (int i = 0; i < 100; i++)
                {
                    if (i < gm.imweapon.Length)
                        gm.imweapon[i].SetActive(false);
                    if (i < gm.imcat.Length)
                    {
                        if (i == gm.invennum[9])
                            gm.imcat[i].SetActive(true);
                        else
                            gm.imcat[i].SetActive(false);
                    }
                    if (i < gm.imbullet.Length)
                        gm.imbullet[i].SetActive(false);
                }

                item cat = gm.btcat[gm.invennum[9]].GetComponent<item>();

                informationtxt.text
                    = cat.weaponname + "\n" + cat.vltype +
                    "\n" + cat.weaponinformation.ToString() +
                    "\n" + catlv + "\n" + catlvup;

                gm.sellweaponbt.SetActive(false);
                gm.buyweaponbt.SetActive(false);
                gm.getweaponbt.SetActive(false);
            }
        }
        else
        {
            information.SetActive(true);
            only[7] = item.velue;
            onlytypeint = item.typeint;
            
            if (gm.inven[12].activeSelf)
            {
                if(gm.nearobj.gameObject.tag == "weapon")
                    gm.sellweaponbt.SetActive(true);
                else
                    gm.sellweaponbt.SetActive(false);
                gm.buyweaponbt.SetActive(false);
                gm.getweaponbt.SetActive(false);
            }
            else if (gm.theshop)
            {
                gm.sellweaponbt.SetActive(false);
                gm.buyweaponbt.SetActive(true);
                gm.getweaponbt.SetActive(false);
            }
            else if (gm.theunkown)
            {
                gm.sellweaponbt.SetActive(false);
                gm.buyweaponbt.SetActive(false);
                gm.getweaponbt.SetActive(true);
            }
            else if (data.chapterindex == 0)
            {
                gm.sellweaponbt.SetActive(false);
                gm.buyweaponbt.SetActive(false);
                gm.getweaponbt.SetActive(true);
            }
            else if (data.chapterindex >= 1)
            {
                gm.sellweaponbt.SetActive(true);
                gm.buyweaponbt.SetActive(false);
                gm.getweaponbt.SetActive(true);
            }
            for (int i = 0; i < 100; i++)
            {
                if (i < gm.imweapon.Length && onlytypeint != item.typeint)
                    gm.imweapon[i].SetActive(false);
                if (i < gm.imcat.Length && onlytypeint != item.typeint)
                    gm.imcat[i].SetActive(false);
                if (i < gm.imbullet.Length && onlytypeint != item.typeint)
                    gm.imbullet[i].SetActive(false);
            }
        }
    }//��ư����
    public void getweapon()//ȹ���ư
    {
        pl.interation();
        inforsel();
        Time.timeScale = 1;
        pl.StartCoroutine(pl.txt());
    }
    public void invenbt() // �κ���ư
    {
        pl.StartCoroutine(pl.txt());
        inforsel();
        if (!gm.inven[12].activeSelf)
        {
            Time.timeScale = 0;
            gm.inven[12].SetActive(true);
            if (!gm.unknown[2].activeSelf && !gm.shop[0].activeSelf
                && !gm.Evolution[0].activeSelf)
            {
                gm.information.SetActive(false);
                for (int i = 0; i < 100; i++)
                {
                    if (i < gm.btweapon.Length)
                        gm.imweapon[i].SetActive(false);
                    if (i < gm.btcat.Length)
                        gm.imcat[i].SetActive(false);
                    if (i < gm.btbullet.Length)
                        gm.imbullet[i].SetActive(false);
                    if (i < gm.setinven.Length - 1 && i >= 11)
                        gm.setinven[i].SetActive(false);
                }
            }
               
            exit.SetActive(true);
            gm.setinvennextint = 0;
            StartCoroutine(setpos());
            for (int i = 0; i < gm.invennum.Length;i++)
            {
                if (gm.invennum[i] != -1)
                {
                    if (i < 9)
                    {
                        gm.btweapon[gm.invennum[i]].SetActive(true);
                        gm.btweapon[gm.invennum[i]].transform.position =
                            gm.inven[i].transform.position;
                    }
                    else if (i == 9)
                    { 

                        gm.btcat[gm.invennum[i]].SetActive(true);
                        gm.btcat[gm.invennum[i]].transform.position =
                               gm.inven[i].transform.position;
                    }
                    else if (i == 10)
                    { 
                        gm.btbullet[gm.invennum[i]].SetActive(true);
                        gm.btbullet[gm.invennum[i]].transform.position =
                               gm.inven[i].transform.position;
                    }
                    else if (i == 11 && gm.invennum[11] != -1)
                    {
                        gm.btbullet[gm.invennum[i]].SetActive(true);
                        gm.btbullet[gm.invennum[i]].transform.position =
                               gm.inven[i].transform.position;
                    }
                }
            }
            itemoff();

        }

        else if(gm.inven[12].activeSelf)
        {
            gm.inven[12].SetActive(false);
            if(!gm.unknown[2].activeSelf && !gm.shop[0].activeSelf
                && !gm.Evolution[0].activeSelf)
                gm.information.SetActive(false);
            if(gm.Evolution[0].activeSelf)
                gm.catevlset();
            exit.SetActive(false);
            for (int i = 0; i < gm.invennum.Length; i++)
            {
                if(gm.invennum[i] != -1)
                {
                    if (i < 9)
                        gm.btweapon[gm.invennum[i]].SetActive(false);
                    else if (i == 9)
                        gm.btcat[gm.invennum[i]].SetActive(false);
                    else if (i == 10)
                        gm.btbullet[gm.invennum[i]].SetActive(false);
                    else if (i == 11 && gm.invennum[11] != -1)
                        gm.btbullet[gm.invennum[i]].SetActive(false);
                }
            }
            itemon();

            if(pl.respawn || pl.dobattle || gm.box[4].activeSelf == true)
                Time.timeScale = 1;
        }
        baceui[5].SetActive(true);
    }

    public void setlftebt()
    {
        if (gm.setinvennextint <= 0)
            gm.setinvennextint = 0;
        else
            gm.setinvennextint--;

        StartCoroutine(setpos());
    }
    public void setrightbt()
    {
        if (gm.setinvennextint >= 2)
            gm.setinvennextint = 2;
        else if(gm.setinvenposint[(gm.setinvennextint*5)+5] != -1)
            gm.setinvennextint++;

        StartCoroutine(setpos());
    }
    IEnumerator setpos()//����������
    {
        setinvenexit();
        for (int d = 0; d < gm.setinven.Length; d++)
        {
            if (gm.setinven[d].activeSelf == true)
                gm.setinven[d].SetActive(false);
        }

        for (int n = 5* gm.setinvennextint; n < (5 * gm.setinvennextint)+5; n++)
        {
            if (gm.setinvenposint[n] != -1)
            {
                RectTransform uipos = gm.setinven[gm.setinvenposint[n]].GetComponent<RectTransform>();
                RectTransform uipos1 = gm.setinvenpos[n - (gm.setinvennextint * 5)].GetComponent<RectTransform>();
                uipos.position = uipos1.transform.position;
                gm.setinven[gm.setinvenposint[n]].SetActive(true);
            }
        }
        yield return new WaitForSecondsRealtime(0.1f);
    }
    public void itemoff()
    {
        for(int i =0;i<gm.btweapon.Length;i++)
        {
            if (i != gm.invennum[0] && i != gm.invennum[1] &&
                i != gm.invennum[2] && i != gm.invennum[3] &&
                i != gm.invennum[4] && i != gm.invennum[5] &&
                i != gm.invennum[6] && i != gm.invennum[7] &&
                i != gm.invennum[8] )
                gm.btweapon[i].SetActive(false);
        }
        for (int i = 0; i < gm.btbullet.Length; i++)
        {
            if (i != gm.invennum[10] && i != gm.invennum[11])
                gm.btbullet[i].SetActive(false);
        }
        for (int i = 0; i < gm.btcat.Length; i++)
        {
            if (i != gm.invennum[9])
                gm.btcat[i].SetActive(false);
        }
    }
    public void itemon()
    {
        if (gm.inven[12].activeSelf)
            return;


        for (int i = 0; i < onlyshop.Length; i++)
          {
              if (i < 3 && onlyshop[i] != -1 && gm.shop[2].activeSelf == true)
              {
                  gm.btweapon[onlyshop[i]].SetActive(true);
                  gm.btweapon[onlyshop[i]].transform.position =
                      gm.itempos[i].transform.position;
              }

              else if (i < 5 && onlyshop[i] != -1 && gm.shop[4].activeSelf == true)
              {
                  gm.btbullet[onlyshop[i]].SetActive(true);
                  gm.btbullet[onlyshop[i]].transform.position =
                     gm.item1pos[i - 3].transform.position;
              }
          }
          if (pl.itemsel && gm.nearint >= 0)
              gm.btweapon[gm.nearint].SetActive(true);
        if (uiexitbt[1].activeSelf && only[2] != -1)
            gm.btweapon[only[2]].SetActive(true);
        if (gm.unknown[2].activeSelf == true && onlyczweapon != -1)
            gm.btweapon[onlyczweapon].SetActive(true);

        if (pl.catsel && gm.nearint >= 0)
              gm.btcat[gm.nearint].SetActive(true);
        if (uiexitbt[2].activeSelf && only[6] != -1)
            gm.btcat[only[6]].SetActive(true);
    }
    public void setuiclick()
    {
        gm.nearobj = EventSystem.current.currentSelectedGameObject;
        uimanager ui = gm.nearobj.GetComponent<uimanager>();

        itemoff();

        for (int im = 11;im< gm.setinven.Length;im++)
        {
            if(im == ui.uiint + 11)
            {
                gm.setinven[im].transform.localScale = new Vector2(1, 1);
                gm.setinven[im].transform.position = gm.setimpos.transform.position;
                gm.setinven[im].SetActive(true);
            }
            else if(im == 22)
                gm.setinven[22].SetActive(true);
            else
                gm.setinven[im].SetActive(false);
        }
        for (int i = 0; i < gm.invennum.Length; i++)
        {
            if (gm.invennum[i] != -1)
            {
                if (i < 9)
                    gm.btweapon[gm.invennum[i]].SetActive(false);
                else if (i == 9)
                    gm.btcat[gm.invennum[i]].SetActive(false);
                else if (i == 10)
                    gm.btbullet[gm.invennum[i]].SetActive(false);
                else if (i == 11 && gm.invennum[11] != -1)
                    gm.btbullet[gm.invennum[i]].SetActive(false);
            }
        }
        if (pl.getset[ui.uiint * 2] && pl.getset[1 + (ui.uiint * 2)])
        {
            gm.setinveninformation[2].color = new Color(0.2f, 0.2f, 0.2f,1);
            gm.setinveninformation[3].color = new Color(0.2f, 0.2f, 0.2f,1);
            gm.setinveninformation[4].color = new Color(0.2f, 0.2f, 0.2f, 1);
            gm.setinveninformation[5].color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
        else if (pl.getset[ui.uiint*2] && !pl.getset[1+(ui.uiint * 2)])
        {
            gm.setinveninformation[2].color = new Color(0.2f, 0.2f, 0.2f, 1);
            gm.setinveninformation[3].color = new Color(0.2f, 0.2f, 0.2f, 1);
            gm.setinveninformation[4].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
            gm.setinveninformation[5].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
        }
        else
        {
            gm.setinveninformation[2].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
            gm.setinveninformation[3].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
            gm.setinveninformation[4].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
            gm.setinveninformation[5].color = new Color(0.2f, 0.2f, 0.2f, 0.6f);
        }
        if (ui.uiint == 0)
        {
            gm.setinveninformation[0].text = "��Ÿ";
            gm.setinveninformation[1].text = "ġ��Ÿ �������� ��������!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] +" / 3";
            gm.setinveninformation[3].text = "ġ��Ÿ ������ 2�� ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "ġ��Ÿ ������ 3�� ����!";
        }
        else if (ui.uiint == 1)
        {
            gm.setinveninformation[0].text = "���";
            gm.setinveninformation[1].text = "ġ��Ÿ Ȯ���� ��������!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 2";
            gm.setinveninformation[3].text = "ġ��Ÿ Ȯ�� 1.5�� ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 4";
            gm.setinveninformation[5].text = "ġ��Ÿ Ȯ�� 2��  ����!";
        }
        else if (ui.uiint == 2)
        {
            gm.setinveninformation[0].text = "����";
            gm.setinveninformation[1].text = "���⸦ �� �ܴ��ϰ�!\n������ ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "������ 30% ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "������ 80% ����!";
        }
        else if (ui.uiint == 3)
        {
            gm.setinveninformation[0].text = "�ż�";
            gm.setinveninformation[1].text = "���� �� ������ ������!\n���� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "���� 30% ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "���� 100%  ����!";
        }
        else if (ui.uiint == 4)
        {
            gm.setinveninformation[0].text = "����";
            gm.setinveninformation[1].text = "���� ������ �� ������ ������!\n���� ���� ������ ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "���� ���� ������ 2 ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "���� ���� ������ 4 ����!";
        }
        else if (ui.uiint == 5)
        {
            gm.setinveninformation[0].text = "��Ⱘ��";
            gm.setinveninformation[1].text = "������ �����ϱ� ���Ѵ�!\nȸ�� Ȯ�� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 2";
            gm.setinveninformation[3].text = "ȸ�� Ȯ�� 33%!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 4";
            gm.setinveninformation[5].text = "ȸ�� Ȯ�� 70%!";
        }
        else if (ui.uiint == 6)
        {
            gm.setinveninformation[0].text = "����";
            gm.setinveninformation[1].text = "�������� �ʾ�.\n�ִ� ü�� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "�ִ� ü�� 1.5�� ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "�ִ� ü�� 2.5��  ����!";
        }
        else if (ui.uiint == 7)
        {
            gm.setinveninformation[0].text = "ǥ��";
            gm.setinveninformation[1].text = "�� �� ��!\n���� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 2";
            gm.setinveninformation[3].text = "���� 1.3�� ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 4";
            gm.setinveninformation[5].text = "���� 1.8��  ����!";
        }
        else if (ui.uiint == 8)
        {
            gm.setinveninformation[0].text = "���";
            gm.setinveninformation[1].text = "������ �̵��ϰ� ������ ������!\n�̵� �ӵ�, źȯ �ӵ� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "�̵� �ӵ� 1.2��, \nźȯ �ӵ� 1.5�� ����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "�̵� �ӵ� 1.5��, \nźȯ �ӵ� 2������!";
        }
        else if (ui.uiint == 9)
        {
            gm.setinveninformation[0].text = "����";
            gm.setinveninformation[1].text = "������ �� ���� �ž�!\n �Ⱦ� ������ ȹ�淮 ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "�Ⱦ� ������ ȹ�淮 1.5�� ����!" +
                "\n �̵� �ӵ��� źȯ �ӵ� 20% ����...";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "�Ⱦ� ������ ȹ�淮 2.5��  ����!"+
                "\n ��� �Ⱦ� ������ �ڼ�ȿ��!" +
                "\n �̵� �ӵ��� źȯ �ӵ� 40 % ����...";
        }
        else if (ui.uiint == 10)
        {
            gm.setinveninformation[0].text = "����";
            gm.setinveninformation[1].text = "���� �����ϰ� �ο��߰ھ�!\n���� ��ų ��Ÿ�� ����!";
            gm.setinveninformation[2].text = pl.hasset[ui.uiint] + " / 3";
            gm.setinveninformation[3].text = "���� ��ų ��Ÿ�� 20%����!";
            gm.setinveninformation[4].text = pl.hasset[ui.uiint] + " / 5";
            gm.setinveninformation[5].text = "���� ��ų ��Ÿ�� 50%����!";
        }
    }
    public void setinvenexit()
    {
        itemon();
        for (int i =11;i< gm.setinven.Length;i++)
            gm.setinven[i].SetActive(false);

        if (gm.wpnearobj != null && information.activeSelf)
        {
            item item = gm.wpnearobj.GetComponent<item>();
            for (int ipos = 0; ipos < informationpos.Length; ipos++)
            {
                for (int i = 0; i < item.wphasset.Length; i++)
                {
                    if (item.wphasset[i] != 0 && !gm.setinven[i + 11].activeSelf)
                    {
                        gm.setinven[i + 11].transform.localScale = new Vector2(0.45f, 0.45f);
                        gm.setinven[i + 11].transform.position = informationpos[ipos].transform.position;
                        gm.setinven[i + 11].SetActive(true);
                        break;
                    }
                }
            }
        }
        

        gm.setinven[22].SetActive(false);
        for (int i = 0; i < gm.invennum.Length; i++)
        {
            if (gm.invennum[i] != -1 && gm.inven[12].activeSelf)
            {
                if (i < 9)
                {
                    gm.btweapon[gm.invennum[i]].SetActive(true);
                    gm.btweapon[gm.invennum[i]].transform.position =
                        gm.inven[i].transform.position;
                }
                else if (i == 9)
                {

                    gm.btcat[gm.invennum[i]].SetActive(true);
                    gm.btcat[gm.invennum[i]].transform.position =
                           gm.inven[i].transform.position;
                }
                else if (i == 10)
                {
                    gm.btbullet[gm.invennum[i]].SetActive(true);
                    gm.btbullet[gm.invennum[i]].transform.position =
                           gm.inven[i].transform.position;
                }
                else if (i == 11 && gm.invennum[11] != -1)
                {
                    gm.btbullet[gm.invennum[i]].SetActive(true);
                    gm.btbullet[gm.invennum[i]].transform.position =
                           gm.inven[i].transform.position;
                }
            }
        }
    }
    public void ui1onclick()
    {
        gm.nearobj  = EventSystem.current.currentSelectedGameObject;
        mainui1 mainui1 = gm.nearobj .GetComponent<mainui1>();
        Image image = ui11[4].GetComponent<Image>();
        Image image1 = ui11[5].GetComponent<Image>();
        Image image2 = ui11[6].GetComponent<Image>();
        if (mainui1.vul == 101)
        {
            ui11[0].SetActive(true);
            ui11[1].SetActive(false);
            ui11[2].SetActive(false);
            image.color = new Color(1, 1, 1, 1);
            image1.color = new Color(1, 1, 1, 0.3f);
            image2.color = new Color(1, 1, 1, 0.3f);
        }
        else if (mainui1.vul == 102)
        {
            ui11[0].SetActive(false);
            ui11[1].SetActive(true);
            ui11[2].SetActive(false);
            image.color = new Color(1, 1, 1, 0.3f);
            image1.color = new Color(1, 1, 1, 1);
            image2.color = new Color(1, 1, 1, 0.3f);
        }
        else if (mainui1.vul == 103)
        {
            ui11[0].SetActive(false);
            ui11[1].SetActive(false);
            ui11[2].SetActive(true);
            image.color = new Color(1, 1, 1, 0.3f);
            image1.color = new Color(1, 1, 1, 0.3f);
            image2.color = new Color(1, 1, 1, 1);
        }


        //����
        if (mainui1.vul == 1)
        {
            if (ui1bool[0] != true)
            {
                ui1imformationtxt[0].text =
                "��!\n" + "+0\n" + "��\n" + "+2\n" + "���� ����!";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "1500";
            }
            else
            { ui1imformationtxt[0].text = "��+3\n"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 2 && ui1bool[0])
        {
            if (ui1bool[1] != true)
            {
                ui1imformationtxt[0].text =
                "��!\n" + "+2\n" + "��\n" + "+5\n" + "���� ����!";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "5000";
            }
            else
            { ui1imformationtxt[0].text = "��+5\n"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 3 && ui1bool[1])
        {
            if (ui1bool[2] != true)
            {
                ui1imformationtxt[0].text =
                "��!\n" + "+5\n" + "��\n" + "+10\n" + "���� ����!";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "��+10\n"; ui11[3].SetActive(false); }
        }

        if (mainui1.vul == 4)
        {
            if (ui1bool[3] != true)
            {
                ui1imformationtxt[0].text =
                "���� �𰡼�!\n" + " 1��\n" + "��\n" + "1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "1500";
            }
            else
            { ui1imformationtxt[0].text = "���� �𰡼�\n" + "1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 5 && ui1bool[3])
        {
            if (ui1bool[4] != true)
            {
                ui1imformationtxt[0].text =
                "���� �𰡼�!\n" + " 1.5��\n" + "��\n" + "2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "5000";
            }
            else
            { ui1imformationtxt[0].text = "���� �𰡼�!\n" + " 2��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 6 && ui1bool[4])
        {
            if (ui1bool[5] != true)
            {
                ui1imformationtxt[0].text =
                "���� �𰡼�!\n" + " 2��\n" + "��\n" + "3��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "���� �𰡼�!\n" + " 3��"; ui11[3].SetActive(false); }
        }


        if (mainui1.vul == 7)
        {
            if (ui1bool[6] != true)
            {
                ui1imformationtxt[0].text =
                "ġ��Ÿ\n" + " Ȯ��!\n" + "+0%\n" + "��\n" + "+5%";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "1500";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+5%"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 8 && ui1bool[6])
        {
            if (ui1bool[7] != true)
            {
                ui1imformationtxt[0].text =
                 "ġ��Ÿ\n" + " Ȯ��!\n" + "+5%\n" + "��\n" + "+10%";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "5000";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+10%"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 9 && ui1bool[7])
        {
            if (ui1bool[8] != true)
            {
                ui1imformationtxt[0].text =
               "ġ��Ÿ\n" + " Ȯ��!\n" + "+10%\n" + "��\n" + "+20%";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+20%"; ui11[3].SetActive(false); }
        }


        if (mainui1.vul == 10)
        {
            if (ui1bool[9] != true)
            {
                ui1imformationtxt[0].text =
                "ġ��Ÿ\n" + " ������!\n" + "1��\n" + "��\n" + "1.2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "1500";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "1.2��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 11 && ui1bool[9])
        {
            if (ui1bool[10] != true)
            {
                ui1imformationtxt[0].text =
                 "ġ��Ÿ\n" + " ������!\n" + "1.2��\n" + "��\n" + "1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "5000";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 12 && ui1bool[10])
        {
            if (ui1bool[11] != true)
            {
                ui1imformationtxt[0].text =
               "ġ��Ÿ\n" + " ������!\n" + "1.5��\n" + "��\n" + "2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "2��"; ui11[3].SetActive(false); }
        }

        //�ǰ�
        if (mainui1.vul == 13)
        {
            if (ui1bool[12] != true)
            {
                ui1imformationtxt[0].text =
                "�ִ� ü��!\n" + "100\n" + "��\n" + "150";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "�ִ� ü��!\n" + "150"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 14 && ui1bool[12])
        {
            if (ui1bool[13] != true)
            {
                ui1imformationtxt[0].text =
                 "�ִ� ü��!\n" + "150\n" + "��\n" + "200";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "�ִ� ü��!\n" + "200"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 15)
        {
            if (ui1bool[14] != true)
            {
                ui1imformationtxt[0].text =
               "ȸ����!\n" + "1��\n" + "��\n" + "1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "ȸ����!\n" + "1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 16 && ui1bool[14])
        {
            if (ui1bool[15] != true)
            {
                ui1imformationtxt[0].text =
               "ȸ����!\n" + "1.5��\n" + "��\n" + "2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "ȸ����!\n" + "2��"; ui11[3].SetActive(false); }
        }



        if (mainui1.vul == 17)
        {
            if (ui1bool[16] != true)
            {
                ui1imformationtxt[0].text =
                "����!\n" + "+0\n" + "��\n" + "+2";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "����!\n" + "+2"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 18 && ui1bool[16])
        {
            if (ui1bool[17] != true)
            {
                ui1imformationtxt[0].text =
                 "����!\n" + "+2\n" + "��\n" + "+5";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "����!\n" + "+5"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 19)
        {
            if (ui1bool[18] != true)
            {
                ui1imformationtxt[0].text =
               "�̵��ӵ�!\n" + "3\n" + "��\n" + "5";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "�̵��ӵ�!\n" + "5"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 20 && ui1bool[18])
        {
            if (ui1bool[19] != true)
            {
                ui1imformationtxt[0].text =
               "�̵��ӵ�!\n" + "5\n" + "��\n" + "8";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "�̵��ӵ�!\n" + "8"; ui11[3].SetActive(false); }
        }

        if (mainui1.vul == 21 && ui1bool[13] && ui1bool[15])
        {
            if (ui1bool[20] != true)
            {
                ui1imformationtxt[0].text =
               "��������\n���� �� ȹ��!\n0\n��\n15";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "18000";
            }
            else
            { ui1imformationtxt[0].text = "��������\n���� �� ȹ��!\n15"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 22 && ui1bool[20])
        {
            if (ui1bool[21] != true)
            {
                ui1imformationtxt[0].text =
                "��Ȱ!\n(ü�� 50%)\n0ȸ\n��\n1ȸ";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "25000";
            }
            else
            { ui1imformationtxt[0].text = "��Ȱ!\n(ü�� 50%)\n1ȸ"; ui11[3].SetActive(false); }
        }

        //����
        if (mainui1.vul == 23)
        {
            if (ui1bool[22] != true)
            {
                ui1imformationtxt[0].text =
                "���� ��ų\n�𰡼�!\n1��\n��\n1.2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n1.2��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 24 && ui1bool[22])
        {
            if (ui1bool[23] != true)
            {
                ui1imformationtxt[0].text =
                 "���� ��ų\n�𰡼�!\n1.2��\n��\n1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 25 && ui1bool[23])
        {
            if (ui1bool[24] != true)
            {
                ui1imformationtxt[0].text =
                 "���� ��ų\n�𰡼�!\n1.5��\n��\n2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n2��"; ui11[3].SetActive(false); }
        }

        if (mainui1.vul == 26)
        {
            if (ui1bool[25] != true)
            {
                ui1imformationtxt[0].text =
                "�Ǹ� �ݾ�\n������!\n1��\n��\n1.2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n1.2��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 27 && ui1bool[25])
        {
            if (ui1bool[26] != true)
            {
                ui1imformationtxt[0].text =
                 "�Ǹ� �ݾ�\n������!\n1.2��\n��\n1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 28 && ui1bool[26])
        {
            if (ui1bool[27] != true)
            {
                ui1imformationtxt[0].text =
                 "�Ǹ� �ݾ�\n������!\n1.5��\n��\n2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n2��"; ui11[3].SetActive(false); }
        }

        if (mainui1.vul == 29)
        {
            if (ui1bool[28] != true)
            {
                ui1imformationtxt[0].text =
                "�Ⱦ� ������\n������!\n1��\n��\n1.2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "3000";
            }
            else
            { ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n1.2��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 30 && ui1bool[28])
        {
            if (ui1bool[29] != true)
            {
                ui1imformationtxt[0].text =
                  "�Ⱦ� ������\n������!\n1.2��\n��\n1.5��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "6000";
            }
            else
            { ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n1.5��"; ui11[3].SetActive(false); }
        }
        else if (mainui1.vul == 31 && ui1bool[29])
        {
            if (ui1bool[30] != true)
            {
                ui1imformationtxt[0].text =
                 "�Ⱦ� ������\n������!\n1.5��\n��\n2��";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "12000";
            }
            else
            { ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n2��"; ui11[3].SetActive(false); }
        }

        if (mainui1.vul == 32 && ui1bool[24] && ui1bool[27] && ui1bool[30])
        {
            if (ui1bool[31] != true)
            {
                ui1imformationtxt[0].text =
                "�κ񿡼�\n���� 1ȸ\n�߰� ����\n����!";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "15000";
            }
            else
            { ui1imformationtxt[0].text = "�κ񿡼�\n���� 1ȸ\n�߰� ����\n����!"; ui11[3].SetActive(false); }
        }
        if (mainui1.vul == 33 && ui1bool[24] && ui1bool[27] && ui1bool[30])
        {
            if (ui1bool[32] != true)
            {
                ui1imformationtxt[0].text =
                "�κ񿡼�\n���� ����\n1ȸ �߰� ��ȸ!";
                ui11[3].SetActive(true);
                ui1imformationtxt[1].text = "15000";
            }
            else
            { ui1imformationtxt[0].text = "�κ񿡼�\n���� ����\n1ȸ �߰� ��ȸ!"; ui11[3].SetActive(false); }
        }
    }
    public void upgrade()
    {
        if (gm.nearobj  == null)
            return;

        mainui1 mainui1 = gm.nearobj .GetComponent<mainui1>();

        //�� data.mainbool[0];
        if (mainui1.vul == 1 && ui1bool[0] != true && pl.soul >= 1500)
        {
            pl.soul -= 1500;
            ui1bool[0] = true;
            data.mainbool[0] = 2;
            Image image1 = ui1[0].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 1);
            Image image = ui1[1].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "��+3";
        }
        else if (mainui1.vul == 2 && ui1bool[0] && ui1bool[1] != true && pl.soul >= 5000)
        {
            pl.soul -= 5000;
            ui1bool[1] = true;
            data.mainbool[0] = 5;
            Image image1 = ui1[1].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 1);
            Image image = ui1[2].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "��+5";
        }
        else if (mainui1.vul == 3 && ui1bool[1] && ui1bool[2] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[2] = true;
            data.mainbool[0] = 10;
            Image image = ui1[2].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "��+10";
        }
        //�����𰡼�
        if (mainui1.vul == 4 && ui1bool[3] != true && pl.soul >= 1500)
        {
            pl.soul -= 1500;
            ui1bool[3] = true;
            data.mainbool[2] = 1.5f;
            Image image = ui1[3].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[4].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "���� �𰡼�\n" + "1.5��";
        }
        else if (mainui1.vul == 5 && ui1bool[3] && ui1bool[4] != true && pl.soul >= 5000)
        {
            pl.soul -= 5000;
            ui1bool[4] = true;
            data.mainbool[2] = 2;
            Image image = ui1[4].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[5].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "���� �𰡼�\n" + "2��";
        }
        else if (mainui1.vul == 6 && ui1bool[4] && ui1bool[5] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[5] = true;
            data.mainbool[2] = 3;
            Image image = ui1[5].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "���� ��Ÿ��\n" + "3��";
        }


        //ġ��Ÿ Ȯ��
        if (mainui1.vul == 7 && ui1bool[6] != true && pl.soul >= 1500)
        {
            pl.soul -= 1500;
            ui1bool[6] = true;
            data.mainbool[3] = 5;
            Image image = ui1[6].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[7].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+5%";
        }
        else if (mainui1.vul == 8 && ui1bool[6] && ui1bool[7] != true && pl.soul >= 5000)
        {
            pl.soul -= 5000;
            ui1bool[7] = true;
            data.mainbool[3] = 10f;
            Image image = ui1[7].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[8].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+10%";
        }
        else if (mainui1.vul == 9 && ui1bool[7] && ui1bool[8] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[8] = true;
            data.mainbool[3] = 20;
            Image image = ui1[8].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " Ȯ��!\n" + "+20%";
        }


        //ġ��Ÿ��
        if (mainui1.vul == 10 && ui1bool[9] != true && pl.soul >= 1500)
        {
            pl.soul -= 1500;
            ui1bool[9] = true;
            data.mainbool[4] = 1.2f;
            Image image = ui1[9].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[10].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "1.2��";
        }
        else if (mainui1.vul == 11 && ui1bool[9] && ui1bool[10] != true && pl.soul >= 5000)
        {
            pl.soul -= 5000;
            ui1bool[10] = true;
            data.mainbool[4] = 1.5f;
            Image image = ui1[10].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[11].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "1.5��";
        }
        else if (mainui1.vul == 12 && ui1bool[10] && ui1bool[11] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[11] = true;
            data.mainbool[4] = 2f;
            Image image1 = ui1[11].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "ġ��Ÿ\n" + " ������!\n" + "2��";
        }
        // �ǰ� ü��
        if (mainui1.vul == 13 && ui1bool[12] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[12] = true;
            data.mainbool[12] = 50;
            Image image = ui1[12].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[13].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�ִ� ü��!\n" + "150";
        }
        else if (mainui1.vul == 14 && ui1bool[12] && ui1bool[13] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[13] = true;
            data.mainbool[12] = 100;
            Image image = ui1[13].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "�ִ� ü��!\n" + "200";
        }
        //������
        else if (mainui1.vul == 15 && ui1bool[14] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[14] = true;
            data.mainbool[7] = 1.5f;
            Image image = ui1[14].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[15].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "ȸ����!\n" + "1.5��";
        }
        else if (mainui1.vul == 16 && ui1bool[14] && ui1bool[15] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[15] = true;
            data.mainbool[7] = 2;
            Image image = ui1[15].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "ȸ����!\n" + "2��";
        }

        //����
        if (mainui1.vul == 17 && ui1bool[16] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[16] = true;
            data.mainbool[5] = 2;
            Image image = ui1[16].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[17].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "����!\n" + "+2";
        }
        else if (mainui1.vul == 18 && ui1bool[16] && ui1bool[17] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[17] = true;
            data.mainbool[5] = 5;
            Image image = ui1[17].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "����!\n" + "+5";
        }
        //�̼�
        else if (mainui1.vul == 19 && ui1bool[18] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[18] = true;
            data.mainbool[1] = 2;
            Image image = ui1[18].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[19].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�̵��ӵ�!\n" + "5";
        }
        else if (mainui1.vul == 20 && ui1bool[18] && ui1bool[19] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[19] = true;
            data.mainbool[1] = 5;
            Image image = ui1[19].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = 
                "�̵��ӵ�!\n8\n(��������\n�̵� �����\n�����ϰ�\n�����ϼ���>";
        }
        //�ڿ�ġ��
        if (mainui1.vul == 21 && ui1bool[20] != true
            && ui1bool[13] && ui1bool[15] && pl.soul >= 18000)
        { 
            pl.soul -= 18000;
            ui1bool[20] = true;
            data.mainbool[13] = 15;
            Image image = ui1[20].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[21].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "��������\n���� �� ȹ��!\n15";
        }
        //��Ȱ
        if (mainui1.vul == 22 && ui1bool[21] != true && pl.soul >= 25000)
        {
            pl.soul -= 25000;
            ui1bool[21] = true;
            data.mainbool[9] = 1;
            Image image = ui1[21].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "��Ȱ!\n" + "(ü�� 50%)\n" + "1ȸ";

        }

        //���� ����
        if (mainui1.vul == 23 && ui1bool[22] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[22] = true;
            data.mainbool[8] = 1.2f;
            Image image = ui1[22].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[23].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n1.2��";
           
        }
        else if (mainui1.vul == 24 && ui1bool[22] && ui1bool[23] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[23] = true;
            data.mainbool[8] = 1.5f;
            Image image = ui1[23].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[24].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n1.5��";
        }
        else if (mainui1.vul == 25 && ui1bool[23] && ui1bool[24] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[24] = true;
            data.mainbool[8] = 2f;
            Image image = ui1[24].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "���� ��ų\n�𰡼�!\n2��";
        }
        //�Ǹűݾ�
        if (mainui1.vul == 26 && ui1bool[25] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[25] = true;
            data.mainbool[10] = 1.2f;
            Image image = ui1[25].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[26].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n1.2��";
        }
        else if (mainui1.vul == 27 && ui1bool[25] && ui1bool[26] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[26] = true;
            data.mainbool[10] = 1.5f;
            Image image = ui1[26].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[27].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n1.5��";
        }
        else if (mainui1.vul == 28 && ui1bool[26] && ui1bool[27] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[27] = true;
            data.mainbool[10] = 2f;
            Image image = ui1[27].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "�Ǹ� �ݾ�\n������!\n2��";
        }

        //ȹ�淮
        if (mainui1.vul == 29 && ui1bool[28] != true && pl.soul >= 3000)
        {
            pl.soul -= 3000;
            ui1bool[28] = true;
            data.mainbool[6] = 1.2f;
            Image image = ui1[28].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[29].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n1.2��";
        }
        else if (mainui1.vul == 30 && ui1bool[28] && ui1bool[29] != true && pl.soul >= 6000)
        {
            pl.soul -= 6000;
            ui1bool[29] = true;
            data.mainbool[6] = 1.5f;
            Image image = ui1[29].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            Image image1 = ui1[30].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
            ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n1.5��";
        }
        else if (mainui1.vul == 31 && ui1bool[29] && ui1bool[30] != true && pl.soul >= 12000)
        {
            pl.soul -= 12000;
            ui1bool[30] = true;
            data.mainbool[6] = 2f;
            Image image = ui1[30].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "�Ⱦ� ������\n������!\n2��";
        }

        //���� ȹ��
        if (mainui1.vul == 32 && ui1bool[31] != true &&
            ui1bool[24] && ui1bool[27] && ui1bool[30] && pl.soul >= 15000)
        {
            pl.soul -= 15000;
            ui1bool[31] = true;
            Image image = ui1[31].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "�κ񿡼�\n���� 1ȸ\n�߰� ����\n����!";
        }
        //���� ȹ��
        if (mainui1.vul == 33 && ui1bool[32] != true &&
            ui1bool[24] && ui1bool[27] && ui1bool[30] && pl.soul >= 15000)
        {
            pl.soul -= 15000;
            ui1bool[32] = true;
            Image image = ui1[32].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            ui1imformationtxt[0].text = "�κ񿡼�\n���� ����\n1ȸ �߰� ��ȸ!";
        }
        StartCoroutine(qnghkf());
    }
    public IEnumerator qnghkf()
    {
        ui11[3].SetActive(false);
        ui1imformationtxt[2].text = pl.soul.ToString();
        Time.timeScale = 1;
        if (ui1bool[13] && ui1bool[15] && !ui1bool[20])
        {
            Image image = ui1[20].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 0.2f);
        }
        if (ui1bool[24] && ui1bool[27] && ui1bool[30] && !ui1bool[31] && !ui1bool[32])
        {
            Image image = ui1[31].GetComponent<Image>();
            image.color = new Color(1, 1, 1, 0.2f);
            Image image1 = ui1[32].GetComponent<Image>();
            image1.color = new Color(1, 1, 1, 0.2f);
        }
        for (int i = 0; i < ui1bool.Length; i++)
        {
            if (ui1bool[i])
                data.ui1bool[i] = true;
            else
                data.ui1bool[i] = false;
        }
        if (ui1bool[0])
        {
            data.mainbool[0] = 2;
            if (ui1bool[1])
            {
                data.mainbool[0] = 5;
                if (ui1bool[2])
                    data.mainbool[0] = 10;
            }
        }
        if (ui1bool[3])
        {
            data.mainbool[2] = 1.5f;
            if (ui1bool[4])
            {
                data.mainbool[2] = 2f;
                if (ui1bool[5])
                    data.mainbool[2] = 3f;
            }
        }
        if (ui1bool[6])
        {
            data.mainbool[3] = 5f;
            if (ui1bool[7])
            {
                data.mainbool[3] = 10f;
                if (ui1bool[8])
                    data.mainbool[3] = 20f;
            }
        }
        if (ui1bool[9])
        {
            data.mainbool[4] = 1.2f;
            if (ui1bool[10])
            {
                data.mainbool[4] = 1.5f;
                if (ui1bool[11])
                    data.mainbool[4] = 2f;
            }
        }
        if (ui1bool[12])
        {
            data.mainbool[12] = 50;
            if (ui1bool[13])
                data.mainbool[12] = 100;
        }
        if (ui1bool[14])
        {
            data.mainbool[7] = 1.5f;
            if (ui1bool[15])
                data.mainbool[7] = 1.5f;
        }
        if (ui1bool[16])
        {
            data.mainbool[5] = 2;
            if (ui1bool[17])
                data.mainbool[5] = 5;
        }
        if (ui1bool[18])
        {
            data.mainbool[1] = 5;
            if (ui1bool[19])
                data.mainbool[1] = 7;
        }
        if (ui1bool[20])
            data.mainbool[13] = 15;
        
        if (ui1bool[21])
            data.mainbool[9] = 1;
        
        if (ui1bool[22])
        {
            data.mainbool[8] = 1.2f;
            if (ui1bool[23])
            {
                data.mainbool[8] = 1.5f;
                if (ui1bool[24])
                    data.mainbool[8] = 2f;
            }
        }
        if (ui1bool[25])
        {
            data.mainbool[10] = 1.2f;
            if (ui1bool[26])
            {
                data.mainbool[10] = 1.5f;
                if (ui1bool[27])
                    data.mainbool[10] = 2f;
            }
        }
        if (ui1bool[28])
        {
            data.mainbool[6] = 1.2f;
            if (ui1bool[29])
            {
                data.mainbool[6] = 1.5f;
                if (ui1bool[30])
                    data.mainbool[6] = 2f;
            }
        }
        for (int c = 0; c < pl.maindata.Length; c++)
        { pl.maindata[c] = data.mainbool[c]; }
        pl.StartCoroutine(pl.txt());
        data.jsondata.Save();
        yield return new WaitForSeconds(0.2f);
    }
    public void menubt()
    {
        menuui[0].SetActive(true);
        exit.SetActive(true);

        Time.timeScale = 0;
        for (int o = 0; o < baceui.Length; o++)
            baceui[o].SetActive(false);
    }
    public void golb()
    {
        if(data.chapterindex != 0)
            menuui[5].SetActive(true);
   
        else
        {
            gm.npctxtobj[0].SetActive(true);
            gm.npctxt[2].text =
            "���� ���Ⱑ �Ƚ�ó��!";
            pl.StartCoroutine(pl.unknowneftxtobjf());
            exitbt();
        }
    }
    public void setbt()
    {
        menuui[1].SetActive(true);
    }
    public void movebt()
    {
        if (!data.moveset)
        {
            data.moveset = true;
            menuui[4].SetActive(true);
            joystickobj.SetActive(false);
            movetxt.text = "�̵� ���� �����\n<��ġ �巹��>��\n���� �Ǿ����ϴ�.";
        }
        else
        {
            data.moveset = false;
            menuui[4].SetActive(true);
            joystickobj.SetActive(true);
            movetxt.text = "�̵� ���� �����\n<���̽�ƽ>��\n���� �Ǿ����ϴ�.";
        }
        if(data.chapterindex !=0)
            data.jsondata.Save();
        StartCoroutine(movetxtf());

    }
    IEnumerator movetxtf()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        menuui[4].SetActive(false);
    }
    public void codebt()
    {
        menuui[2].SetActive(true);
        code[0].text = " ";
    }
    //menuui[0]�޴�/menuui[1]����/menuui[2]�ڵ� �Է�/menuui[3]��¥ ����/�̵����۹�ĺ���
    public void codeboolbt()
    {
        //�ؽ�Ʈ ������Ʈ�� �ؽ�Ʈ�� �ؽ�Ʈ ��Ȯ�ϰ� �����ؼ� �ۼ�����.
        //�̰ɷ� 3�ð� ��ƸԴ°� ��¥ �ݼ�����.
        if (code[1].text.ToString().Equals("�ȳ��ϼ���?") && !data.codeonly[0])
        {
            data.codeonly[0] = true;
            pl.soul += 2000;
            code[0].text = "�ҿ� 2000�� �߰�! �Է¿Ϸ�!";
        }
        else if (code[1].text.ToString().Equals("�̰Եǳ�") && !data.codeonly[1])
        {
            data.codeonly[1] = true;
            pl.soul += 4000;
            code[0].text = "�ҿ� 4000�� �߰�!�Է¿Ϸ�!";
        }
        else
        {
            code[0].text = "�ٽ� �� �� Ȯ���ϼ���!";
        }
        for (int i = 0; i < menuui.Length; i++)
        {
            menuui[i].SetActive(false);
        }
        Time.timeScale = 1;
        adfasdf.text = "";
        StartCoroutine(txtf());
        pl.StartCoroutine(pl.txt());
        data.jsondata.Save();
        exitbt();

    }
    IEnumerator txtf()
    {
        yield return new WaitForSecondsRealtime(2f);
        code[0].text = " ";
    }
    public void gameexitbt()
    {
        menuui[3].SetActive(true);
    }
    public void gameexitbt1()
    {
        data.jsondata.Save();
        StartCoroutine(gameexit());

    }
    IEnumerator gameexit()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Application.Quit();
    }
    // ��Ʋ��
    public void boxcompensation()//�ڽ�����
    {
        gm.nearobj = EventSystem.current.currentSelectedGameObject;
        item item = gm.nearobj.GetComponent<item>();
        if(item.type == item.Type.wood)
        {
            gm.box[5].SetActive(true);
            if (!pl.coinsel && !pl.itemsel && !pl.chooruselsel && !pl.catsel)
            {
                pl.Coin += 50 * pl.plui[6];
                gm.boxtxt.text = "+ " + (int)(50 * pl.plui[6]) + "����";
            }
            if (pl.coinsel)
            {
                int woodran = Random.Range(150, 300);
                pl.Coin += woodran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(woodran * pl.plui[6]) + "����";
            }
            if (pl.chooruselsel)
            {
                int woodran = Random.Range(30, 60);
                pl.churoo += woodran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(woodran * pl.plui[6]) + "��";
            }
        }
        else if(item.type == item.Type.br)
        {
            gm.box[6].SetActive(true);
            if (!pl.coinsel && !pl.itemsel && !pl.chooruselsel && !pl.catsel)
            {
                pl.Coin += 100 * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(100 * pl.plui[6]) + "����";
            }
            if (pl.coinsel)
            {
                int brran2 = Random.Range(200, 500);
                pl.Coin += brran2 * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(brran2 * pl.plui[6]) + "����";
            }
            if (pl.chooruselsel)
            {
                int brran2 = Random.Range(60, 100);
                pl.churoo += brran2 * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(brran2 * pl.plui[6]) + "��";
            }
        }
        else if (item.type == item.Type.sv)
        {
            gm.box[7].SetActive(true);
            if (!pl.coinsel && !pl.itemsel && !pl.chooruselsel && !pl.catsel)
            {
                pl.Coin += 200 * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(200 * pl.plui[6]) + "����";
            }
            else if (pl.coinsel)
            {
                int svcoinselran = Random.Range(400, 700);
                pl.Coin += svcoinselran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(svcoinselran * pl.plui[6]) + "����";
            }
            else if (pl.chooruselsel)
            {
                int gdcoinselran = Random.Range(100, 150);
                pl.churoo += gdcoinselran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(gdcoinselran * pl.plui[6]) + "��";
            }
        }
        else if (item.type == item.Type.gd)
        {
            gm.box[8].SetActive(true);
            if (!pl.coinsel && !pl.itemsel && !pl.chooruselsel && !pl.catsel)
            {
                pl.Coin += 300 * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(300 * pl.plui[6]) + "����";
            }
            else if (pl.coinsel)
            {
                int gdcoinselran = Random.Range(600, 1000);
                pl.Coin += gdcoinselran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(gdcoinselran * pl.plui[6]) + "����";
            }
            else if (pl.chooruselsel)
            {
                int gdcoinselran = Random.Range(150, 300);
                pl.churoo += gdcoinselran * pl.plui[6];
                gm.boxtxt.text = "+" + (int)(gdcoinselran * pl.plui[6]) + "��";
            }
        }
        data.jsondata.Save();
        gm.nearobj.SetActive(false);
        StartCoroutine(choiceInvoke());
        pl.StartCoroutine(pl.txt());
    }
    public IEnumerator choiceInvoke()
    {
        yield return new WaitForSeconds(3f);
        gm.boxtxt.text = " ";
        for(int i = 0;i<gm.box.Length;i++)
            gm.box[i].SetActive(false);
        gm.nearint = -100;
        if (gm.stage % 5 == 0 && pl.catlv[0] != 3)
            gm.StartCoroutine(gm.choice1());
        
        else
            gm.StartCoroutine(gm.choice());
    }
    public void coinselect()
    {
        Time.timeScale = 1;
        pl.coinsel = true;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = false;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }

    public void churooselect()
    {
        Time.timeScale = 1;
        pl.coinsel = false;
        pl.chooruselsel = true;
        pl.itemsel = false;
        pl.catsel = false;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }
    public void itemselect()
    {
        Time.timeScale = 1;
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = true;
        pl.catsel = false;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }
    public void catselect()
    {
        Time.timeScale = 1;
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = true;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }

    public void bigenemyselect()
    {
        Time.timeScale = 1;
        pl.coinsel = true;
        pl.chooruselsel = true;
        pl.itemsel = false;
        pl.catsel = false;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }
    public void BOSSselect()
    {
        Time.timeScale = 1;
        pl.coinsel = true;
        pl.chooruselsel = true;
        pl.itemsel = true;
        pl.catsel = false;
        gm.clear = false;
        StartCoroutine(gm.stagestart());
       gm. nextuif();
    }
    public void exitselect()//������ ��ư
    {
        Time.timeScale = 1;
        for (int s = 0; s < 50; s++)
        {
            if(s < gm.unknown.Length)
                gm.unknown[s].SetActive(false);
            if(s<gm.btweapon.Length)
                gm.btweapon[s].SetActive(false);
            if(s< gm.btcat.Length)
                gm.btcat[s].SetActive(false);
            if(s< gm.shop.Length && gm.shop[s] != null)
                gm.shop[s].SetActive(false);
            if(s< gm.btbullet.Length)
                gm.btbullet[s].SetActive(false);
            if(s<  onlyshop.Length)
                onlyshop[s] = -1;
        }
        gm.Evolution[0].SetActive(false);
        gm.information.SetActive(false);
        gm.inven[12].SetActive(false);
        gm.exit.SetActive(false);
        gm.clear = false;
        if (onlyczweapon != -1)
            onlyczweapon = -1;
        gm.StartCoroutine(gm.stagestart());
        gm.nextuif();
    }
    public void shopselect()//����
    {
        Time.timeScale = 0;
        gm.shop[0].SetActive(true);
        gm.shop[1].SetActive(true);
        gm.shop[2].SetActive(true);
        gm.shop[8].SetActive(true);
        gm.information.SetActive(true);
        gm.exit.SetActive(true);
        gm.theshop = true;
        gm.spownweaponindex = 0;
        gm.spownbulletindex = 0;
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = false;
        pl.curstage = 0;
        gm.ability[10].text = string.Format("{0:n0}", pl.curstage);
        float rin =
            Random.Range((400 + (gm.stage * 100)) * 0.8f,
            (400 + (gm.stage *100)) * 1.2f);
        gm.rancoin = (int)rin;
        StartCoroutine(ranshopweapon());
        gm.rancointxt[5].text = gm.rancoin.ToString();
        
        int ran = Random.Range(0, 10);
        if (ran > 6)
        {
            gm.rancointxt[6].text = "����!";
            gm.rancointxt[7].text = " ";
            gm.shop[3].SetActive(true);
            gm.shop[4].SetActive(false);
            gm.shop[5].SetActive(false);
            gm.shop[6].SetActive(true);
            gm.shop[7].SetActive(false);
            StartCoroutine(ranshopweapon1());
        }
        else
        {
            gm.rancointxt[6].text = "����!";
            gm.rancointxt[7].text = " ";
            gm.shop[3].SetActive(false);
            gm.shop[4].SetActive(false);
            gm.shop[5].SetActive(true);
            gm.shop[6].SetActive(true);
            gm.shop[7].SetActive(false);
        }
        gm.shopanim.SetTrigger("shop1");
        for (int i = 0; i < 3; i++)
            shopnpc[i].color = new Color(1, 1, 1, 1);
        for (int i = 3; i < 7; i++)
            shopnpc[i].color = new Color(1, 1, 1, 0.5f);
        gm. nextuif();
    }
     void inforsel()
    {
        informationtxt.text = " ";
        gm.sellweaponbt.SetActive(false);
        gm.buyweaponbt.SetActive(false);
        gm.getweaponbt.SetActive(false);
        for (int i = 0; i <100;i++)
        {
            if (i < gm.btweapon.Length)
                gm.imweapon[i].SetActive(false);
                
            if (i < gm.btcat.Length)
                gm.imcat[i].SetActive(false);
               
            if (i < gm.btbullet.Length)
                gm.imbullet[i].SetActive(false);

            if (i < gm.setinven.Length-1 && i>=11)
                gm.setinven[i].SetActive(false);
        }
    }
    public void shopnpcselect()
    {
        if (gm.shop[2].activeSelf)
            return;

        gm.rancointxt[6].text = "�����ϰ�\n" + "����!";
        gm.rancointxt[7].text = " ";
        gm.shop[2].SetActive(true);
        gm.shop[4].SetActive(false);
        gm.shop[6].SetActive(true);
        gm.shop[7].SetActive(false);
        for (int i = 0; i < onlyshop.Length; i++)
        {
            if (i < 3 && onlyshop[i] != -1)
                gm.btweapon[onlyshop[i]].SetActive(true);
            else if (i < 5 && onlyshop[i] != -1)
                gm.btbullet[onlyshop[i]].SetActive(false);
        }
        gm.shopanim.SetTrigger("shop1");
        for (int i = 0; i < 3; i++)
            shopnpc[i].color = new Color(1, 1, 1, 1);
        for (int i = 3; i < 7; i++)
            shopnpc[i].color = new Color(1, 1, 1, 0.5f);

    }
    public void shopnpc1select()
    {
        if (gm.shop[4].activeSelf)
            return;

        if (gm.shop[3].activeSelf == true)
        {
            gm.rancointxt[6].text = " ";
            gm.rancointxt[7].text = "���� ����\n" + "���� ���̴µ�\n" + "�̰� �?";
            gm.shop[2].SetActive(false);
            gm.shop[4].SetActive(true);
            gm.shop[6].SetActive(false);
            gm.shop[7].SetActive(true);
            for (int i = 0; i < onlyshop.Length; i++)
            {
                if (i < 3 && onlyshop[i] != -1)
                    gm.btweapon[onlyshop[i]].SetActive(false);
                else if (i < 5 && onlyshop[i] != -1)
                    gm.btbullet[onlyshop[i]].SetActive(true);
            }
            gm.shopanim.SetTrigger("shop2");
            for (int i = 0; i < 3; i++)
                shopnpc[i].color = new Color(1, 1, 1, 0.5f);
            for (int i = 3; i < 7; i++)
                shopnpc[i].color = new Color(1, 1, 1, 1);
        }
    }
    public void unknownselect()//�����ư
    {
        Time.timeScale = 0;
        gm.theunkown = true;
        gm.stageper.SetActive(false);
        gm.exit.SetActive(true);
        gm.unknown[4].SetActive(true);
        gm.npctxtobj[1].SetActive(true);
        gm.npctxtobj[2].SetActive(true);
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = false;
        pl.curstage = 0;
        pl.npctolk = true;
        gm.ability[10].text = string.Format("{0:n0}", pl.curstage);
        inforsel();
        float rin =
            Random.Range((400 + ((gm.stage / 5) * 500)),
            (400 + ((gm.stage / 5) * 500)) * 1.5f);
        gm.rancoin = (int)rin;
        gm.unknown[0].SetActive(true);

        if (gm.czing)
        { max = 6; }
        else
        { max = 9; }
        if (fullbuff)
        { min = 3;}
        else
        { min = 0; }
        int ran = Random.Range(min, max);
        if (ran < 3)//3
        {
            gm.unknown[1].SetActive(true);
            gm.unknown[2].SetActive(false);
            gm.unknown[3].SetActive(false);
           
            gm.npctxt[0].text = "Ž�谡\n" + " �����";
            gm.npctxt[1].text = "�ʹ� ����µ� ���� ����..." + "\n"
            + "������ �ź�ο� ���� �ִ�\n" +
            "�˾��� �ִµ� ���ְھ�?";
            gm.npctxt[3].text = gm.rancoin.ToString();
        }
        else if (ran < 6)//6
        {
            gm.unknown[1].SetActive(false);
            gm.unknown[2].SetActive(true);
            gm.unknown[3].SetActive(false);
            gm.shop[8].SetActive(true);
            gm.information.SetActive(true);
            gm.npctxt[0].text = "�� ����\n" + "�����";
            gm.npctxt[1].text = "�� ���� ��� �Ծ�?" + "\n"
           + "Ȥ�� ������ ������ ���\n" +
           "������ ������ �� �� �־�?";
            gm.npctxt[3].text = gm.rancoin.ToString();
        }
        else if (ran < 9)
        {
            gm.unknown[1].SetActive(false);
            gm.unknown[2].SetActive(false);
            gm.unknown[3].SetActive(true);
            gm.npctxt[0].text = "�̻���\n" + " ���г�";
            gm.npctxt[1].text = "���⿡ ���...��ħ �� �Ծ�!" + "\n"
                + "���� ���� ���� ���� ���� �־�!\n" +
                "�Ծ� ����?\n" +
                "ó������ �ź� ������ �ֱ��ѵ�..." + "\n"
                + "�и� �������� ���� ����� ��ž�!";
            gm.npctxt[3].text = " ";
        }
        gm. nextuif();
    }

    public void retry()
    {
        Time.timeScale = 1;
        pl.life = pl.maxlife * pl.maxlifeper;
        pl.ishit = true;
        pl.poison = false;
        pl.slow = false;
        pl.slowint = 1;
        gm.isstop = false;
        pl.isbooming = false;
        pl.plmesh[0].SetActive(true);
        pl.mesh[pl.catint].SetActive(true);
        pl.StartCoroutine(pl.ishitf());
        gm.fade.SetActive(false);
        pl.StartCoroutine(pl.txt());
        gm.gameoverset.SetActive(false);
        for (int i = 0; i < pl.plmesh.Length - 1; i++)
        {
            SpriteRenderer sp = pl.plmesh[i].GetComponent<SpriteRenderer>();
            sp.color = new Color(1, 1, 1, 1);
        }
        gm. nextuif();
    }

    public void gohome()//�κ��
    {
        Time.timeScale = 1;
        if (gm.objectmanager != null)
            gm.objectmanager = null;

        pl.life = pl.maxlife;
        gm.ability[10].text = string.Format("{0:n0}", pl.curstage);
        pl.Coin = 0;
        pl.catint = 0;
        pl.churoo = 0;
        pl.healper = 100;
        pl.getper = 100;
        pl.perpower = 100;
        pl.weaponnum = 0;
        pl.weapon2num = -1;
        pl.defense = 1;
        pl.defenseper = 1;
        pl.power = 1;
        pl.attackspeed = 100;
        pl.speed = 3;
        pl.slowint = 1;
        pl.Cri = 10;
        pl.Boomcooldown = 15;
        pl.catlv[0] = 0;
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = false;
        pl.curstage = 0;
        pl.dobattle = false;
        pl.slow = false;
        pl.poison = false;
        pl.isTouchtop = false;
        pl.isTouchbottom = false;
        pl.isTouchleft = false;
        pl.isTouchright = false;
        pl.czefgetper = 1;
        pl.czefcri = 1;
        pl.czefdel = 1;
        pl.czeflife = 1;
        pl.czefpower = 1;
        pl.maxlife = 100;
        for (int i = 0; i < gm.lbbace.Length; i++)
            gm.lbbace[i].SetActive(true);
        gm.managerbossHPgroup[0].SetActive(false);
        gm.managerbossHPgroup[1].SetActive(false);

        for (int i =0;i< 50; i++)
        {
            if(i< pl.mainpl.Length)
            {
                if(i==0)
                    pl.mainpl[i].SetActive(true);
                else
                    pl.mainpl[i].SetActive(false);
            }
            if(i<gm.chaptertbt.Length)
                gm.chaptertbt[i].SetActive(false);
            if (i < pl.hasset.Length)
                pl.hasset[i] = 0;
            if (i < pl.getset.Length)
                pl.getset[i] = false;
            if (i < gm.invennum.Length)
            {
                if(i == 9 || i == 10)
                    gm.invennum[i] = 0;
                else if(i <=8 || i == 11)
                    gm.invennum[i] = -1;
            }
            if (i < ui4.Length)
                ui4[i].SetActive(false);
            if (i < gm.btweapon.Length)
                gm.btweapon[i].SetActive(false);
            if(i < onlyshop.Length)
                onlyshop[i] = -1;
            if (i < gm.unknownui.Length)
                gm.unknownui[i].SetActive(false);
            if (i < gm.data.plbuff.Length)
                gm.data.plbuff[i] = 0;
            if(i < gm.battleobj.Length)
                gm.battleobj[i].SetActive(false);
            if(i< menuui.Length)
                menuui[i].SetActive(false);
            if (i < pl.czint.Length)
                pl.czint[i] = 0;
            if (i < pl.mainbuffdata.Length)
                pl.mainbuffdata[i] = 1;
            if (i < gm.shop.Length)
                gm.shop[i].SetActive(false);
            if (i < gm.npctxtobj.Length)
                gm.npctxtobj[i].SetActive(false);
            if (i < gm.unknown.Length)
                gm.unknown[i].SetActive(false);
            if (i < gm.set.Length)
                gm.set[i].SetActive(false);
        }

        baceui[4].SetActive(true);
        baceui[5].SetActive(true);
        only[5] = 0;
        only[6] = -1;
        only[0] = 0;
        only[2] = -1;
        only[7] = -1;
        gm.mainbuff[(int)data.mainbool[17]].SetActive(false);
        gm.mainbuff[0].SetActive(false);
        gm.exit.SetActive(false);
        data.mainbool[17] = 0;
        pl.getinformation();
        StartCoroutine(lobby());
        ui4imformationtxt[2].text = " ";
        gm.data.mainbool[14] = 0;
        gm.data.mainbool[15] = 0;
        gm.data.mainbool[16] = 0;
        gm.data.mainbool[17] = 0;
        gm.data.chapterindex = 0;
        gm.mainonly = false;
        gm.czing = false;
        gm.stage = 0;
        gm.btend = false;
        gm.nearint = -100;
        gm.fadescript.chapter = 0;
        gm.objectmanagerfind = false;
        gm.backobj.SetActive(false);
        gm.gameoverset.SetActive(false);
        gm.player.transform.position = new Vector2(0, -2.5f);
        gm.fade.SetActive(true);
        gm.fadeanim.SetTrigger("mainin");
        uiexitbt[4].SetActive(false);
        MoonBtn.SetActive(true);
        SceneManager.LoadScene(1);
        gm. nextuif();
    }
    public void Rweaponeset()// �ʱ�ȭ ��ư
    {
        if (gm.inven[12].activeSelf)
            return;

        if (pl.Coin >= gm.rancoin * (1+(gm.shopresetindex * 1.2f)))
        {
            pl.Coin -= gm.rancoin * (1 + (gm.shopresetindex * 1.2f));
            if (gm.shop[2].activeSelf)
            {
                
                for (int i = 0; i < gm.btweapon.Length; i++)
                {
                    if (i < 3)
                        onlyshop[i] = -1;
                    gm.btweapon[i].SetActive(false);
                    gm.spownweaponindex = 0;
                    if (i == (gm.btweapon.Length-1))
                        StartCoroutine(ranshopweapon());
                }
            }
            else if (gm.shop[4].activeSelf)
            {

                for (int i = 0; i < gm.btbullet.Length; i++)
                {
                    if (i < 2)
                        onlyshop[i+3] = -1;
                    gm.btbullet[i].SetActive(false);
                    gm.spownbulletindex = 0;
                    if (i == (gm.btbullet.Length-1))
                        StartCoroutine(ranshopweapon1());
                }
            }
            gm.shopresetindex++;
            gm.rancointxt[5].text = (gm.rancoin * (int)(1 + (gm.shopresetindex * 1.2f))).ToString();
         
            for (int i = 11; i < gm.setinven.Length; i++)
                gm.setinven[i].SetActive(false);
            pl.StartCoroutine(pl.txt());
        }
    }

    public IEnumerator ranshopweapon()//������ �ʱ�ȭ
    {
        inforsel();
        yield return new WaitForSecondsRealtime(0.1f);
        int ranstage = gm.stage > 13 ? 10 : 0;
        int ranstage2 = gm.stage > 3 ? 18 : 8;
        int ranstage3 = gm.stage > 9 ? 11 : 1;
        int ranstage4 = gm.stage > 13 ? 7 : 1;
        while (gm.spownweaponindex < 3)
        {
            int pi = Random.Range(ranstage,ranstage2 + ranstage3+ ranstage4);
            if (gm.invennum[0] != pi &&gm.invennum[1] != pi &&
                gm.invennum[2] != pi &&gm.invennum[3] != pi &&
                gm.invennum[4] != pi &&gm.invennum[5] != pi &&
                gm.invennum[6] != pi &&gm.invennum[7] != pi &&
                gm.invennum[8] != pi && gm.btweapon[pi].activeSelf == false)
            {
                item item = gm.btweapon[pi].GetComponent<item>();
                float i = Random.Range(1, 1.2f);
                gm.btweapon[pi].SetActive(true);
                gm.btweapon[pi].transform.position =
                    gm.itempos[gm.spownweaponindex].transform.position;
                if (pi < 10)
                    gm.weapontypecoin = (int)(gm.rancoin*i);                
                else if (pi < 20)
                    gm.weapontypecoin = (int)(gm.rancoin * i*1.15f);
                else if (pi < 30)
                    gm.weapontypecoin = (int)(gm.rancoin *i* 1.30f);
                else if (pi < 40)
                    gm.weapontypecoin = (int)(gm.rancoin *i* 1.5f);
                gm.rancointxt[gm.spownweaponindex].text = gm.weapontypecoin.ToString();
                item.thiscoin = (int)gm.weapontypecoin;
                onlyshop[gm.spownweaponindex] = item.velue;
                gm.spownweaponindex++;
            }
        }
    }
    public IEnumerator ranshopweapon1()// ���� �ʱ�ȭ
    {
        inforsel();
        yield return new WaitForSecondsRealtime(0.1f);
        while (gm.spownbulletindex < 2)
        {
            int ran = Random.Range(0, gm.btbullet.Length);
            if (gm.btbullet[ran].activeSelf == false
                && gm.invennum[10] != ran && gm.invennum[11] != ran)
            {               
                float i = Random.Range(1, 1.2f);
                item item = gm.btbullet[ran].GetComponent<item>();
                gm.btbullet[ran].transform.position =
                gm.item1pos[gm.spownbulletindex].transform.position;
                if (ran < 10)
                    gm.weapontypecoin = (int)(gm.rancoin *i* 1.75f);
                else if (ran < 20) 
                    gm.weapontypecoin = (int)(gm.rancoin *i* 1.9f);
                else if (ran < 30)
                    gm.weapontypecoin = (int)(gm.rancoin * i*2.05f);
                else if (ran < 40)
                    gm.weapontypecoin = (int)(gm.rancoin * i*2.3f);
                gm.rancointxt[gm.spownbulletindex+3].text = gm.weapontypecoin.ToString();
                item.thiscoin = (int)gm.weapontypecoin;
                onlyshop[gm.spownbulletindex+3] = item.velue;
                gm.spownbulletindex++;
            }
        }
       
    }
    
    public void sellweapon()//�ǸŹ�ư
    {
        if (gm.inven[12].activeSelf)
        {
            item item = gm.wpnearobj.GetComponent<item>();
           
            for (int a = 0; a < 9; a++)
            {
                if (a == item.weaponpos)
                {
                    //������ �ɷ�ġ ����
                    pl.attackspeed -= item.wpattackspeed;
                    pl.Boomcooldown -= item.wpBoomcooldown;
                    pl.Cri -= (int)item.wpCri;
                    pl.Cridmg -= (int)item.wpCridmg;
                    pl.getper -= item.wpgetper;
                    pl.healper -= (int)item.wphealper;
                    pl.maxlife -= (int)item.wpmaxlife;
                    pl.power -= (int)item.wppower;
                    pl.perpower -= (int)item.wpperpower;
                    pl.speed -= (int)item.wpspeed;
                    pl.shotspeed -= (int)item.wpshotspeed;
                    pl.defense -= (int)item.wpdefense;
                    item.weaponpos = -1;
                    //��Ʈ������
                    for (int r = 0; r < item.wphasset.Length; r++)
                    {pl.hasset[r] -= item.wphasset[r];}
                    //�κ� ����
                    gm.invennum[a] = -1;
                    StartCoroutine(repos());
                    float getcoin = item.thiscoin / 5 * pl.plui[6] * pl.maindata[10];
                    pl.Coin += (int)getcoin;
                    pl.getinformation();
                }
            }
        }
        else if (gm.inven[12].activeSelf == false && gm.wpnearobj != null)
        {
            item nearitem = gm.wpnearobj.GetComponent<item>();
            if (gm.wpnearobj.gameObject.tag == "weapon" )
            {
                if (nearitem.velue < 10)
                    gm.weapontypecoin = gm.rancoin;
                else if (nearitem.velue < 20)
                    gm.weapontypecoin = (int)(gm.rancoin * 1.15f);
                else if (nearitem.velue < 30)
                    gm.weapontypecoin = (int)(gm.rancoin * 1.30f);
                else if (nearitem.velue < 40)
                    gm.weapontypecoin = (int)(gm.rancoin * 1.5f);

                float getcoin = gm.weapontypecoin / 5 * pl.plui[6] * pl.maindata[10];
                pl.Coin += getcoin;
            }
            else if(gm.wpnearobj.gameObject.tag == "cat")
            {
                if (nearitem.vltype.Equals("���"))
                    gm.weapontypecoin = 30;
                else if (nearitem.vltype.Equals("����"))
                    gm.weapontypecoin = 60;
                else if (nearitem.vltype.Equals("����ũ"))
                    gm.weapontypecoin = 120;
                else if (nearitem.vltype.Equals("����"))
                    gm.weapontypecoin = 250;
                float getcoin = gm.weapontypecoin * pl.plui[6] * pl.maindata[10];
                pl.churoo += getcoin;
            }
            gm.StartCoroutine(gm.choice());
            gm.nearint = -100;
        }

        for (int i = 11; i < gm.setinven.Length; i++)
            gm.setinven[i].SetActive(false);
        gm.wpnearobj.SetActive(false);
        gm.information.SetActive(false);
        inforsel();
        if (gm.box[4].activeSelf == true)
            gm.box[4].SetActive(false);
        pl.StartCoroutine(pl.txt());
    }
    IEnumerator repos()
    {
       
        for (int repos = 0; repos < 8; repos++)
        {
            if (gm.invennum[repos] == -1 && gm.invennum[repos + 1] != -1)
            {
                item next = gm.btweapon[gm.invennum[repos + 1]].GetComponent<item>();
                next.weaponpos = repos;
                gm.invennum[repos] = gm.invennum[repos + 1];
                gm.invennum[repos + 1] = -1;
                gm.btweapon[gm.invennum[repos]].transform.position =
                    gm.inven[repos].transform.position;
            }
        }
       
        setreposint = gm.setinvenposint.Length - 1;
        while (setreposint > -1)
        {
            for(int y = 0;y<gm.setinvenposint.Length-1;y++)
            {
                if (gm.setinvenposint[y]==-1 && gm.setinvenposint[y+1] != -1)
                {
                    gm.setinvenposint[y] = gm.setinvenposint[y + 1];
                    gm.setinvenposint[y + 1] = -1;
                }
            }
            setreposint--;
            yield return new WaitForSecondsRealtime(0.04f);
        }
        yield return StartCoroutine(pl.order()); 
        StartCoroutine(setpos());
    }
        public void buyweapon() //���Ź�ư
    {
       item item = gm.wpnearobj.GetComponent<item>();
        if (gm.wpnearobj.gameObject.tag == "weapon" && item.typeint == 1)
        {
            if (gm.invennum[0] == -1 || gm.invennum[1] == -1 || gm.invennum[2] == -1
                || gm.invennum[3] == -1 || gm.invennum[4] == -1 || gm.invennum[5] == -1
                || gm.invennum[6] == -1 || gm.invennum[7] == -1 || gm.invennum[8] == -1)
            {
                if (pl.Coin >= item.thiscoin)
                {
                    pl.Coin -= item.thiscoin;
                    if (gm.shop[2].activeSelf==true)
                    {
                        for(int i =0;i<3;i++)
                        {
                            if (onlyshop[i] == item.velue)
                                onlyshop[i] = -1;
                        }
                    }
                    inforsel();
                    pl.interation();
                }
                else
                {
                    gm.npctxtobj[0].SetActive(true);
                    gm.npctxt[2].text =
                        "���� ������...\n" + "�������� �����ϸ� �ɱ�?";
                    invenbt();
                    pl.StartCoroutine(pl.unknowneftxtobjf());
                }
            }
            else
            {
                gm.npctxtobj[0].SetActive(true);
                gm.npctxt[2].text =
                     "�������� �� á��!\n" + "�������� �����ؾ߰ھ�!";
                invenbt();
                pl.StartCoroutine(pl.unknowneftxtobjf());
            }
        }
        else if (gm.wpnearobj.gameObject.tag == "shotweapon" && item.typeint == 3)
        {
            if (pl.Coin >= item.thiscoin)
            {
                pl.Coin -= item.thiscoin;
                if (gm.shop[4].activeSelf == true)
                {
                    for (int i = 3; i < 5; i++)
                    {
                        if (onlyshop[i] == item.velue)
                            onlyshop[i] = -1;
                    }
                }
                gm.selectweapontype.SetActive(true);
                inforsel();
            }
            else
            {
                gm.npctxtobj[0].SetActive(true);
                gm.npctxt[2].text =
                    "���� ������...\n" + "�������� �����ϸ� �ɱ�?";
                gm.inven[12].SetActive(true);
                pl.StartCoroutine(pl.unknowneftxtobjf());
            }
        }
        pl.StartCoroutine(pl.txt());
    }
    public void cancel()
    {
        item item = gm.nearobj.GetComponent<item>();
        pl.Coin += item.thiscoin;
        gm.selectweapontype.SetActive(false); 
    }

    public void slot1()
    {
        item item = gm.nearobj.GetComponent<item>();
        pl.weaponnum = item.velue;
        gm.invennum[10] = item.velue;

        gm.btbullet[pl.weaponnum].transform.position =
            gm.inven[10].transform.position;
        gm.selectweapontype.SetActive(false);
        gm.nearobj.SetActive(false);
        gm.information.SetActive(false);
        pl.StartCoroutine(pl.txt());
    }
    public void slot2()
    {
        item item = gm.nearobj.GetComponent<item>();
        pl.weapon2num = (item.velue);
        gm.invennum[11] = item.velue;
        gm.btbullet[item.velue].transform.position =
            gm.inven[11].transform.position;
        gm.selectweapontype.SetActive(false);
        gm.nearobj.SetActive(false);
        gm.information.SetActive(false);
        pl.StartCoroutine(pl.txt());
    }
    public void unknownget()
    {
        
        if (gm.unknown[1].activeSelf == true)
        {
            if (pl.Coin >= gm.rancoin)
            {
                onlycz = false;
                gm.unknown[4].SetActive(false);
                gm.npctxt[1].text = "����! �и� ū ������ �� �ž�!";
                gm.npctxtobj[4].SetActive(true);
                pl.Coin -= gm.rancoin;
                while (onlycz != true)
                {
                    int ran = Random.Range(0, 5);
                    if (ran < 1)
                    {//��
                        if (pl.czint[0] <= 3)
                        {
                            pl.power += 15;
                            pl.czint[0]++;
                            onlycz = true;
                            posin = 0;
                            gm.npctxt[4].text = "���� ������ �� ����!";
                            gm.data.plbuff[0]++;
                        }
                    }
                    else if (ran < 2)
                    {//ü��
                        if(pl.czint[1] <= 2)
                        {
                            pl.maxlife += 50;
                            posin = 1;
                            pl.czint[1]++;
                            onlycz = true;
                            gm.npctxt[4].text = "���� �� �ǰ����� �� ����!";
                            gm.data.plbuff[1]++;
                        }
                    }
                    else if (ran < 3)
                    {//ġ��Ÿ
                        if (pl.czint[2] <= 1)
                        {
                            pl.Cri += 10;
                            pl.czint[2]++;
                            posin = 2;
                            onlycz = true;
                            gm.npctxt[4].text = "���� ������ �� �� ���� �� ����!";
                            gm.data.plbuff[2]++;
                        }
                    }
                    else if (ran < 4)
                    {//����
                        if (pl.czint[3] <= 1)
                        {
                            pl.maxShotDelay -= 0.1f;
                            posin = 3;
                            pl.czint[3]++;
                            onlycz = true;
                            gm.npctxt[4].text = "���� ������ ������ �� ��������!";
                            gm.data.plbuff[3]++;
                        }

                    }
                    else if (ran < 5)
                    {//����� ��ų �𰡼�
                        if (pl.czint[4] <= 3)
                        {
                            pl.Boomcooldown -= 2f;
                            posin = 4;
                            pl.czint[4]++;
                            onlycz = true;
                            gm.npctxt[4].text = "������ ����...\n" +
                                "�� ����̰� �� ��������?\n" +
                                "(����� ��ų ��Ÿ�Ӱ���!)";
                            gm.data.plbuff[4]++;
                        }
                    }
                }
                StartCoroutine(unknownuipos());
                pl.StartCoroutine(pl.unknowneftxtobjf());
            }
            else if (pl.Coin < gm.rancoin)
            {
                gm.npctxt[1].text = "�ʵ� ���� ���� ó��������...";
            }
        }
        else if(gm.unknown[2].activeSelf == true)
        {
            if (pl.Coin >= gm.rancoin)
            {
                pl.Coin -= gm.rancoin;
                gm.npctxt[1].text = "����! ������ �ǹ̷�\n" + "�̰� �ٰ�!";
                StartCoroutine(ranweapon());
                gm.unknown[4].SetActive(false);
                gm.buyweaponbt.SetActive(false);
            }
            else if (pl.Coin < gm.rancoin)
            {
                gm.npctxt[1].text = "�ʵ� ���� ���� ó��������...";
            }
        }
        else if (gm.unknown[3].activeSelf == true)
        {
            gm.npctxt[1].text = "���� ����� �?\n"
        + "������ �� ���������,\n" + "�и� ū ������ �ɰž�!";
            gm.npctxtobj[4].SetActive(true);
            int ran = Random.Range(0, 5);
            cztime = 180;
            posin = 5;
            if (ran < 1)
            {//��
                pl.czefpower = 0.5f;
                gm.npctxt[4].text = "3�а� ������ 50%����...\n" + "�� ���Ŀ�?";
                gm.data.plbuff[5] = 1;
            }
            else if (ran < 2)//
            {//ü��
                pl.maxlife -= 80f;
                pl.czeflife = 0.2f;
                gm.data.plbuff[5] = 2;
                gm.npctxt[4].text = "3�а� �ִ�ü�� ����, ȸ���� 80%����...\n" + " �� ���Ŀ�?";
            }
            else if (ran < 3)
            {//ġ��Ÿ ��
                pl.czefcri = 2 / 3f;
                gm.data.plbuff[5] = 3;
                gm.npctxt[4].text = "3�а� ġ��Ÿ������ ����...\n" + "�� ���Ŀ�?";
            }
            else if (ran < 4)
            {//����
                pl.czefdel = 0.5f;
                gm.data.plbuff[5] = 4;
                gm.npctxt[4].text = "3�а� ���ݼӵ� 50% ����...\n" + " �� ���Ŀ�?";
            }
            else if (ran < 5)
            {//�Ⱦ� ����    
                pl.czefgetper = 0.2f;
                gm.data.plbuff[5] = 5;
                gm.npctxt[4].text = "3�а� �Ⱦ�������ȹ�淮 50% ����...\n" + " �� ���Ŀ�?";
            }
            pl.StartCoroutine(pl.unknowneftxtobjf());
            StartCoroutine(getczafter());
            
            gm.unknown[4].SetActive(false);
            gm.czing = true;
        }
        pl.StartCoroutine(pl.txt());
    }
     IEnumerator unknownuipos()
    {
        yield return new WaitForFixedUpdate();
        Image image = gm.unknownui[posin].GetComponent<Image>();
        if (gm.unknownui[posin].activeSelf == false)
        {
            for (int i = 11; i < gm.setuipos.Length; i++)
            {
                RectTransform pos = gm.setuipos[i].GetComponent<RectTransform>();

                if (posck[i] == false)
                {
                    RectTransform czui = gm.unknownui[posin].GetComponent<RectTransform>();

                    czui.position =
                        new Vector3(pos.position.x, pos.position.y, 0);
                    gm.unknownui[posin].SetActive(true);
                    czcount[posin]++;
                    czcounttxt[posin].text = czcount[posin].ToString();
                    if(posin == 0)
                    {image.color = Color.red; }
                    else if (posin == 1)
                    {image.color = Color.green; }
                    else if (posin == 2)
                    { image.color = Color.yellow; }
                    else if (posin == 3)
                    { image.color = Color.cyan; }
                    else if (posin == 4)
                    { image.color = Color.magenta; }
                    else if (posin == 5)
                    { 
                        if (gm.data.plbuff[5] == 1)
                            image.color = Color.red;
                        else if (gm.data.plbuff[5] == 2)
                            image.color = Color.green;
                        else if (gm.data.plbuff[5] == 3)
                            image.color =  new Color(1,0.6f,0.2f,1);
                        else if (gm.data.plbuff[5] == 4)
                            image.color = Color.cyan;
                        else if (gm.data.plbuff[5] == 5)
                            image.color = Color.yellow;
                    }
                    posck[i] = true;
                    break;
                }
            }    
        }            
        else if(gm.unknownui[posin].activeSelf == true)
        {
            czcount[posin]++;
            czcounttxt[posin].text = czcount[posin].ToString();
        }
    }
   
    IEnumerator ranweapon()
    {
        int pi = Random.Range(0, gm.btweapon.Length);
        if (gm.invennum[0] == pi || gm.invennum[1] == pi
            || gm.invennum[2] == pi|| gm.invennum[3] == pi
            || gm.invennum[4] == pi|| gm.invennum[5] == pi
            || gm.invennum[6] == pi|| gm.invennum[7] == pi
            || gm.invennum[8] == pi)
            StartCoroutine(ranweapon());
        else
        {
            RectTransform wp = gm.btweapon[pi].GetComponent<RectTransform>();
            RectTransform bt = gm.unknown[4].GetComponent<RectTransform>();
            item item = gm.btweapon[pi].GetComponent<item>();
            gm.btweapon[pi].SetActive(true);
            wp.position = bt.position;
            if (gm.unknown[2].activeSelf == true)
                onlyczweapon = item.velue;
        }
        yield return new WaitForSecondsRealtime(0.03f);
    }

    public IEnumerator getczafter()
    {
        RectTransform uipos = gm.unknownui[11].GetComponent<RectTransform>();
        RectTransform czui = gm.unknownui[posin].GetComponent<RectTransform>();
        StartCoroutine(unknownuipos());
        gm.getweaponbt.SetActive(true);
        gm.unknownui[11].SetActive(true);
        Image image = gm.unknownui[11].GetComponent<Image>();
        while (cztime >= 0)
        {
            cztime -= Time.deltaTime;
            image.fillAmount = (cztime / 180);
            uipos.position = czui.position;
            yield return new WaitForFixedUpdate();
        }
        if(cztime <= 0)
        {
            if (pl.czefgetper <= 0.5f)
                pl.czefgetper = 2f;
            else if (pl.czefcri < 0.9f)
                pl.czefcri = 1.5f;
            else if (pl.czefdel < 0.9f)
                pl.czefdel = 1.5f;
            else if (pl.czeflife < 0.9f)
            {
                pl.czeflife = 1.5f;
                pl.maxlife += 200f;
                pl.life += 200f;
            }
            else if (pl.czefpower < 0.9f)
                pl.czefpower = 1.5f;
            pl.StartCoroutine(pl.txt());
        }
    }
    public void evolution()
    {
        if(pl.churoo >= gm.consumption)
        {
            pl.churoo -= gm.consumption;
            //�ִ� �߰� �Ұ�
            pl.catlv[0]++;
            if (pl.catlv[0] == 0)
                gm.consumption = 50;
            else if (pl.catlv[0] == 1)
                gm.consumption = 150;
            else if (pl.catlv[0] == 2)
                gm.consumption = 500;
            gm.Evolutiontxt[2].text = string.Format("{0:n0}", pl.churoo);
            if (pl.catlv[0] < 3)
            {
                gm.Evolutiontxt[0].text = "����̰� ���� ��������!\n"
               + "�η����� �غ��ϴ� ��\n"+ "ū ������ �� �ž�!\n"+
               gm.consumption.ToString()+"�� �� �ִٸ�\n �� ������ �� �־�";
                gm.Evolutiontxt[1].text = "�� �־�!\n"
                    +gm.consumption.ToString();
            }
            else if(pl.catlv[0] == 3)
            {
                gm.Evolutiontxt[0].text = "����̰� ���� ���� ���°� �ƾ�!\n"
             + "�η����� �غ��ϴ� ��\n" + "ū ������ �� �ž�!\n"+
             "�ٸ� ������ �� �� ����̰� ���� ��\n"+
             "�ٽ� ã�ƿð�!";
                gm.Evolution[1].SetActive(false);
            }
        }
        else
        {
            gm.Evolutiontxt[0].text = "������ �ְ� ������.\n"
             + "�򸣰� ���ٸ�\n" + "������ �� ���� ����.\n" +
            "������ ���� �ȴٸ�\n�׶��� �غ� �� �ֱ⸦ �ٶ���.";
            gm.Evolution[1].SetActive(false);
        }
        pl.StartCoroutine(pl.txt());
    }
}
