using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public datamanager data;
    public ObjectManager objectmanager;
    public bool objectmanagerfind;
    public back back;
    public player pl;
    public uianim fadescript;
    public buttonmanager bt;

    public GameObject backobj, lbback;
    public bool btend;

    public GameObject[] Evolution;
    public Text[] Evolutiontxt;
    public int consumption;

    public GameObject[] set;
    public GameObject[] setuipos;
    public int[] setuiint;

    public GameObject[] inven;
    public GameObject[] setinven;
    public Image[] setinvenui;
    public GameObject[] setinvenpos;
    public GameObject setimpos;
    public int setinvennextint;
    public int[] setinvenposint;
    public Text[] setinvenint;
    public Text[] setinveninformation;
    public int[] invennum;
    public GameObject nearobj;
    public GameObject wpnearobj;
    public int nearint;
    public GameObject[] btweapon;
    public GameObject[] btcat;
    public GameObject[] btbullet;
    public GameObject[] imweapon;
    public GameObject[] imcat;
    public GameObject[] imbullet;
    public Text[] ability;
    public GameObject[] uicat;
    public GameObject sellweaponbt;

    public GameObject information;
    public GameObject getweaponbt;
    public GameObject buyweaponbt;
    public Transform[] itempos;
    public Transform[] item1pos;
    public int rancoin;
    public int shopresetindex;
    public float weapontypecoin;
    public int spownweaponindex;
    public int spownbulletindex;
    public Text[] rancointxt;
    public GameObject selectweapontype;

    public GameObject btpos;
    public GameObject repos;
    public GameObject shoppos;
    public GameObject[] shop;
    public Animator shopanim;
    public GameObject[] unknown;
    public GameObject[] unknownui;
    public GameObject[] npctxtobj;
    public Text[] npctxt;
    public GameObject exit;
    public bool theshop, theevolution;
    public bool theunkown;



    public int stage;
    public string bossname;
    public int enemydeadint;
    public int stageenemyint;
    public int enemyint;
    public int enemyperint;


    public GameObject stagean;
    public Animator stageanim;
    public Text stage1txt;
    public GameObject stageper;
    public Text stage1pertxt;
    public Text stagepertxt;
    public Animator stageperanim;
    public GameObject fade;
    public Animator fadeanim;

    public GameObject clearan;
    public Animator clearanim;

    public GameObject failan;
    public Animator failanim;
    public Transform playerpos;


    public string[] enemyobjs;
    public Transform[] spawn1points;

    public float maxspawn1delay;
    public float curspawn1delay;

    public GameObject player;
    public GameObject playerhitpoint;
    public GameObject boss;
    public RectTransform bossbadypos;
    public Text coinText, shopcointxt;
    public Text churooText;
    public Text soulText;
    public Text playerHP;
    public Text defint;
    public Image defim;
    public RectTransform playerHPbar;
    public RectTransform playermaxHPbar;

    public Text gamebossHP;
    public RectTransform gamebossHPbar, gamebossrmaxHPbar;
    public Animator gamebossHPbaram, gamebossimam, camaan;
    public Text[] bosstext;
    public GameObject[] managerbossHPgroup;

    public GameObject[] box;
    public Text boxtxt;

    public GameObject nextui;
    public GameObject[] Rnext;
    public GameObject[] Lnext;


    public GameObject gameoverset;
    public GameObject dmgtxt;
    public int spawn1index;
    public bool spawn1end;
    public bool isstop;
    public bool stageitem;
    public Image boomcl, defcolim, atkcolim;
    public bool clear = false;
    public bool bosstime = false;
    public bool czing;
    public bool mainonly;
    public bool spownstart;
    public GameObject[] mainbuff;
    //��Ʋ ����?
    public GameObject[] battleobj;


    //������ư
    public GameObject[] lbbace;
    public GameObject[] menuui;
    public GameObject mebt;
    public Text[] code;
    public InputField adfasdf;
    public GameObject panel;
    public GameObject joystickobj;
    public Text movetxt;
    public GameObject uiopening;
    public Text uiopeningtxt;

    //���� Ŭ����
    public string[] chaptername;
    public Text[] chapternametxt;
    public Text[] chaptertxt;
    public GameObject[] chaptertbt;
    public Animator chapter;

    

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
        fade.SetActive(true);
        fadeanim.SetTrigger("mainin");
        Invoke("ttck",1);
        stage = 0;
        if(data.chapterindex == 0)
        {
            for(int i = 0; i< battleobj.Length;i++)
                battleobj[i].SetActive(false);
            StartCoroutine(lbstart());
        }
    }
           
    IEnumerator lbstart()
    {
        pl.coinsel = false;
        pl.chooruselsel = false;
        pl.itemsel = false;
        pl.catsel = false;
        pl.curstage = 0;
        pl.dobattle = false;
        mainonly = false;
        nearint = -100;
        if (data.chapterindex != 0)
        {
            StartCoroutine(stagestart());
            backobj.SetActive(true);
        }
        yield return new WaitForSecondsRealtime(0.2f);
        bt.movebt();
        yield return new WaitForSecondsRealtime(0.2f);
        bt.movebt();
    }
    //�� ��ȯ�� �ڷ�ƾ ������ �ִ��̹�Ʈ��
    public IEnumerator stagestart()
    {
        fade.SetActive(true);
        for (int i = 0; i < lbbace.Length; i++)
            lbbace[i].SetActive(false);
        fadeanim.SetTrigger("dofi");//���⼭ �������� ++�� �ؽ�Ʈ ui �۵�(ui�޴���)
        while(objectmanager == null || objectmanager.gm == null)
            yield return new WaitForFixedUpdate();
        back.sprit();
        pl.StartCoroutine(pl.respawntime());
        stage += 1;
        pl.mainpl[0].SetActive(false);
        pl.mainpl[1].SetActive(true);
        pl.mainpl[2].SetActive(true);
        for (int i = 0; i < battleobj.Length; i++)
            battleobj[i].SetActive(true);
        back.stop = false;
        maxspawn1delay = 3;
        theshop = false;
        theunkown = false;
        theevolution = false;
        enemydeadint = 0;
        enemyint = 0;
        nearint = -100;
        bosstime = false;
        stageitem = false;
        spownstart = false;
        enemyobjs = new string[] 
        { "1", "1", "2", "2", "3", "4", "4", "4", "3", "4",
            "5","3", "6", "6", "6", "3", "4", "5", "6", "4"};
        for(int i = 0;i< unknown.Length;i++)
        {unknown[i].SetActive(false);  }
        for (int i = 0; i < npctxtobj.Length; i++)
        { npctxtobj[i].SetActive(false); }
        for (int i = 11; i < setinven.Length; i++)
            setinven[i].SetActive(false);
        shop[3].SetActive(false);
        exit.SetActive(false);
        ability[10].text = string.Format("{0:n0}", pl.curstage);
        pl.npctolk = false;
        pl.curstage++;
        pl.ishit = false;
        pl.StartCoroutine(pl.txt());
    }

    public IEnumerator maingetbuff()
    {//���̵� �ִ� �̺�Ʈ���� �۵�
        Image im = mainbuff[0].GetComponent<Image>();
        Image im1 = mainbuff[(int)data.mainbool[17]].GetComponent<Image>();
        if (data.mainbool[17] != 0)
        {
            mainbuff[0].SetActive(true);
            mainbuff[(int)data.mainbool[17]].SetActive(true);
        }
        im.color = new Color(0, 0f, 0f, 0.5f);
        if (data.mainbool[17] == 1)
        {
            pl.mainbuffdata[0] = 2;
            im1.color = new Color(1, 0.16f, 0.16f, 1f);
        }
        else if (data.mainbool[17] == 2)
        {
            pl.mainbuffdata[1] = 2;
            im1.color = new Color(0.6f, 0.98f, 1, 1f);
        }
        else if (data.mainbool[17] == 3)
        {
            pl.mainbuffdata[2] = 2;
            im1.color = new Color(1, 0.95f, 0.42f, 1f);
        }
        for (int i = 180; i > 0; i -= 1)
        {
            im1.fillAmount = ((float)i / 180);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(0.1f);
        for (int a = 0; a < pl.mainbuffdata.Length; a++)
        {
            pl.mainbuffdata[a] = 1;
        }

        mainbuff[(int)data.mainbool[17]].SetActive(false);
        mainbuff[0].SetActive(false);


        data.mainbool[17] = 0;
    }

    public void stageend()
    {
        btend = true;
        stageperanim.SetTrigger("end");
        clearan.SetActive(true);
        clearanim.SetTrigger("clear");
        if (stage == 20)
        {
                StartCoroutine(chaptercl());
            if(!data.uiopening[3])
            {
                data.uiopening[3] = true;
                uiopening.SetActive(true);
                uiopeningtxt.text = "�Ƚ�ó�� <Ư��>��\nȰ��ȭ�Ǿ����ϴ�.";
                StartCoroutine(uiopeningf());
            }
        }
        else
        {
            if (stage == 5 && !data.uiopening[0])
            {
                data.uiopening[0] = true;
                uiopening.SetActive(true);
                uiopeningtxt.text = "�Ƚ�ó�� <����>��\nȰ��ȭ�Ǿ����ϴ�.";
                StartCoroutine(uiopeningf());
            }

            else if (stage == 10 && !data.uiopening[1])
            {
                data.uiopening[1] = true;
                uiopening.SetActive(true);
                uiopeningtxt.text = "�Ƚ�ó�� <����>��\nȰ��ȭ�Ǿ����ϴ�.";
                StartCoroutine(uiopeningf());
            } 

            else if (stage == 15 && !data.uiopening[2])
            {
                data.uiopening[2] = true;
                uiopening.SetActive(true);
                uiopeningtxt.text = "�Ƚ�ó�� <����>��\nȰ��ȭ�Ǿ����ϴ�.";
                StartCoroutine(uiopeningf());
            }
        }
        data.jsondata.Save();
    }
    IEnumerator uiopeningf()
    {
        yield return new WaitForSecondsRealtime(2f);
        uiopening.SetActive(false);
    }
    IEnumerator chaptercl()
    {
        yield return new WaitForSecondsRealtime(2f);
        chaptertbt[3].SetActive(true);
        chapter.SetTrigger("cl");
        yield return new WaitForSecondsRealtime(1f);
        chaptertbt[0].SetActive(true);
        chaptertxt[0].text = chaptername[data.chapterindex]+"�� ����\n�η����� �̰ܳ¾�!";
        yield return new WaitForSecondsRealtime(3f);
        chaptertxt[0].text = chaptername[data.chapterindex+1] +"�� ����\n�η��� �̰ܺ���?";
        yield return new WaitForSecondsRealtime(3f);
        chaptertxt[0].text = "���� �����۵鵵\n�� ������ �� �־�!";
        yield return new WaitForSecondsRealtime(3f);
        chaptertxt[0].text = "�Ƚ�ó�� ���ư��ٸ�\n��ȥ���� ������\n��� ��������\n������ž�!";
        Time.timeScale = 0;
        chaptertbt[1].SetActive(true);
        chaptertbt[2].SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        if (objectmanager != null)
            objectmanager = null;
        chaptertxt[0].text = "��ȥ������\n�ɷ�ġ�� ������Ѽ�\n�ٽ� �����ϴ� �͵�\n���� ����̾�!";
    }
    public void gonextchapter()
    {
        for (int i = 0; i < chaptertbt.Length; i++)
            chaptertbt[i].SetActive(false);
        objectmanagerfind = false;
        SceneManager.LoadScene(data.chapterindex + 1);
    }
    public void compensation() // ���� qhtkd
    {
        box[4].SetActive(true);
        pl.dobattle = false;
        if (pl.coinsel || pl.chooruselsel ||
            (!pl.coinsel && !pl.chooruselsel
            && !pl.itemsel && !pl.catsel))
        {
            int ran = Random.Range(0, 100);
            if (ran < 40)
            { box[0].SetActive(true); }
            else if (ran < 70)
            { box[1].SetActive(true); }
            else if (ran < 90)
            { box[2].SetActive(true); }
            else if (ran < 100)
            { box[3].SetActive(true); }
        }
        else if (pl.itemsel)
        {
            int ran1 = Random.Range(0, 100);
            float rin =
            Random.Range((400 + (stage * 100)) * 0.8f,
            (400 + (stage * 100)) * 1.2f);
            rancoin = (int)rin;

            if (ran1 < 40)
            {
                while (invennum[0] != nearint && invennum[1] != nearint
                        && invennum[2] != nearint && invennum[3] != nearint
                        && invennum[4] != nearint && invennum[5] != nearint
                        && invennum[6] != nearint && invennum[7] != nearint
                        && invennum[8] != nearint && !stageitem)
                {
                    int ranweapon = Random.Range(0, 10);
                    if (invennum[0] != ranweapon && invennum[1] != ranweapon
                        && invennum[2] != ranweapon && invennum[3] != ranweapon
                        && invennum[4] != ranweapon&& invennum[5] != ranweapon
                        && invennum[6] != ranweapon && invennum[7] != ranweapon
                        && invennum[8] != ranweapon)
                    {
                        float m = Random.Range(1, 1.2f);
                        weapontypecoin = (rancoin * m);
                        item item = btweapon[ranweapon].GetComponent<item>();
                        item.thiscoin = (int)weapontypecoin;
                        nearint = item.velue;
                        stageitem = true;
                        btweapon[ranweapon].SetActive(true);
                        btweapon[ranweapon].transform.position
                            = box[0].transform.position;
                    }
                }
            }
            else if (ran1 < 70)
            {
                while (invennum[0] != nearint && invennum[1] != nearint
                        && invennum[2] != nearint && invennum[3] != nearint
                        && invennum[4] != nearint && invennum[5] != nearint
                        && invennum[6] != nearint && invennum[7] != nearint
                        && invennum[8] != nearint && !stageitem)
                {
                    int ranweapon1 = Random.Range(10, 20);
                    if (invennum[0] != ranweapon1 && invennum[1] != ranweapon1
                        && invennum[2] != ranweapon1 && invennum[3] != ranweapon1
                        && invennum[4] != ranweapon1 && invennum[5] != ranweapon1
                        && invennum[6] != ranweapon1 && invennum[7] != ranweapon1
                        && invennum[8] != ranweapon1)
                    {
                        float m = Random.Range(1, 1.2f);
                        weapontypecoin = (rancoin * m * 1.15f);
                        item item = btweapon[ranweapon1].GetComponent<item>();
                        item.thiscoin = (int)weapontypecoin;
                        nearint = item.velue;
                        btweapon[ranweapon1].SetActive(true);
                        stageitem = true;
                        btweapon[ranweapon1].transform.position
                            = box[0].transform.position;
                    }
                }
            }
            else if (ran1 < 90)
            {
                while (invennum[0] != nearint && invennum[1] != nearint
                        && invennum[2] != nearint && invennum[3] != nearint
                        && invennum[4] != nearint && invennum[5] != nearint
                        && invennum[6] != nearint && invennum[7] != nearint
                        && invennum[8] != nearint && !stageitem)
                {
                    int ranweapon2 = Random.Range(20, 30);
                    if (invennum[0] != ranweapon2 && invennum[1] != ranweapon2
                        && invennum[2] != ranweapon2 && invennum[3] != ranweapon2
                        && invennum[4] != ranweapon2 && invennum[5] != ranweapon2
                        && invennum[6] != ranweapon2 && invennum[7] != ranweapon2
                        && invennum[8] != ranweapon2)
                    {
                        float m = Random.Range(1, 1.2f);
                        weapontypecoin = (rancoin * m * 1.30f);
                        item item = btweapon[ranweapon2].GetComponent<item>();
                        item.thiscoin = (int)weapontypecoin;
                        nearint = item.velue;
                        stageitem = true;
                        btweapon[ranweapon2].SetActive(true);
                        btweapon[ranweapon2].transform.position
                            = box[0].transform.position;
                    }
                }
            }
            else if (ran1 <= 100)
            {
                while (invennum[0] != nearint && invennum[1] != nearint
                        && invennum[2] != nearint && invennum[3] != nearint
                        && invennum[4] != nearint && invennum[5] != nearint
                        && invennum[6] != nearint && invennum[7] != nearint
                        && invennum[8] != nearint && !stageitem)
                {
                    int ranweapon3 = Random.Range(30, 36);
                    if (invennum[0] != ranweapon3 && invennum[1] != ranweapon3
                        && invennum[2] != ranweapon3 && invennum[3] != ranweapon3
                        && invennum[4] != ranweapon3 && invennum[5] != ranweapon3
                        && invennum[6] != ranweapon3 && invennum[7] != ranweapon3
                        && invennum[8] != ranweapon3)
                    {
                        float m = Random.Range(1, 1.2f);

                        if (ranweapon3 < 10)
                            weapontypecoin = (rancoin * m);
                        else if (ranweapon3 < 20)
                            weapontypecoin = (rancoin * m * 1.15f);
                        else if (ranweapon3 < 30)
                            weapontypecoin = (rancoin * m * 1.30f);
                        else if (ranweapon3 < 40)
                            weapontypecoin = (rancoin * m * 1.5f);
                        item item = btweapon[ranweapon3].GetComponent<item>();
                        item.thiscoin = (int)weapontypecoin;
                        nearint = item.velue;
                        stageitem = true;
                        btweapon[ranweapon3].SetActive(true);
                        btweapon[ranweapon3].transform.position
                            = box[0].transform.position;
                    }
                }
            }
            
        }
        else if (pl.catsel)
            StartCoroutine(catselget());
    }
    IEnumerator catselget()
    {
        int catran = Random.Range(0, btcat.Length);
        if (invennum[9] == catran)
        { StartCoroutine(catselget()); }
        else
        {
            item item = btcat[catran].GetComponent<item>();
            nearint = item.velue;
            btcat[catran].SetActive(true);
            btcat[catran].transform.position
                = box[0].transform.position;
        }
        yield return new WaitForSecondsRealtime(0.1f);
    }

    void Update()
    {
        if (objectmanager == null || objectmanager.gm == null)
            return;

        if(!clear && spownstart)
        {
            if (curspawn1delay > maxspawn1delay 
                && !bosstime && enemyint < stageenemyint 
                && !theshop && !theunkown )
            {
               
                if (stage % 5 == 0 && enemyint == stageenemyint - 1 && enemydeadint != enemyint)
                    return;
                if (stage % 5 == 0 && enemydeadint == stageenemyint - 1)
                    spawnboss();
                else
                    spawn1Enemy();
                maxspawn1delay = 
                    Random.Range(1.2f - (stage * 0.05f), 2.3f - (stage * 0.1f));
                curspawn1delay = 0;
            }
            if (stage % 5 == 0 && !bosstime && enemyint == stageenemyint - 1 && enemydeadint != enemyint)
                curspawn1delay = 0;
            else if (enemydeadint >= enemyint - 5)
                curspawn1delay += Time.deltaTime * 3;
            else
                curspawn1delay += Time.deltaTime;
        }
    }

    void spawn1Enemy()
    {
        if (bosstime)
            return;

        int enemyindex = Random.Range(0, stage);
        int enemypoint = Random.Range(0, 9);
        float movem = Random.Range(-1, -0.5f);
        float movep = Random.Range(0.5f, 1);
        float movevec = Random.Range(-0.3f, 0.3f);
        GameObject enemy = objectmanager.MakeObj(enemyobjs[enemyindex]);
       
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        enemy enemyLogic = enemy.GetComponent<enemy>();

        if (enemyLogic.chil != null)
            enemyLogic.chil.SetActive(true);
        enemyLogic.player = player;
        enemyLogic.playerhitpoint = playerhitpoint;
        enemyLogic.gm = this;
        enemyLogic.objectmanager = objectmanager;
        enemyLogic.velzero = false;
        enemyLogic.pl = pl;

        enemy.transform.position = spawn1points[enemypoint].position;
        if (enemypoint == 5 || enemypoint == 6)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), movem);
            if(!enemyLogic.bossbullet)
                enemyint++;

        }
        else if (enemypoint == 7 || enemypoint == 8)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1),  movep);
            if (!enemyLogic.bossbullet)
                enemyint++;
        }
        else if(!enemyLogic.range)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), movevec);
            if (!enemyLogic.bossbullet)
                enemyint++;
        }

    }
    void spawnboss()
    {
        clearan.SetActive(false);
        stageperanim.SetTrigger("bossstart");
        bosstime = true;
        if (stage == 20)
            bossname = "B";
        else if (stage == 15)
            bossname = "miniB3";
        else if (stage == 10)
            bossname = "miniB2";
        else if (stage == 5)
            bossname = "miniB1";

        GameObject enem1y = objectmanager.MakeObj(bossname);
        enem1y.transform.position = spawn1points[2].position;

        Rigidbody2D rigidB = enem1y.GetComponent<Rigidbody2D>();
        enemy enemyBLogic = enem1y.GetComponent<enemy>();
        if (enemyBLogic.chil != null)
            enemyBLogic.chil.SetActive(true);
        enemyBLogic.player = player;
        enemyBLogic.playerhitpoint = playerhitpoint;
        enemyBLogic.gm = this;
        enemyBLogic.box.enabled = false;
        enemyBLogic.objectmanager = objectmanager;
        enemyBLogic.velzero = false;
        enemyBLogic.bossHPgroup[0] = managerbossHPgroup[0];
        enemyBLogic.bossHPgroup[1] = managerbossHPgroup[1];
        enemyBLogic.randmgtxt = dmgtxt;
        enemyBLogic.HP = enemyBLogic.maxHP;
        enemyBLogic.bossHP = gamebossHP;
        enemyBLogic.bossrmaxHPbar = gamebossrmaxHPbar;
        enemyBLogic.bossHPbar = gamebossHPbar;
        enemyBLogic.bossHPbaram = gamebossHPbaram;
        enemyBLogic.bossimam = gamebossimam;
        enemyBLogic.caman = camaan;
        enemyBLogic.pl = pl;
        bosstext[2].text = enemyBLogic.titletext + " " + enemyBLogic.bosstext;

        rigidB.velocity = new Vector2(enemyBLogic.speed * (-1), 0);

    }
    public void GameOver()
    {
        isstop = true;
        Time.timeScale = 0;
        failan.SetActive(true);
        failanim.SetTrigger("fail");
        StartCoroutine(again());
    }
    IEnumerator again()
    {
        yield return new WaitForSecondsRealtime (3f);
        fadeanim.SetTrigger("dofo");
        failan.SetActive(false);
        gameoverset.SetActive(true);
    }
    public IEnumerator choice1()
    {
        if(stage == 5)
        {
            Evolution[2].SetActive(true);
            Evolution[3].SetActive(false);
            Evolution[4].SetActive(false);
        }
        else if (stage == 10)
        {
            Evolution[2].SetActive(false);
            Evolution[3].SetActive(true);
            Evolution[4].SetActive(false);
        }
        else if (stage == 15)
        {
            Evolution[2].SetActive(false);
            Evolution[3].SetActive(false);
            Evolution[4].SetActive(true);
        }


        catevlset();

        theevolution = true;
        exit.SetActive(true);
        fade.SetActive(true);
        fadeanim.SetTrigger("dofo");
        Time.timeScale = 0;
        back.stop = true;
        Evolution[0].SetActive(true);
        Evolution[1].SetActive(true);
        information.SetActive(true);
        Evolutiontxt[2].text = string.Format("{0:n0}", pl.churoo);
        if (pl.catlv[0]<3)
        {
            Evolutiontxt[0].text = "����̰� ���� ������ �� �ƾ�.\n" + "��..." +
           consumption.ToString() + "������ �򸣰� �ִٸ�\n" +
           "���� ��������� �� �ִµ�.\n" + "�� ���� �򸣰� �־�?";
            Evolutiontxt[1].text = "��! �־�!\n" + consumption.ToString(); 
        }
        else
        {
            Evolutiontxt[0].text = "����̰� ���� ���� ���°� �ƾ�!\n"
             + "�η����� �غ��ϴ� ��\n" + "ū ������ �� �ž�!\n" +
             "�ٸ� ������ �� �� ����̰� ���� ��\n" +
             "�ٽ� ã�ƿð�!";
            Evolution[1].SetActive(false);
        }
       
        yield return new WaitForSecondsRealtime(1f);
    }
    public IEnumerator choice()
    {
        nextui.SetActive(true);
        back.stop = true;
        Time.timeScale = 0;
        if (stage % 10 == 9)
        {
            Rnext[5].SetActive(true);
            Lnext[2].SetActive(true);
        }
        else if (stage % 5 == 4 && stage % 10 != 9)
        {
            Rnext[4].SetActive(true);
            Lnext[2].SetActive(true);
        }
        else if (stage % 5 == 2)
        {
            int Rran = Random.Range(0, 9);
            if (Rran < 3)
                Rnext[0].SetActive(true);
            else if (Rran < 6)
                Rnext[1].SetActive(true);
            else if (Rran < 8)
                Rnext[2].SetActive(true);
            else if (Rran < 9)
                Rnext[3].SetActive(true);

            Lnext[0].SetActive(true);
        }
        else
        {
            int Rran = Random.Range(0, 9);
            if (Rran < 3)
            { Rnext[0].SetActive(true); }
            else if (Rran < 6)
            { Rnext[1].SetActive(true); }
            else if (Rran < 8)
            { Rnext[2].SetActive(true); }
            else if (Rran < 9)
            { Rnext[3].SetActive(true); }

            int Lran = Random.Range(0, 9);//���� 
            if (Lran < 4)
            { Lnext[1].SetActive(true); }//����
            else if (Lran < 9)
            { Lnext[2].SetActive(true); }//����    
        }
        yield return new WaitForSecondsRealtime(1f);
    }
    public void catevlset()
    {
        if ((int)pl.catlv[0] == 0)
        {
            bt.catlv = "������, �̵��ӵ�, ����, ���� 100%";
            bt.catlvup = "������ 100% ��120%";
            consumption = 50;
        }

        else if ((int)pl.catlv[0] == 1)
        {
            bt.catlv = "������, �̵��ӵ�, ����, ���� 120%";
            bt.catlvup = "������ 120% ��150%";
            consumption = 150;
        }
        else if ((int)pl.catlv[0] == 2)
        {
            bt.catlv = "������, �̵��ӵ�, ����, ���� 150%";
            bt.catlvup = "������ 150% ��200%";
            consumption = 500;
        }

        else if ((int)pl.catlv[0] == 3)
            bt.catlv = "������, �̵��ӵ�, ����, ���� 200%";

        for (int e = 11; e < setinven.Length; e++)
            setinven[e].SetActive(false);

        for (int i = 0; i < 100; i++)
        {
            if (i < imweapon.Length)
                imweapon[i].SetActive(false);
            if (i < imcat.Length)
            {
                if (i == invennum[9])
                    imcat[i].SetActive(true);
                else
                    imcat[i].SetActive(false);
            }
            if (i < imbullet.Length)
                imbullet[i].SetActive(false);
        }
        item cat = btcat[invennum[9]].GetComponent<item>();

        bt.informationtxt.text
            = cat.weaponname + "\n" + cat.vltype +
            "\n" + cat.weaponinformation.ToString() +
            "\n" + bt.catlv + "\n" + bt.catlvup;

        sellweaponbt.SetActive(false);
        buyweaponbt.SetActive(false);
        getweaponbt.SetActive(false);

    }
    public void nextuif()
    {
        data.jsondata.Save();
        nextui.SetActive(false);
        Rnext[0].SetActive(false);
        Rnext[1].SetActive(false);
        Rnext[2].SetActive(false);
        Rnext[3].SetActive(false);
        Rnext[4].SetActive(false);
        Rnext[5].SetActive(false);
        Lnext[0].SetActive(false);
        Lnext[1].SetActive(false);
        Lnext[2].SetActive(false);
    }


    // Ʃ�丮��
    
    public Text[] tttxt;

    public int[] tttxtint;
    public GameObject[] ttobj;
    public float cps;
    public GameObject ingcursor, endcursor;

    [TextArea]
    public string[] targetmsg;

    int index;
    public Animator ttanim;

    public void ttck()
    {
        if (data.tutorial[9])
            return;

        ttobj[16].SetActive(true);
        tttxt[1].text = "";
        if (!data.tutorial[0])
        {
            ttanim.SetTrigger("in");
            ttobj[0].SetActive(true);
            ttobj[1].SetActive(true);
            ttobj[9].SetActive(false);
            ttobj[13].SetActive(false);
            ttobj[14].SetActive(false);
            ttobj[15].SetActive(true);
            tttxt[0].text = "�޴�";
        }
        Invoke("efstart",1);
    }

    public void ttbt()
    {
        if (!data.tutorial[0] && index == 4)
        {
            ttobj[13].SetActive(true);
        }
        else if (!data.tutorial[0] && index == 4)
        {
            ttobj[13].SetActive(true);
        }
        else if (!data.tutorial[0] && index == 4)
        {
            ttobj[13].SetActive(true);
        }
        ttinout();
    }
    public void ttinout()
    {
        if (ingcursor.activeSelf)
        {
            StopCoroutine(efing());
            for (int i = 0; i < targetmsg[index].Length; i++)
                tttxt[1].text += targetmsg[index][i];
            index++;
            endcursor.SetActive(true);
            ingcursor.SetActive(false);
        }
        else if (endcursor.activeSelf)
        {
            StartCoroutine(efing());
            endcursor.SetActive(false);
            ingcursor.SetActive(true);
        }
    }

    void efstart()
    {
        index = 0;
        endcursor.SetActive(false);
        StartCoroutine(efing());
    }
    IEnumerator efing()
    {
        tttxt[1].text = "";
        yield return new WaitForSecondsRealtime(cps);
        for (int i = 0; i < targetmsg[index].Length;i++)
        {
            tttxt[1].text += targetmsg[index][i];
            yield return new WaitForSecondsRealtime(cps);
        }
        yield return new WaitForSecondsRealtime(cps);
        index++;
        ingcursor.SetActive(false);
        endcursor.SetActive(true);
    }
} 
