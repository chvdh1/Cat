using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameManager gm;
    public datamanager data;



    //아이템 확인
    public GameObject[] catobj;
    public int catint;
    //셋트

    public int[] hasset;
    public bool[] getset;

    public bool isTouchtop;
    public bool isTouchbottom;
    public bool isTouchleft;
    public bool isTouchright;

    public float[] plui;

    public float life;
    public float maxlife;
    public float maxlifeper;
    
    public float speed;
    public float speedper;
    public float mspeedper;
    public float slowint;
    public float shotspeed;
    public float shotspeedper;
    public float mshotspeedper;

    public int power;
    public int perpower;
    public float perpowerper;
    public int Cri;
    public float Criper;
    public int Cridmg;
    public int Cridmgper;
    public int weaponnum;
    public int weapon2num;
    public bool[] settrue;
   
    public float dmg;
    public float Boom,atkcol,defcol,defcount;
    public float boomdmgper, atkdmg;
    public float Boomcooldown,atkcooldown, defcooldown;
    public float Boomcooldownper;
    public float getper;
    public float pergetper;
    public int curstage;
    public float Coin;
    public float churoo;
    public float soul;
    public int healper;
    public int evasion; // 회피
    public int defense;
    public float defenseper;// 방어력
    public float attackspeed; //연사속도
    public float maxShotDelay;
    public float maxShotDelayper;
    public float curShotDelay;
    public float maxShot2Delay;
    public float curShot2Delay;


    public GameObject bulletA;


    public Transform weaponrpoint;

    public bool poison;
    public bool slow;
    public bool ishit;
    public bool dobattle;
    public bool respawn;
    public bool isboomtime;
    public bool isbooming = false;
    public bool isatk = false;
    public bool isdef = false;


    public GameObject[] follow;

    public bool isrespawntime;

    public bool coinsel;
    public bool chooruselsel;
    public bool itemsel;
    public bool catsel;

    public float[] catlv;
    public GameObject[] plmesh;
    public GameObject[] mesh;
    public GameObject[] cat1;
    public GameObject[] cat2;
    public GameObject shl;
    public Transform reposition;
    public Animator[] catam;
    public Animator playeran;
    public SpriteRenderer spriterenderer;
    public Rigidbody2D rigid;
    public BoxCollider2D boxcollider;
    public bool itemtargeting;
    public int[] czint;
    public bool npctolk;
    public float czefpower, czefcri, czefdel, czeflife, czefgetper;
    public float[] maindata;
    public float[] mainbuffdata;
    public bool[] mainbool;
    public bool[] ttbool;

    public joystick joy;
    public Vector2[] mpos;
    public Vector2[] plpos;

    public Animator mainan,skill;
    public GameObject[] mainpl;
    public static player Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        rigid = GetComponent<Rigidbody2D>();
        spriterenderer = mesh[catint].GetComponent<SpriteRenderer>();
        catam[catint] = mesh[catint].GetComponent<Animator>();
    }

    void OnEnable()
    {
        mainpl[0].SetActive(true);
        mainpl[1].SetActive(false);
        mainpl[2].SetActive(false);
    }

    public IEnumerator respawntime()
    {
        lddata();
        respawn = true;
        gm.btend = false;
        gameObject.transform.position = reposition.transform.position;
        this.rigid.velocity = new Vector2(2, 0);
        yield return new WaitForSeconds(2);
        this.rigid.velocity = new Vector2(0, 0);
        isTouchtop = false;
        isTouchbottom = false;
        isTouchleft = false;
        isTouchright = false;
        dobattle = true;
        respawn = false;
        gm.spownstart = true;
        //로비저장 데이터 불러오기.
        StartCoroutine(txt());
    }
    void lddata()
    {
        for (int c = 0; c < maindata.Length; c++)
        { maindata[c] = data.mainbool[c]; }
        gm.invennum[9] = catint;

        if (data.chapterindex != 0)
        {
            for (int a = 0; a < mesh.Length; a++)
            {
                if (a == catint)
                {
                    mesh[a].SetActive(true);
                    gm.invennum[9] = catint;
                    gm.btcat[a].transform.position =
                        gm.inven[9].transform.position;
                    gm.uicat[a].SetActive(true);
                }
                else
                {
                    mesh[a].SetActive(false);
                    gm.btcat[a].SetActive(false);
                    gm.uicat[a].SetActive(false);
                }
            }
            if (!mainbool[12])
            {
                maxlife += maindata[12];
                life = maxlife;
                mainbool[12] = true;
            }
        }
        life += maindata[13];

    }
  
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Q))
            gm.stage = 0;

        if (Input.GetKeyDown(KeyCode.W))
            gm.stage = 5;
        if (Input.GetKeyDown(KeyCode.E))
            gm.stage = 10;
        if (Input.GetKeyDown(KeyCode.R))
            gm.stage = 15;
        if (Input.GetKeyDown(KeyCode.T))
            gm.stage = 20;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Coin += 1000000;
            itemsel = true;
            power += 5000;
            gm.Lnext[0].SetActive(false);
            gm.Lnext[1].SetActive(true);
            gm.Lnext[2].SetActive(false);  }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Coin += 1000000;
            power -= 5000;
            itemsel = true;
            gm.Lnext[0].SetActive(true);
            gm.Lnext[1].SetActive(false);
            gm.Lnext[2].SetActive(false);
        }
       
        if (data.chapterindex == 0)
            Move();

        else if (dobattle && !isbooming && gm.objectmanager != null) 
        {
            Move();
            Reload();
            if (!isdef)
            {
                Fire();
                Fire2();
            }
           
            if (!gm.btend&& !isdef && !isatk && Input.GetKeyDown(KeyCode.S))
                atk();

            if (!gm.btend &&!isdef && !isatk && Input.GetKeyDown(KeyCode.D))
                def();
            
            if (Input.GetKeyDown(KeyCode.A))
                boom();
        }
    }
   
    void Move()
    {
        if (!data.moveset)
        {
            if (joy.joyvec.x >= 1)
            { joy.joyvec.x = 1; }
            if (joy.joyvec.x <= -1)
            { joy.joyvec.x = -1; }
            if (joy.joyvec.y >= 1)
            { joy.joyvec.y = 1; }
            if (joy.joyvec.y <= -1)
            { joy.joyvec.y = -1; }

            float h = joy.joyvec.x;
            float v = joy.joyvec.y;
            bool move = (v >= 0.2f) || (v <= -0.2f) ||
           (h >= 0.2f) || (h <= -0.2f) ? true : false;

            if (data.chapterindex == 0)
            {
                 mainan.SetBool("mainrun", move);

                if (h > 0)
                    gameObject.transform.localScale = new Vector2(1.5f, 1.5f);

                else if (h < 0)
                    gameObject.transform.localScale = new Vector2(-1.5f, 1.5f);

                if ((isTouchright && h > 0) || (isTouchleft && h < 0)) //|| !isC)
                     h = 0;
            }
            if ((isTouchright && h > 0) || (isTouchleft && h < 0)) //|| !isC)
                     h = 0;
            if ((isTouchtop && v > 0) || (isTouchbottom && v < 0))//|| !isC)
                     v = 0;
            
                Vector2 nextPos = new Vector2(h, v) * plui[0] * Time.deltaTime;
            Vector2 pos = transform.position;
            transform.position = pos + nextPos;

           // if (!data.tutorial[0] && !ttbool[0])
            //    ttbool[0] = true;

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            { td(); }
            else if (Input.GetMouseButton(0))
            { tr(); }
            else if (Input.GetMouseButtonUp(0))
            { tp(); }
        }
    }
    public void td()
    {
        if (!data.moveset)
            return;
        mpos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);// 빅
        mpos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);//스몰
        plpos[0] = transform.position;// 빅
        plpos[1] = transform.position;//스몰
        plpos[2] = transform.position;//현위치
        mpos[2] = plpos[0]-mpos[0]; // 플레이어와 폰인트의 거리
    }

    public void tr()
    {
        if (!data.moveset)
            return;
        mpos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);//움직이는 포인트
        plpos[1] = mpos[1] + mpos[2];//플레이어가 가야하는 포인트
        plpos[2] = transform.position;//플레이어 현위치
        Vector2 bace = new Vector2(plpos[1].x - plpos[2].x,
            plpos[1].y - plpos[2].y).normalized;
        bool move = (plpos[1].y - plpos[2].y >= 0.3f) || (plpos[1].y - plpos[2].y <= -0.3f) ||
          (plpos[1].x - plpos[2].x >= 0.3f) || (plpos[1].x - plpos[2].x <= -0.3f) ? true : false;
        if (bace.x < -1)
            bace.x = -1;
        if (bace.x > 1)
            bace.x = 1;

        if (bace.y < -1)
            bace.y = -1;
        if (bace.y > 1)
            bace.y = 1;
        float h = bace.x;
        float v = bace.y;
        
        if ((isTouchright && h > 0) || (isTouchleft && h < 0))
            h = 0;

        if ((isTouchtop && v > 0) || (isTouchbottom && v < 0))
            v = 0;
        Vector2 nomal = new Vector2(h, v);
        Vector2 nextPos = nomal * plui[0] * Time.deltaTime;
        
        if (move)
            transform.position = plpos[2] + nextPos;
        else if(!move)
            transform.position = plpos[2];
        if (data.chapterindex == 0)
        {
            mainan.SetBool("mainrun", move);

            if (h > 0.5f)
                gameObject.transform.localScale = new Vector2(1.5f, 1.5f);

            else if (h < -0.5f)
                gameObject.transform.localScale = new Vector2(-1.5f, 1.5f);
        }
       
    }
    
    public void tp()
    {
        if (!data.moveset)
            return;
        mpos[0] = new Vector2(0, 0);
        mpos[1] = new Vector2(0, 0);
        plpos[0] = transform.position;
        plpos[1] = transform.position;
        plpos[2] = transform.position;
        //plpos[3] = transform.position; 방향
        mpos[2] = new Vector2(0, 0); // 차이값?

        if (!data.tutorial[0] && !ttbool[1])
            ttbool[1] = true;
    }
    public void boom()
    {
        if (isbooming)
            return;
            
        if (Boom <= 0)
        { isbooming = true;

             catam[catint].SetTrigger("doboom");
            playeran.SetTrigger("doboom");
            StartCoroutine(txt());
        }
    }
    public IEnumerator boomEffect()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        while (Boom >= 0)
        {
            Boom -= Time.deltaTime * plui[8];
            gm.boomcl.fillAmount = (Boom / Boomcooldown);
            yield return new WaitForFixedUpdate();
        }
        if (Boom / Boomcooldown <= 0)
        {
            gm.boomcl.fillAmount = 1;
            gm.boomcl.color = Color.white;
            yield return new WaitForSecondsRealtime(0.1f);
            gm.boomcl.fillAmount = 0;
            gm.boomcl.color = new Color(0, 0, 0, 0.5f);
        }
    }
    public void atk()
    {
        if (isatk)
            return;

        if (atkcol <= 0)
        {
            isatk = true;

            skill.SetTrigger("atk");
            StartCoroutine(txt());
        }
        Debug.Log("atkcol");
    }
    public IEnumerator atkEffect()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        atkdmg = 1;
        StartCoroutine(txt());
        while (atkcol >= 0)
        {
            atkcol -= Time.deltaTime;
            gm.atkcolim.fillAmount = (atkcol / atkcooldown);

            yield return new WaitForFixedUpdate();
        }
        if ((atkcol / atkcooldown) <= 0)
        {
            gm.atkcolim.fillAmount = 1;
            gm.atkcolim.color = Color.white;
            yield return new WaitForSecondsRealtime(0.1f);
            gm.atkcolim.fillAmount = 0;
            gm.atkcolim.color = new Color(0, 0, 0, 0.5f);
        }
    }
    public void def()
    {
        if (isdef)
            return;

        if (defcol <= 0)
        {
            isdef = true;
            defcount = 1;

            skill.SetTrigger("def");
            StartCoroutine(txt());
        }
        Debug.Log("defcol");
    }
    public IEnumerator defEffect()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        while (defcol >= 0)
        {
            defcol -= Time.deltaTime * defcount;
            gm.defcolim.fillAmount = (defcol / defcooldown);
            yield return new WaitForFixedUpdate();
        }
        if ((defcol / defcooldown) <= 0)
        {
            gm.defcolim.fillAmount = 1;
            gm.defcolim.color = Color.white;
            yield return new WaitForSecondsRealtime(0.1f);
            gm.defcolim.fillAmount = 0;
            gm.defcolim.color = new Color(0, 0, 0, 0.5f);
        }
    }
   
    public void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        switch (weaponnum)
        {
            case 0:
                //power one
                GameObject bullet = gm.objectmanager.MakeObj("bulletPlayerA");
                bullet logic = bullet.GetComponent<bullet>();
                bullet.transform.position = weaponrpoint.transform.position;
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                logic.weapon2 = false;
                bullet.transform.localScale = new Vector2(1f * maindata[11], 1f * maindata[11]);
                rigid.AddForce(Vector2.right * plui[2] * 10, ForceMode2D.Impulse);
                bullet.transform.Rotate(new Vector3(0, 1, 0) * 180 * Time.deltaTime);
                break;
            case 1:
                //power one
                GameObject bullet1 = gm.objectmanager.MakeObj("bulletPlayer2A");
                bullet logic1 = bullet1.GetComponent<bullet>();
                logic1.weapon2 = false;
                bullet1.transform.localScale = new Vector2(1f * maindata[11], 1f * maindata[11]);
                bullet1.transform.position = weaponrpoint.transform.position;
                Rigidbody2D rigid1 = bullet1.GetComponent<Rigidbody2D>();
                rigid1.AddForce(Vector2.right * plui[2] * 10, ForceMode2D.Impulse);
                break;
        }
        curShot2Delay++;
        curShotDelay = 0;
    }
    public void Fire2()
    {
        if (curShot2Delay < maxShot2Delay)
            return;
        if(weapon2num + 1 == 0)
            return;

        switch (weapon2num+1)
        {
            case 1:
                //power one
                GameObject bullet = gm.objectmanager.MakeObj("bulletPlayerA");
                bullet logic = bullet.GetComponent<bullet>();
                bullet.transform.position = weaponrpoint.transform.position;
                bullet.transform.localScale = new Vector2(1.2f* maindata[11], 1.2f* maindata[11]);
                logic.weapon2 = true;
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * plui[2] * 12, ForceMode2D.Impulse);
                bullet.transform.Rotate(new Vector3(0, 1, 0) * 180 * Time.deltaTime);
                break;
            case 2:
                //power one
                GameObject bullet1 = gm.objectmanager.MakeObj("bulletPlayer2A");
                bullet logic1 = bullet1.GetComponent<bullet>();
                bullet1.transform.position = weaponrpoint.transform.position;
                bullet1.transform.localScale = new Vector2(1.2f* maindata[11], 1.2f* maindata[11]);
                logic1.weapon2 = true;
                Rigidbody2D rigid1 = bullet1.GetComponent<Rigidbody2D>();
                rigid1.AddForce(Vector2.right * plui[2] * 10, ForceMode2D.Impulse);
                break;
        }
        curShot2Delay = 0;
    }
    void die()
    {
        dobattle = true;
        catam[catint].SetTrigger("die");
        playeran.SetTrigger("die");
        //비활성화는 애니이벤트
        gm.GameOver();
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime* plui[1];
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            switch (collision.gameObject.name)
            {
                case "top":
                    isTouchtop = true;
                    break;
                case "bottom":
                    isTouchbottom = true;
                    break;
                case "left":
                    isTouchleft = true;
                    break;
                case "right":
                    isTouchright = true;
                    break;
            }
        }
        else if (collision.gameObject.tag == "enemybullet" )
        {
            if (!isdef && !ishit && !isbooming && !gm.btend)
            {
                ishit = true;
                // ishit = f는 애니 이벤트
                int ran = Random.Range(0, 10+ evasion);
                if(ran <=10)
                {
                    enemybullet enemybulletlogic =
                        collision.gameObject.GetComponent<enemybullet>();
                    if (defense < 1 + (int)enemybulletlogic.dmg - plui[5])
                        life -= 1 + (int)enemybulletlogic.dmg - plui[5];
                    else
                        life -= 1;

                    if (enemybulletlogic.poison && !poison)
                        StartCoroutine(poisoning());
                    if (enemybulletlogic.slow && !slow)
                        StartCoroutine(slowing());


                    StartCoroutine(ishitfals());
                }
                if (life > 0)
                {
                    catam[catint].SetTrigger("dohit");
                    playeran.SetTrigger("dohit");
                }
            }
            StartCoroutine(txt());
        }
        else if (collision.gameObject.layer == 9)
        {
            item item = collision.GetComponent<item>();
            if (item.onlyone)
            {
                GameObject randmgtxt = gm.objectmanager.MakeObj("dmg");
                dmgtxt dmglogic = randmgtxt.GetComponent<dmgtxt>();
                randmgtxt.transform.localScale = new Vector2(0.07f, 0.07f);
                switch (item.type)
                {
                    case item.Type.coin:
                        int Coinran = Random.Range(0, 100);
                        dmglogic.alpha = Color.yellow;
                        if (Coinran < 50)
                        {
                            float aintcoin = 20 * plui[6];
                            Coin += dmglogic.randmgtxt = (int)aintcoin;
                            item.onlyone = false;
                        }
                        else if (Coinran < 80)
                        {
                            float bintcoin = 50 * plui[6];
                            Coin += dmglogic.randmgtxt = (int)bintcoin;
                            item.onlyone = false;
                        }
                        else if (Coinran < 95)
                        {
                            float cintcoin = 80 * plui[6];
                            Coin += dmglogic.randmgtxt = (int)cintcoin;
                            item.onlyone = false;
                        }
                        else
                        {
                            float dintcoin = 130 * plui[6];
                            Coin += dmglogic.randmgtxt = (int)dintcoin;
                            item.onlyone = false;
                        }
                        break;

                    case item.Type.heal:
                        dmglogic.alpha = Color.green;
                        life += dmglogic.randmgtxt = (int)plui[7];
                        item.onlyone = false;
                        break;
                    case item.Type.soul:
                        dmglogic.alpha = Color.magenta;
                        item.onlyone = false;
                        float intsoul = 10 + ((gm.stage - 1) * 5);
                        soul += dmglogic.randmgtxt = (int)intsoul;
                         break;
                }
                randmgtxt.transform.position = transform.position;
            }
            collision.gameObject.SetActive(false);
            StartCoroutine(txt());
        }
        else if(collision.gameObject.tag == "poison" && !poison && !ishit && !isbooming)
        {
            StartCoroutine(poisoning());
        }
    }
    IEnumerator slowing()
    {
        slow = true;
        for (int i = 0; i < plmesh.Length - 1; i++)
        {
            SpriteRenderer sp = plmesh[i].GetComponent<SpriteRenderer>();
            sp.color = new Color(0.5f, 0.5f, 1f, 1);
        }
        for (int i = 0; i < 5; i++)
        {
            float ran =  0.1f+(0.1f*i);
            slowint = ran;
            StartCoroutine(txt());
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < plmesh.Length - 1; i++)
        {
            SpriteRenderer sp = plmesh[i].GetComponent<SpriteRenderer>();
            sp.color = new Color(1, 1, 1, 1);
        }
        slowint = 1;
        slow = false;
    }
    IEnumerator poisoning()
    {
        poison = true;
        for (int i = 0; i< plmesh.Length-1;i++)
        {
            SpriteRenderer sp = plmesh[i].GetComponent<SpriteRenderer>();
            sp.color = new Color(0, 0.5f, 0, 1);
        }
        for (int i = 0; i < 5 && life >0; i++)
        {
            int ran = Random.Range(5, 11);
            if (!gm.btend)
                life -= ran;
            StartCoroutine(txt());
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < plmesh.Length - 1; i++)
        {
            SpriteRenderer sp = plmesh[i].GetComponent<SpriteRenderer>();
            sp.color = new Color(1, 1, 1, 1);
        }
        poison = false;
    }
    public IEnumerator ishitfals()
    {
        yield return new WaitForSecondsRealtime(1);
        ishit = false;
    }
    

    public IEnumerator txt() //텍스트xprtmxm
    {
        if (Cri >= 100)
            Cri = 100; 

        if ((int)catlv[0] == 0)
        { catlv[1] = 1; catlv[2] = 1; catlv[3] = 1; catlv[4] = 1;
            shl.transform.localScale = new Vector2(1f, 1f);
            catobj[0].transform.localScale = new Vector2(0.6f, 0.6f); }
        else if((int)catlv[0] == 1)
        { catlv[1] = 1.2f; catlv[2] = 1.2f; catlv[3] = 1.2f; catlv[4] = 1.2f;
            shl.transform.localScale = new Vector2(1.2f, 1.2f); 
            catobj[0].transform.localScale = new Vector2(0.8f, 0.8f); }
        else if ((int)catlv[0] == 2)
        { catlv[1] = 1.5f; catlv[2] = 1.5f; catlv[3] = 1.5f;
            shl.transform.localScale = new Vector2(1.7f, 1.7f); 
            catlv[4] = 1.5f; catobj[0].transform.localScale = new Vector2(1.1f, 1.1f); }
        else if ((int)catlv[0] == 3)
        { catlv[1] = 2; catlv[2] = 2f; catlv[3] = 2f; catlv[4] = 1.5f;
            shl.transform.localScale = new Vector2(2.2f, 2.2f);
            catobj[0].transform.localScale = new Vector2(1.5f, 1.5f); }

        for (int a = 0; a < mesh.Length; a++)
        {
            if (a == catint)
             mesh[a].SetActive(true); 
            else
             mesh[a].SetActive(false); 
        }
        yield return new WaitForSecondsRealtime(0.01f);
        for (int i = 0; i < 4; i++)
        {
            if (isbooming)
            {
                dmg = (10 + ((power + maindata[0]) * 2)) * (perpower / 100) * 5 * perpowerper * boomdmgper
                    * czefpower * catlv[1]* mainbuffdata[0];
            }
            else if (isatk)
            {
                dmg = (10 + ((power + maindata[0]) * 2)) * (perpower / 100) * 5 * perpowerper * boomdmgper
                    * czefpower * catlv[1] * mainbuffdata[0]*atkdmg;
            }
            else
            {
                dmg = (10 + ((power + maindata[0]) * 2)) * 
                    (perpower / 100) * perpowerper * czefpower * catlv[1]* mainbuffdata[0];
            }
            plui[0] = (speed + maindata[1]) * speedper * catlv[2] 
                * mspeedper* mainbuffdata[1]*slowint;
            plui[1] = maxShotDelayper * czefdel * catlv[3] * attackspeed * maindata[2] * mainbuffdata[1] / 100;
            plui[2] = shotspeed * mshotspeedper * shotspeedper / 100;
            plui[3] = (Cri + maindata[3]) * Criper* mainbuffdata[0];
            plui[4] = (1.5f * ((Cridmg + maindata[4]) / 100 * Cridmgper)) * czefcri;
            plui[5] = (defense + maindata[5]) * defenseper * catlv[4];
            plui[6] = (getper / 100) * maindata[6]*(1 + ((curstage - 1) * 0.1f)) 
                * pergetper * czefgetper* mainbuffdata[2];
            plui[7] = 15 * (healper / 100) * czeflife* maindata[7];
            plui[8] = Boomcooldownper * maindata[8];

            gm.coinText.text = string.Format("{0:n0}", Coin);
            gm.shopcointxt.text = string.Format("{0:n0}", Coin);
            gm.churooText.text = string.Format("{0:n0}", churoo);
            gm.soulText.text = string.Format("{0:n0}", soul);
            gm.defint.text = string.Format("{0:n1}", atkdmg);
            gm.ability[0].text = string.Format("{0:n0}", dmg);
            gm.ability[1].text = string.Format("{0:n0}", plui[0]);
            gm.ability[2].text = string.Format("{0:n0}", plui[1]);
            gm.ability[3].text = string.Format("{0:n0}", plui[2]);
            gm.ability[4].text = string.Format("{0:n0}", plui[3]);
            gm.ability[5].text = string.Format("{0:n0}", plui[4]);
            gm.ability[6].text = string.Format("{0:n0}", plui[5]);
            gm.ability[7].text = string.Format("{0:n0}", evasion);
            gm.ability[8].text = string.Format("{0:n0}", plui[6]);
            gm.ability[9].text = string.Format("{0:n0}", plui[7]);

            //HP
            gm.playerHP.text = string.Format("{0}", (int)life + "/" + (int)(maxlife * maxlifeper));
            RectTransform trans = gm.playermaxHPbar.GetComponent<RectTransform>();
            if ((maxlife * maxlifeper) > 250)
                trans.sizeDelta = new Vector2(625, 100);
            else
                trans.sizeDelta = new Vector2((maxlife * maxlifeper) * 2.5f, 100);
            float hpx = trans.sizeDelta.x;
            RectTransform transhp = gm.playerHPbar.GetComponent<RectTransform>();
            if (life <= 0)
            {
                if(maindata[9] <= 0)
                {
                    
                    transhp.sizeDelta = new Vector2(0, 100);
                    die();
                }
                else
                {
                    maindata[9]--;
                    life = maxlife/2;
                    StartCoroutine(ishitf());
                }
            }
            else
                transhp.sizeDelta = new Vector2(life / (maxlife * maxlifeper) * hpx, 100);
            



            if (life >= (maxlife * maxlifeper))
                life = (maxlife * maxlifeper);
            if (life <= 0)
                life = 0;
            yield return new WaitForSecondsRealtime(0.1f);
        } 
    }
    public IEnumerator ishitf()
    {
        ishit = true;
        shl.SetActive(true);
        yield return new WaitForSeconds(1f);
        shl.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        shl.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        shl.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        shl.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        shl.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        shl.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        shl.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        shl.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        shl.SetActive(false);
        ishit = false;
    }
        

    // 벽에 닿으면 행동하지마.
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            switch (collision.gameObject.name)
            {
                case "top":
                    isTouchtop = false;
                    break;
                case "bottom":
                    isTouchbottom = false;
                    break;
                case "left":
                    isTouchleft = false;
                    break;
                case "right":
                    isTouchright = false;
                    break;
            }
        }
    }
    
    public void interation()
    {
        if (gm.wpnearobj.gameObject.tag == "weapon")
        {
            if (gm.wpnearobj != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if( gm.invennum[i] == -1)
                    {
                        StartCoroutine(playerweaponinformation());
                        if (gm.box[4].activeSelf == true 
                            && gm.inven[12].activeSelf == false)
                            gm.box[4].SetActive(false);
                        if (gm.bt.uiexitbt[1].activeSelf == true)
                            gm.bt.only[2] = -1;
                        if (gm.bt.uiexitbt[2].activeSelf == true)
                            gm.bt.only[6] = -1;
                        if (!gm.theshop && !gm.theunkown && data.chapterindex != 0)
                            gm.StartCoroutine(gm.choice());
                        gm.nearint = -100;
                        gm.bt.only[7] = -1;
                        break;
                    }
                    else if (i == 8 && gm.invennum[8] != -1)
                    {
                        if (gm.box[4].activeSelf == true)
                            gm.btweapon[gm.nearint].SetActive(false);

                        gm.npctxtobj[4].SetActive(true);
                        gm.npctxt[4].text =
                            "아이템이 꽉 찼어!\n" + "아이템을 정리해야겠어!";
                        gm.bt.invenbt();
                        StartCoroutine(unknowneftxtobjf());
                    }
                }
            }
        }
        else if (gm.wpnearobj.gameObject.tag == "cat")
        {
            item item = gm.wpnearobj.GetComponent<item>();
            catint = item.velue;
            gm.invennum[9] = item.velue;
            catlv[0] = item.thiscoin;
            for (int i = 0; i < mesh.Length; i++)
            {
                if (i == catint)
                {
                    gm.wpnearobj.SetActive(false);
                    gm.wpnearobj.transform.position =
                        gm.inven[9].transform.position;
                    gm.uicat[i].SetActive(true);
                    for (int r = 0; r < mesh.Length; r++)
                    {
                        if (r != catint)
                        {
                            gm.uicat[r].SetActive(false);
                            if (r == (mesh.Length - 1))
                                StartCoroutine(txt());
                        }
                    }
                    if (gm.box[4].activeSelf == true)
                        gm.box[4].SetActive(false);
                    if (!gm.unknown[0].activeSelf && !gm.shop[0].activeSelf 
                        && data.chapterindex != 0)
                        gm.StartCoroutine(gm.choice());
                }
            }

        }

        if (!gm.unknown[2].activeSelf && !gm.shop[0].activeSelf)
        gm.information.SetActive(false);
    }
   public IEnumerator unknowneftxtobjf()
    {
        yield return new WaitForSecondsRealtime(3f);
        gm.npctxtobj[4].SetActive(false);
    }
    IEnumerator playerweaponinformation()
    {
        item item = gm.wpnearobj.GetComponent<item>();
        int weaponindex = item.velue;
        gm.btweapon[weaponindex].SetActive(true);
        attackspeed += item.wpattackspeed;
        Boomcooldown += item.wpBoomcooldown;
        Cri += (int)item.wpCri;
        Cridmg += (int)item.wpCridmg;
        getper += item.wpgetper;
        healper += (int)item.wphealper;
        maxlife += (int)item.wpmaxlife;
        if (item.velue == 20 && life < 51)
            life = 1;
        else
            life += item.wplife;
        
        power += (int)item.wppower;
        perpower += (int)item.wpperpower;
        speed += (int)item.wpspeed;
        shotspeed += (int)item.wpshotspeed;
        defense += (int)item.wpdefense;
        for (int a = 0; a < item.wphasset.Length; a++)
        {
            hasset[a] += item.wphasset[a];
        }

        for (int i = 0; gm.invennum[i] == -1 || i < 8; i++)
        {
            if(gm.invennum[i] == -1)
            {
                item invenitem = gm.btweapon[weaponindex].GetComponent<item>();
                invenitem.transform.position =  gm.inven[(i + 4)].transform.position;
                gm.invennum[i] = weaponindex;
                invenitem.weaponpos = i;

                if (gm.wpnearobj != null)
                {
                    if (curstage == 0)
                    {
                        gm.wpnearobj.SetActive(false);
                        gm.wpnearobj = null;
                        gm.nearobj = null;
                    }
                    else if (curstage > 0)
                        gm.wpnearobj.SetActive(false); 
                }
                break;
            }
        }
        if (gm.unknown[2].activeSelf == true && gm.bt.onlyczweapon != -1)
            gm.bt.onlyczweapon = -1;
        getinformation();
        yield return new WaitForSecondsRealtime(0.03f);
    }
    // 셋트효과
    public void getinformation()
    {
        for (int i = 11; i < gm.setinven.Length; i++)
            gm.setinven[i].SetActive(false);
        //강타셋

        switch (hasset[0])
        {
            case < 3:
                getset[0] = false;
                getset[1] = false;
                break;
            case 3:
            case <5:
                getset[0] = true;
                getset[1] = false;
                break;
            case >=5:
                getset[0] = true;
                getset[1] = true;
                break;
        }
        //행운
        switch (hasset[1])
        {
            case< 2:
                getset[2] = false;
                getset[3] = false;
                break;
            case 2:
            case 3:
                getset[2] = true;
                getset[3] = false;
                break;
            case >=4:
                getset[2] = true;
                getset[3] = true;
                break;
            
               
        }
        //강골
        switch (hasset[2])
        {
            case < 3:
                getset[4] = false;
                getset[5] = false;
                break;
            case 3:
            case 4:
                getset[4] = true;
                getset[5] = false;
                break;
            case >=5:
                getset[4] = true;
                getset[5] = true;
                break;
        }
        //신속
        switch (hasset[3])
        {
            case <3:
                getset[6] = false;
                getset[7] = false;
                break;
            case 3:
            case 4:
                getset[6] = true;
                getset[7] = false;
                break;
            case >=5:
                getset[6] = true;
                getset[7] = true;
                break;
        }
        //관통
        switch (hasset[4])
        {
            case <3:
                getset[8] = false;
                getset[9] = false;
                break;
            case 3:
            case 4:
                getset[8] = true;
                getset[9] = false;
                break;
            case >=5:
                getset[8] = true;
                getset[9] = true;
                break;
        }
        //회피
        switch (hasset[5])
        {
            case <2:
                getset[10] = false;
                getset[11] = false;
                break;
            case 2:
            case <4:
                getset[10] = true;
                getset[11] = false;
                break;
            case >=4:
                getset[10] = true;
                getset[11] = true;
                break;
        }
        //맷집
        switch (hasset[6])
        {
            case <3:
                getset[12] = false;
                getset[13] = false;
                break;
            case 3:
            case 4:
                getset[12] = true;
                getset[13] = false;
                break;
            case >=5:
                getset[12] = true;
                getset[13] = true;
                break;
        }
        //표피
        switch (hasset[7])
        {
            case <2:
                getset[14] = false;
                getset[15] = false;
                break;
            case 2:
            case 3:
                getset[14] = true;
                getset[15] = false;
                break;
            case >=4:
                getset[14] = true;
                getset[15] = true;
                break;
        }
        //쾌속
        switch (hasset[8])
        {
            case <3:
                getset[16] = false;
                getset[17] = false;
                break;
            case 3:
            case 4:
                getset[16] = true;
                getset[17] = false;
                break;
            case >=5:
                getset[16] = true;
                getset[17] = true;
                break;              
        }
        //과욕
        switch (hasset[9])
        {
            case <3:
                getset[18] = false;
                getset[19] = false;
                break;
            case 3:
            case 4:
                getset[18] = true;
                getset[19] = false;
                break;
            case >=5:
                getset[18] = true;
                getset[19] = true;
                break;
        }
        //지혜
        switch (hasset[10])
        {
            case <2:
                getset[21] = false;
                getset[20] = false;
                break;
            case 2:
            case 3:
                getset[20] = true;
                getset[21] = false;
                break;
            case >=4:
                getset[20] = true;
                getset[21] = true;
                break;
        }
        setinformation();
    }

    public void setinformation()
    {
        //강타셋
        switch (getset[0])
        {
            case true:
                Image image = gm.set[0].GetComponent<Image>();
                Image image1 =  gm.setinven[11].GetComponent<Image>();
                switch (getset[1])
                {
                    case true:
                        Cridmgper = 3;
                        image.color = Color.yellow;
                        gm.setinvenui[0].color = new Color(1, 1, 0, 1f);
                        image1.color = new Color(1, 1, 0, 1f);
                        break;
                    case false:
                        Cridmgper = 2;
                        image.color = Color.white;
                        gm.setinvenui[0].color = new Color(1, 1, 1, 1f);
                        image1.color = new Color(1, 1, 1, 1f);
                        
                        break;
                }
                break;
            case false:
                Image image2 = gm.setinven[11].GetComponent<Image>();
                gm.setinvenui[0].color = new Color(1, 1, 1, 0.6f);
                Cridmgper = 1;
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //행운
        switch (getset[2])
        {
            case true:
                Image image = gm.set[1].GetComponent<Image>();
                Image image1 = gm.setinven[12].GetComponent<Image>();
                switch (getset[3])
                {
                    case true:
                        Criper = 2f;
                        image.color = Color.yellow;
                        gm.setinvenui[1].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 0, 1f);
                        break;
                    case false:
                        Criper = 1.5f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[1].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                gm.setinvenui[1].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[12].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                Criper = 1;
                break;
        }
        //강골
        switch (getset[4])
        {
            case true:
                Image image = gm.set[2].GetComponent<Image>();
                Image image1 = gm.setinven[13].GetComponent<Image>();
                switch (getset[5])
                {
                    case true:
                        perpowerper = 1.8f;
                        image.color = Color.yellow;
                        image1.color = new Color(1, 1, 0, 1f);
                        gm.setinvenui[2].color = new Color(1, 1, 0, 1);
                        break;
                    case false:
                        perpowerper = 1.3f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[2].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                perpowerper = 1;
                gm.setinvenui[2].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[13].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //신속
        switch (getset[6])
        {
            case true:
                Image image1 = gm.setinven[14].GetComponent<Image>();
                Image image = gm.set[3].GetComponent<Image>();
                switch (getset[7])
                {
                    case true:
                        maxShotDelayper = 2f;
                        image.color = Color.yellow;
                        gm.setinvenui[3].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 0, 1f);
                        break;
                    case false:
                        maxShotDelayper = 1.3f;
                        image.color = Color.white;
                        gm.setinvenui[3].color = new Color(1, 1, 1, 1);
                        image1.color = new Color(1, 1, 1, 1f);

                        break;
                }
                break;
            case false:
                maxShotDelayper = 1;
                gm.setinvenui[3].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[14].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //관통
        switch (getset[8])
        {
            case true:
                Image image1 = gm.setinven[15].GetComponent<Image>();
                Image image = gm.set[4].GetComponent<Image>();
                switch (getset[9])
                {
                    case true:
                        maxShot2Delay =2;
                        image.color = Color.yellow;
                        gm.setinvenui[4].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 0, 1f);
                        break;
                    case false:
                        maxShot2Delay = 4;
                        image.color = Color.white;
                        gm.setinvenui[4].color = new Color(1, 1, 1, 1);
                        image1.color = new Color(1, 1, 1, 1f);

                        break;
                }
                break;
            case false:
                maxShot2Delay = 6;
                Image image2 = gm.setinven[15].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                gm.setinvenui[4].color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //살기감지
        switch (getset[10])
        {
            case true:
                Image image = gm.set[5].GetComponent<Image>();
                Image image1 = gm.setinven[16].GetComponent<Image>();
                switch (getset[11])
                {
                    case true:
                        evasion = 23;
                        image.color = Color.yellow;
                        gm.setinvenui[5].color = new Color(1, 1, 0, 1);                
                        image1.color = new Color(1, 1, 0, 1f);

                        break;
                    case false:
                        evasion = 5;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[5].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                evasion = 0;
                gm.setinvenui[5].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[16].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //맷집
        switch (getset[12])
        {
            case true:
                Image image = gm.set[6].GetComponent<Image>();
                Image image1 = gm.setinven[17].GetComponent<Image>();

                switch (getset[13])
                {
                    case true:
                        maxlifeper = 2.5f;
                        image.color = Color.yellow;
                        image1.color = new Color(1, 1, 0, 1f);

                        gm.setinvenui[6].color = new Color(1, 1, 0, 1);
                        break;
                    case false:
                        maxlifeper = 1.5f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);

                        gm.setinvenui[6].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                maxlifeper = 1;
                gm.setinvenui[6].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[17].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //표피
        switch (getset[14])
        {
            case true:
                Image image = gm.set[7].GetComponent<Image>();
                Image image1 = gm.setinven[18].GetComponent<Image>();

                switch (getset[15])
                {
                    case true:
                        defenseper = 1.8f;
                        image.color = Color.yellow;
                        gm.setinvenui[7].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 0, 1f);
                        break;
                    case false:
                        defenseper = 1.3f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[7].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                defenseper = 1;
                gm.setinvenui[7].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[18].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f); 
                break;
        }
        //쾌속
        switch (getset[16])
        {
            case true:
                Image image = gm.set[8].GetComponent<Image>();
                Image image1 = gm.setinven[19].GetComponent<Image>();
                switch (getset[17])
                {
                    case true:
                        speedper = 1.5f;
                        shotspeedper = 2f;
                        image.color = Color.yellow;
                        image1.color = new Color(1, 1, 0, 1f);
                        gm.setinvenui[8].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 1, 1f);
                        break;
                    case false:
                        speedper = 1.2f;
                        shotspeedper = 1.5f;
                        image.color = Color.white;
                        gm.setinvenui[8].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                speedper = 1;
                shotspeedper = 1;
                gm.setinvenui[8].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[19].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //과욕
        switch (getset[18])
        {
            case true:
                Image image = gm.set[9].GetComponent<Image>();
                Image image1 = gm.setinven[20].GetComponent<Image>();
                switch (getset[19])
                {
                    case true:
                        pergetper = 2.5f;
                        itemtargeting = true;
                        mspeedper = 0.6f;
                        mshotspeedper = 0.6f;
                        gm.setinvenui[9].color = new Color(1, 1, 0, 1);
                        image1.color = new Color(1, 1, 0, 1f);
                        image.color = Color.yellow;
                       
                        break;
                    case false:
                        pergetper = 1.5f;
                        itemtargeting = false;
                        mspeedper = 0.8f;
                        mshotspeedper = 0.8f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[9].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                pergetper = 1;
                itemtargeting = false;
                mspeedper = 1;
                mshotspeedper = 1;
                gm.setinvenui[9].color = new Color(1, 1, 1, 0.6f);
                Image image2 = gm.setinven[20].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                break;
        }
        //지혜
        switch (getset[20])
        {
            case true:
                Image image = gm.set[10].GetComponent<Image>();
                Image image1 = gm.setinven[21].GetComponent<Image>();
                switch (getset[21])
                {
                    case true:
                        Boomcooldownper = 0.5f;
                        image.color = Color.yellow;
                        image1.color = new Color(1, 1, 0, 1f);
                        gm.setinvenui[10].color = new Color(1, 1, 0, 1);
                        break;
                    case false:
                        Boomcooldownper = 0.8f;
                        image.color = Color.white;
                        image1.color = new Color(1, 1, 1, 1f);
                        gm.setinvenui[10].color = new Color(1, 1, 1, 1);
                        break;
                }
                break;
            case false:
                Boomcooldownper = 1;
                Image image2 = gm.setinven[21].GetComponent<Image>();
                image2.color = new Color(1, 1, 1, 0.6f);
                gm.setinvenui[10].color = new Color(1, 1, 1, 0.6f);
                break;

        }
        //애착인형
        //분노
        //그림자
        StartCoroutine(order());
    }
    public  IEnumerator order()
    {//각인 위치
        for (int i = 0; i < getset.Length; i += 2)
        {
            if (getset[i] == false && gm.set[(i / 2)].activeSelf == true)
            {
                for (int r = 0; r < 10; r++)
                {
                    uimanager ui1 = gm.set[(i / 2)].GetComponent<uimanager>();
                    if (gm.setuiint[r] == ui1.uiint)
                    {
                        gm.set[(i / 2)].SetActive(false);
                        gm.setuiint[r] = -1;
                        StartCoroutine(setrepos());
                        break;
                    }
                }
            }
            else if (getset[i] == true && gm.set[(i / 2)].activeSelf == false)
            {
                for (int a = 0; a < gm.setuipos.Length; a++)
                {
                    if (gm.setuiint[a] == -1)
                    {
                        gm.set[(i / 2)].transform.position = gm.setuipos[a].transform.position;
                        gm.set[(i / 2)].SetActive(true);
                        uimanager ui = gm.set[(i / 2)].GetComponent<uimanager>();
                        gm.setuiint[a] = ui.uiint;
                        break;
                    }
                }
            }
        }
        //인벤각인 위치배치
        for (int s = 0; s < hasset.Length; s++)
        {
            if (hasset[s] <= 0)
            {
                uimanager ui = gm.setinven[s].GetComponent<uimanager>();
                for (int posint = 0; posint < gm.setinvenposint.Length; posint++)
                {
                    if (gm.setinvenposint[posint] == ui.uiint)
                    {
                        gm.setinven[s].SetActive(false);
                        gm.setinvenposint[posint] = -1;
                    }
                }
            }
            if (hasset[s] > 0)
            {
                uimanager ui = gm.setinven[s].GetComponent<uimanager>();
                for (int posint = 0; posint < gm.setinvenposint.Length; posint++)
                {
                    if (gm.setinvenposint[posint] == -1 && gm.setinvenposint[0] != ui.uiint
                        && gm.setinvenposint[1] != ui.uiint && gm.setinvenposint[2] != ui.uiint
                        && gm.setinvenposint[3] != ui.uiint && gm.setinvenposint[4] != ui.uiint
                        && gm.setinvenposint[5] != ui.uiint && gm.setinvenposint[6] != ui.uiint
                        && gm.setinvenposint[7] != ui.uiint && gm.setinvenposint[8] != ui.uiint
                        && gm.setinvenposint[9] != ui.uiint && gm.setinvenposint[10] != ui.uiint
                        && gm.setinvenposint[11] != ui.uiint && gm.setinvenposint[12] != ui.uiint
                        && gm.setinvenposint[13] != ui.uiint && gm.setinvenposint[14] != ui.uiint)
                        gm.setinvenposint[posint] = ui.uiint;
                }
                
                for (int v = 0; v < hasset.Length; v++)
                {
                    if (hasset[v] > 0 && hasset[s] < hasset[v])
                    {
                        uimanager ui1 = gm.setinven[v].GetComponent<uimanager>();
                        for (int pos = 0; pos < (gm.setinvenposint.Length-1) ; pos++)
                        {
                            if (gm.setinvenposint[pos] == ui1.uiint && s!=v)
                            {
                                gm.setinvenposint[(gm.setinvenposint.Length-1)]
                                    = gm.setinvenposint[pos];
                                gm.setinvenposint[pos] = ui.uiint;
                                for (int pos1 = 0; pos1 < gm.setinvenposint.Length - 1; pos1++)
                                {
                                    if (gm.setinvenposint[pos1] == ui.uiint && pos != pos1)
                                    {
                                        gm.setinvenposint[pos1] = gm.setinvenposint[gm.setinvenposint.Length - 1];
                                        gm.setinvenposint[gm.setinvenposint.Length - 1] = -1;
                                    }
                                }
                            }

                        }
                    }
                    gm.setinvenint[v].text = string.Format("{0:n0}", hasset[v]);
                }
            }
        }
        Debug.Log("?");
        yield return new WaitForSecondsRealtime(0.04f);
    }
    IEnumerator setrepos()
    {
        for (int repos = 0; repos < 9; repos++)
        {
            if (gm.setuiint[repos+1] != -1)
            {
                gm.setuiint[repos] = gm.setuiint[repos + 1];
                gm.setuiint[repos + 1] = -1;
                gm.set[gm.setuiint[repos]].transform.position =
                    gm.setuipos[repos].transform.position;
            }
        }
        yield return new WaitForSecondsRealtime(0.1f);
    }
}