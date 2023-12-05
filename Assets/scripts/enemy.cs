using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public string enemyname;
    public int enemynum;
    Rigidbody2D rg;
    
    public GameObject chil;

    public float speed;
    public float HP;
    public float maxHP;
    public float dmg;
    public float hitdmg;
   
    public float maxShotDelay;
    public float curShotDelay;
    public float shotspeed1;

    public Transform bulletpoint, bulletpoint1;
    public GameObject bulletobjtA;
    
    public GameObject itemcoin, itemchuroo;

    public GameObject player, playerhitpoint, playerbullet;
    public ObjectManager objectmanager;
    public GameManager gm;
    public player pl;

    public SpriteRenderer bosspriteRenderer;
    public CapsuleCollider2D box;
    public Animator dieanim;


    public int patternindex, curpatterncount;
    public int[] maxpatterncount;
    public Text bossHP;
    public GameObject[] bossHPgroup;
    public RectTransform bossHPbar, bossrmaxHPbar;
    public Animator bossHPbaram, bossimam, caman;
    public string titletext, bosstext;
    public bool bossbarstop = false;
    public bool isboss;
    public GameObject randmgtxt, atkrange, bossef;
    public bool isdie;
    public bool velzero = false;
    bool bossdie = false;
    public int isdmg = 0;
    public int bossint;
    public int[] bossatkrange;
    public bool range;
    public bool bossbullet;
    public bool noatkzon;
    //boss 무기
    public bool nodmg;
    public string[] MBB1;
    public GameObject bossweaponpos;
    public Sprite[] bossweapon;
    public Vector2[] atkpos;
    public float rot;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        if(chil !=null)
        {
            dieanim = chil.GetComponent<Animator>();
            box = chil.GetComponent<CapsuleCollider2D>();
        }
        else
        {
            dieanim = GetComponent<Animator>();
            box = GetComponent<CapsuleCollider2D>();
        }
    }

    void OnEnable()
    {
       
            switch (enemyname)
            {
                case "10":
                    HP = maxHP;
                    box.enabled = false;
                    StartCoroutine(stop());
                isdie = false;
                bossdie = false;
                  break;

            case "1":
                onenable();
                break;

            case "2":
                onenable();
                break;
            case "3":
                onenable();
                break;
            case "4":
                onenable();
                break;

            case "5":
                onenable();
                break;
            case "6":
                onenable();
                 break;
            }
    }
    void onenable()
    {
       
        HP = maxHP;
        isdie = false;
        box.enabled = true;

        if (enemynum == 26)
            StartCoroutine(enemynum26());
        else if (enemynum == 21)
            StartCoroutine(enemynum21());
        else if (enemynum == 22)
            StartCoroutine(enemynum22());
        else if (enemynum == 25)
            StartCoroutine(enemynum25());
    }
    // enemy move
    IEnumerator enemynum21()
    {
        yield return new WaitForSeconds(2f);
        Vector2 dirVec = playerhitpoint.transform.position - transform.position;
        Vector2 ranVec = new Vector2(Random.Range(-3,3), Random.Range(-3, 3));
        Vector2 dir = dirVec + ranVec;
        if(HP>0)
            rg.velocity = dir.normalized * speed * 2;

    }
    IEnumerator enemynum22()
    {
        yield return new WaitForSeconds(2f);
        Vector2 dieVec = playerhitpoint.transform.position - transform.position;
        if (HP > 0)
            rg.velocity = dieVec.normalized * speed * 2;
        yield return new WaitForSeconds(2f);
        Vector2 dieVec1 = playerhitpoint.transform.position - transform.position;
        if (HP > 0)
            rg.velocity = dieVec1.normalized * speed * 3;
        StartCoroutine(enemynum22());
    }
    IEnumerator enemynum25()
    {
        yield return new WaitForSeconds(2f);
        Vector2 dieVec1 = playerhitpoint.transform.position - transform.position;
        if (HP > 0)
            rg.velocity = dieVec1.normalized * 1;
    }
    IEnumerator enemynum26()
    {
        if (HP > 0)
            dieanim.SetTrigger("atkoff");
        yield return new WaitForSeconds(3f);
       
        if(HP>0)
        {
            rg.velocity = new Vector2(0, 0);
            dieanim.SetTrigger("atk");
        }
            
        yield return new WaitForSeconds(2f);
        if (HP > 0)
        {
            Vector2 dieVec = playerhitpoint.transform.position - transform.position;
            rg.velocity = dieVec.normalized * speed *10;
        }
        yield return new WaitForSeconds(2f);
    }

    IEnumerator stop()
    {
        if(bossint == 7)
            dieanim.SetTrigger("start");
        yield return new WaitForSeconds(3f);
        isboss = true;
        bossbarstop = true;
        bossHPgroup[0].SetActive(true);
        bossHPgroup[1].SetActive(true);
        gm.bosstext[0].text = string.Format(titletext);
        gm.bosstext[1].text = string.Format(bosstext);

        bossHPbaram.SetTrigger("boss");
        bossimam.SetTrigger("boss");
        caman.SetTrigger("boss");
        bossHP.text = string.Format("{0}", HP + "/" + maxHP);
        bossHPbar.sizeDelta = new Vector2(500, 100);

        rg.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Think());
        StartCoroutine(pattern());
    }
    IEnumerator pattern()
    {
        yield return new WaitForSeconds(2f);
        if(bossint==4)
            while (HP > 0)
            {
                dieanim.SetTrigger("ack");
                for (int i = 0; i < bossatkrange.Length; i++)
                    bossatkrange[i] = -1;
                int min = (HP / maxHP) > 0.7f? 1 : 3;
                int max = (HP / maxHP)>0.5f? 3 : 4;
                int ran = Random.Range(min, max);
                float sp1 = (HP / maxHP)>0.4f ? 0.5f : 0.2f;
                float sp2 = (HP / maxHP) >0.7f ? 1.5f : 1f;
                yield return new WaitForSeconds(0.5f);
                for(int i=0;i< ran;)
                {
                    int posran = Random.Range(0, 5);
                    if (bossatkrange[0] != posran && bossatkrange[1] != posran
                        && bossatkrange[2] != posran && bossatkrange[3] != posran
                        && bossatkrange[4] != posran)
                    {
                        GameObject atkrange = gm.objectmanager.MakeObj("Brange1");
                        atkrange.transform.localScale = new Vector2(30, 2);
                        atkrange.transform.position =
                            new Vector2(0, gm.spawn1points[posran].position.y);
                        bossatkrange[i] = posran;
                        i++; ;
                    }
                    yield return new WaitForFixedUpdate();
                    //범위 사라지는 건 애니효과
                }
                yield return new WaitForSeconds(0.3f);
                for (int i = 0; i < bossatkrange.Length && HP > 0; i++)
                {
                    if (bossatkrange[i] !=-1 && HP > 0)
                    {
                        GameObject bossef = objectmanager.MakeObj("B4bullet");
                        bossef.transform.position = gm.spawn1points[bossatkrange[i]].position;
                        Rigidbody2D rigid = bossef.GetComponent<Rigidbody2D>();
                        enemy enemyLogic = bossef.GetComponent<enemy>();


                        enemyLogic.player = player;
                        enemyLogic.playerhitpoint = playerhitpoint;
                        enemyLogic.gm = gm;
                        enemyLogic.objectmanager = objectmanager;
                        enemyLogic.bossHP = gm.gamebossHP;
                        enemyLogic.bossrmaxHPbar = gm.gamebossrmaxHPbar;
                        enemyLogic.bossHPbar = gm.gamebossHPbar;
                        enemyLogic.bossHPbaram = gm.gamebossHPbaram;
                        enemyLogic.randmgtxt = gm.dmgtxt;
                        enemyLogic.bossbullet = true;
                        enemyLogic.bossHPgroup[0] = gm.managerbossHPgroup[0];
                        enemyLogic.bossHPgroup[1] = gm.managerbossHPgroup[1];
                        enemyLogic.velzero = false;
                        rigid.velocity = new Vector2(enemyLogic.speed * (-1), 0);
                    }
                }
                yield return new WaitForSeconds(sp1*sp2);

            }
        else if (bossint == 1)
            while (HP > 0)
            {
                dieanim.SetTrigger("ack");
                int ranwepon = Random.Range(0, bossweapon.Length-1);
                SpriteRenderer sp = bossweaponpos.GetComponent<SpriteRenderer>();
                sp.sprite = bossweapon[ranwepon];
                if (ranwepon < 2)
                    bossweaponpos.transform.localScale = new Vector2(0.66f, 0.66f);
                else
                    bossweaponpos.transform.localScale = new Vector2(1.2f, 1.2f);
                
                int min = (HP / maxHP) > 0.7f ? 1 : 2;
                int max = (HP / maxHP) > 0.4f ? 0 : 1;
                int ran = min+ max;
                float sp1 = (HP / maxHP) > 0.7f ? 1 : 0.8f;
                float sp2 = (HP / maxHP) > 0.4f ? 0 : 0.2f;
                yield return new WaitForSeconds(0.98f);
                if(HP >0)
                {
                    GameObject bossbullet1 = objectmanager.MakeObj(MBB1[ranwepon]);
                    bossbullet1.transform.position = bulletpoint.transform.position;
                    Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();
                    Vector2 dieVec1 = playerhitpoint.transform.position - transform.position;
                    Vector2 ranVec1 = new Vector2(Random.Range(0f, 2f), Random.Range(-2f, 2f));
                    dieVec1 += ranVec1;
                    rigid1.AddForce(dieVec1.normalized * shotspeed1 * 2, ForceMode2D.Impulse);
                    for (int i = 1; i < ran && HP > 0; i++)
                    {
                        int ranweapon = Random.Range(0, bossweapon.Length);
                        GameObject bossbullet = objectmanager.MakeObj(MBB1[ranweapon]);
                        bossbullet.transform.position = bulletpoint.transform.position;

                        Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();
                        Vector2 dieVec = playerhitpoint.transform.position - transform.position;
                        Vector2 ranVec = new Vector2(Random.Range(0f, 2f), Random.Range(-5f, 5f));
                        dieVec += ranVec;
                        rigid.AddForce(dieVec.normalized * shotspeed1 * 2, ForceMode2D.Impulse);
                    }
                }
                yield return new WaitForSeconds(sp1- sp2);
            }
        else if (bossint == 2)
            while (HP > 0)
            {
                if ((HP/maxHP)>0.7f)
                {
                    dieanim.SetTrigger("ack");
                    yield return new WaitForSeconds(0.88f);
                    GameObject bossbullet1 = objectmanager.MakeObj("MBB2");
                    enemybullet bul = bossbullet1.GetComponent<enemybullet>();
                    bul.dmg = 25;
                    bul.bulletint = 1;
                    bossbullet1.transform.localScale = new Vector2(4, 4);
                    bossbullet1.transform.position = bulletpoint.transform.position;
                    Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();
                    Vector2 dieVec1 = playerhitpoint.transform.position - transform.position;
                    Vector2 ranVec1 = new Vector2(Random.Range(0f, 2f), Random.Range(-2f, 2f));
                    dieVec1 += ranVec1;
                    rigid1.AddForce(dieVec1.normalized * shotspeed1 * 3, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(1f);
                }
               else
                {
                    dieanim.SetTrigger("ack1");
                    int ran = Random.Range(0, 2);
                    GameObject atkrange = gm.objectmanager.MakeObj("Brange1");
                  
                    atkrange.transform.localScale = new Vector2(30, 11);
                    atkrange.transform.position =
                        new Vector2(0, gm.spawn1points[ran*4].position.y);
                    for(int i =0;i<5;i++)
                    {
                        box.size = new Vector2(0.97f + (0.97f * (i + 1)), 1.96f + (1.96f * (i + 1)));
                        yield return new WaitForSeconds(0.1f);
                    }
                   
                    //범위 표시
                    yield return new WaitForSeconds(0.86f);
                    StartCoroutine(boxsm());
                    if(HP > 0)
                    {
                        GameObject bossbullet1 = objectmanager.MakeObj("MBB2");
                        enemybullet bul = bossbullet1.GetComponent<enemybullet>();
                        bul.dmg = 40;
                        bul.bulletint = 2;
                        Rigidbody2D rigid = bossbullet1.GetComponent<Rigidbody2D>();
                        bossbullet1.transform.localScale = new Vector2(22, 22);
                        bossbullet1.transform.position
                            = new Vector2(bulletpoint.transform.position.x,
                            gm.spawn1points[ran * 4].transform.position.y);
                        rigid.velocity = new Vector2(-3, 0);
                        SpriteRenderer sp = bossbullet1.GetComponent<SpriteRenderer>();
                        for (int i = 0; i < 3; i++)
                        {
                            sp.color = new Color(1, 1, 1, 1 - (i * 0.3f));
                            yield return new WaitForSeconds(1);
                        }
                        bossbullet1.SetActive(false);
                        sp.color = new Color(1, 1, 1, 1);
                        rigid.velocity = new Vector2(0, 0);
                        yield return new WaitForSeconds(1f);
                    }
                }
            }
        else if (bossint == 3)
            while (HP > 0)
            {
                dieanim.SetTrigger("ack");
                for (int i = 0; i < atkpos.Length; i++)
                    atkpos[i] = new Vector2(-100, -100);
                int min = (HP / maxHP) > 0.7f ? 1 : 2;
                int max = (HP / maxHP) > 0.4f ? 1 : 2;
                int ran = Random.Range(min, min + max);
                yield return new WaitForSeconds(1f);
                for (int i =0; i< ran;i++)
                {
                    float x = Random.Range(-8, 7.2f);
                    float y = Random.Range(-3.1f, 2.6f);

                    GameObject atkrange = gm.objectmanager.MakeObj("Brange2");

                    atkrange.transform.localScale = new Vector2(8, 8);
                    atkrange.transform.position = new Vector2(x, y);
                    atkpos[i] = new Vector2(x, y);
                }
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < ran; i++)
                {
                    if (atkpos[i].x > -10)
                    {
                        GameObject bossbullet1 = objectmanager.MakeObj("MBB3");
                        enemybullet bul = bossbullet1.GetComponent<enemybullet>();
                        bul.dmg = 10;
                        bul.bulletint = 3;
                        Rigidbody2D rigid = bossbullet1.GetComponent<Rigidbody2D>();
                        bossbullet1.transform.localScale = new Vector2(1, 1);
                        bossbullet1.transform.position
                            = new Vector2(atkpos[i].x,
                            atkpos[i].y +8);
                        rigid.velocity = new Vector2(0, -8);
                    }
                }
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < ran; i++)
                {
                    GameObject bossbullet1 = objectmanager.MakeObj("poison");
                    Rigidbody2D rigid = bossbullet1.GetComponent<Rigidbody2D>();
                    bossbullet1.transform.localScale = new Vector2(8, 8);
                    bossbullet1.transform.position = new Vector2(atkpos[i].x,
                        atkpos[i].y );
                    rigid.velocity = new Vector2(0, 0);
                }
            }
        else if(bossint == 5)
            while (HP > 0)
            {
                dieanim.SetTrigger("ack");
                int min = (HP / maxHP) > 0.7f ? 0 : 1;
                int max = (HP / maxHP) > 0.4f ? 0 : 2;
                int ran = Random.Range(1+min, 1+min + max);
                int ranspeed = Random.Range(8, 12);
                yield return new WaitForSeconds(1f);
                if (HP > 0)
                {
                    GameObject bossbullet1 = objectmanager.MakeObj(MBB1[0]);
                    bossbullet1.transform.position = bulletpoint.transform.position;
                    bossbullet1.transform.localScale = new Vector2(1, Random.Range(1f, 3f));
                    Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();
                    Vector2 dieVec1 = playerhitpoint.transform.position - transform.position;
                    rigid1.AddForce(dieVec1.normalized * shotspeed1 *3, ForceMode2D.Impulse);
                    for (int i = 0; i < ran ; i++)
                    {
                        GameObject bossbullet = objectmanager.MakeObj(MBB1[0]);
                        Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();

                        bossbullet.transform.position = bulletpoint1.transform.position;
                        bossbullet.transform.localScale = new Vector2(1, Random.Range(1f, 2f));
                        Vector2 dieVec = playerhitpoint.transform.position - transform.position;
                        Vector2 ranVec = new Vector2(Random.Range(0f, 2f), Random.Range(-5f, 5f));
                        dieVec += ranVec;
                        rigid.AddForce(dieVec.normalized * ranspeed, ForceMode2D.Impulse);
                    }
                }
                yield return new WaitForSeconds(2.5f);
                
            }
        else if (bossint == 6)
            while (HP > 0)
            {
                dieanim.SetTrigger("ack");
                int min = (HP / maxHP) > 0.7f ? 2 : 4;
                int max = (HP / maxHP) > 0.4f ? 1 : 6;
                int ran = Random.Range(min, min + max);
                int ranspeed = Random.Range(8, 12);
                yield return new WaitForSeconds(1.5f);
                if (HP > 0)
                {
                    for (int i = 0; i < 6&& HP > 0; i++)
                    {
                        GameObject bossbullet = objectmanager.MakeObj("bulletenemyA");
                        Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();
                        bossbullet.transform.position = bulletpoint1.transform.position;
                        bossbullet.transform.rotation = Quaternion.Euler(0, 0, 90);
                        bossbullet.transform.localScale = new Vector2(2, 2);
                        rigid.AddForce(Vector2.up * ranspeed, ForceMode2D.Impulse);

                        GameObject bossbullet1 = objectmanager.MakeObj("bulletenemyA");
                        Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();
                        bossbullet1.transform.position = bulletpoint1.transform.position;
                        bossbullet1.transform.localScale = new Vector2(2, 2);
                        bossbullet.transform.rotation = Quaternion.Euler(0, 0, -90);
                        rigid1.AddForce(Vector2.down * ranspeed, ForceMode2D.Impulse);

                        yield return new WaitForSeconds(0.1f);
                    }
                    for (int i = 0; i < ran && HP > 0; i++)
                    {
                        int enemypoint = Random.Range(0, 9);

                        GameObject enemy = objectmanager.MakeObj("4");

                        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
                        enemy enemyLogic = enemy.GetComponent<enemy>();

                        if (enemyLogic.chil != null)
                            enemyLogic.chil.SetActive(true);
                        enemyLogic.player = player;
                        enemyLogic.playerhitpoint = playerhitpoint;
                        enemyLogic.gm = gm;
                        enemyLogic.pl = pl;
                        enemyLogic.objectmanager = objectmanager;
                        enemyLogic.velzero = false;

                      

                        enemy.transform.position = gm.spawn1points[enemypoint].position;

                        if (enemypoint == 5 || enemypoint == 6)
                        {
                            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -0.5f);

                        }
                        else if (enemypoint == 7 || enemypoint == 8)
                        {
                            rigid.velocity = new Vector2(enemyLogic.speed * (-1), 0.5f);
                        }
                        else if (!enemyLogic.range)
                        {
                            rigid.velocity = new Vector2(enemyLogic.speed * (-1), 0);
                        }
                        yield return new WaitForSeconds(0.1f);
                    }

                }
                yield return new WaitForSeconds(5f);

            }
        else if (bossint == 7)
            while (HP > 0)
            {
                if((HP / maxHP) > 0.5f)
                {
                    yield return new WaitForSeconds(5f);
                    dieanim.SetTrigger("ack");
                    int min = (HP / maxHP) > 0.7f ? 2 : 4;
                    int max = (HP / maxHP) > 0.4f ? 1 : 6;
                    int ran = Random.Range(min, min + max);
                    int ranspeed = Random.Range(8, 12);
                    yield return new WaitForSeconds(0.5f);
                    if (HP > 0)
                    {
                       GameObject bossbullet1 = objectmanager.MakeObj("bulletenemybace");
                        Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();

                        bossbullet1.transform.localScale = new Vector2(0, 0);


                        bossbullet1.transform.position = 
                            new Vector2(bulletpoint.transform.position.x-1,
                            bulletpoint.transform.position.y+1);
                        yield return new WaitForSeconds(0.5f);
                        for (int i = 0; i < 6 && HP > 0; i++)
                        {
                            int roundnumaB = 20;
                            int roundnumaA = 15;
                            int roundnuma = i % 2 == 0 ? roundnumaA : roundnumaB;

                            for (int index = 0; index < roundnuma; index++)
                            {
                                GameObject bulletRR = objectmanager.MakeObj("bulletenemybace");
                                bulletRR.transform.position = bulletpoint1.transform.position;
                                bulletRR.transform.rotation = Quaternion.identity;
                                bulletRR.transform.localScale = new Vector2(0.2f, 0.5f);
                                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                                Vector2 dieVecRR = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundnuma)
                                                             , Mathf.Sin(Mathf.PI * 2 * index / roundnuma));
                                rigidRR.AddForce(dieVecRR.normalized * shotspeed1, ForceMode2D.Impulse);

                                Vector3 rotVec = Vector3.forward * 360 * index / roundnuma + Vector3.forward * 90;
                                bulletRR.transform.Rotate(rotVec);
                            }

                            yield return new WaitForSeconds(0.1f);

                            GameObject bossbullet2 = objectmanager.MakeObj("bulletenemybace");
                            enemybullet bullet5 = bossbullet2.GetComponent<enemybullet>();
                            bullet5.target = playerhitpoint.transform;
                            bossbullet2.transform.position = bulletpoint.transform.position;
                            bossbullet2.transform.localScale = new Vector2(0.5f, 0.5f);
                            Rigidbody2D rigid = bossbullet2.GetComponent<Rigidbody2D>();
                            Vector3 dieVec = playerhitpoint.transform.position - (bulletpoint.transform.position);
                            rigid.AddForce(dieVec.normalized * shotspeed1 * 2, ForceMode2D.Impulse);


                            bossbullet1.transform.localScale = new Vector2( 2*i/5, 2*i/5);
                            yield return new WaitForSeconds(0.1f);
                        }
                        Vector3 dieVec1 = playerhitpoint.transform.position - (bulletpoint.transform.position);
                        rigid1.AddForce(dieVec1.normalized * shotspeed1, ForceMode2D.Impulse);

                        if ((HP / maxHP) <= 0.5f)
                        {
                            dieanim.SetTrigger("2page");
                            box.enabled = false;
                        }
                    }
                }
                else
                {
                    box.enabled = true;
                    yield return new WaitForSeconds(5f);
                    dieanim.SetTrigger("2atk");
                    yield return new WaitForSeconds(1f);
                    GameObject bossbullet1 = objectmanager.MakeObj("bulletenemybace");
                    Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();

                    bossbullet1.transform.localScale = new Vector2(0, 0);
                    bossbullet1.transform.position = new Vector2(bulletpoint.transform.position.x - 1, bulletpoint.transform.position.y + 2);
                    yield return new WaitForSeconds(0.5f);
                    for (int i = 0; i < 12 && HP > 0; i++)
                    {
                        GameObject bulletL = objectmanager.MakeObj("bulletenemybace");
                        enemybullet bullet1 = bulletL.GetComponent<enemybullet>();
                        bulletL.transform.position = bulletpoint1.transform.position;
                        bullet1.rotate = true;
                        bulletL.transform.rotation = Quaternion.identity;
                        bulletL.transform.localScale = new Vector2(0.8f, 1.6f);
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        Vector2 dieVecL = new Vector2(-1, Mathf.Sin(Mathf.PI * 4 * i / 12));
                        rigidL.AddForce(dieVecL.normalized * shotspeed1, ForceMode2D.Impulse);

                        GameObject bulletR = objectmanager.MakeObj("bulletenemybace");
                        enemybullet bullet2 = bulletR.GetComponent<enemybullet>();
                        bullet2.rotate = true;
                        bulletR.transform.position = bulletpoint1.transform.position;
                        bulletR.transform.rotation = Quaternion.identity;
                        bulletR.transform.localScale = new Vector2(0.8f, 1.6f);
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Vector2 dieVecR = new Vector2(-1, Mathf.Sin(Mathf.PI * -4 * i / 12));
                        rigidR.AddForce(dieVecR.normalized * shotspeed1, ForceMode2D.Impulse);

                        GameObject bulletLL = objectmanager.MakeObj("bulletenemybace");
                        enemybullet bullet3 = bulletLL.GetComponent<enemybullet>();
                        bullet3.rotate = true;
                        bulletLL.transform.position = bulletpoint1.transform.position;
                        bulletLL.transform.rotation = Quaternion.identity;
                        bulletLL.transform.localScale = new Vector2(0.8f, 1.6f);
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        Vector2 dieVecLL = new Vector2(-1, Mathf.Sin(Mathf.PI * 6 * i / 12));
                        rigidLL.AddForce(dieVecLL.normalized * shotspeed1, ForceMode2D.Impulse);

                        GameObject bulletRR = objectmanager.MakeObj("bulletenemybace");
                        enemybullet bullet4 = bulletRR.GetComponent<enemybullet>();
                        bullet4.rotate = true;
                        bulletRR.transform.position = bulletpoint1.transform.position;
                        bulletRR.transform.rotation = Quaternion.identity;
                        bulletRR.transform.localScale = new Vector2(0.8f, 1.6f);
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Vector2 dieVecRR = new Vector2(-1, Mathf.Sin(Mathf.PI * -6 * i / 12));
                        rigidRR.AddForce(dieVecRR.normalized * shotspeed1, ForceMode2D.Impulse);
                        yield return new WaitForSeconds(0.05f);



                        int roundnumaB = 20;
                        int roundnumaA = 15;
                        int roundnuma = i % 2 == 0 ? roundnumaA : roundnumaB;

                        for (int index = 0; index < roundnuma; index++)
                        {
                            GameObject bulleta = objectmanager.MakeObj("bulletenemybace");
                            bulleta.transform.position = bulletpoint1.transform.position;
                            bulleta.transform.rotation = Quaternion.identity;
                            bulleta.transform.localScale = new Vector2(0.2f, 0.5f);
                            Rigidbody2D rigida = bulleta.GetComponent<Rigidbody2D>();
                            Vector2 dieVeca = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundnuma)
                                                         , Mathf.Sin(Mathf.PI * 2 * index / roundnuma));
                            rigida.AddForce(dieVeca.normalized * shotspeed1, ForceMode2D.Impulse);

                            Vector3 rotVec = Vector3.forward * 360 * index / roundnuma + Vector3.forward * 90;
                            bulleta.transform.Rotate(rotVec);
                        }


                        bossbullet1.transform.localScale = new Vector2((0.5f * i), (0.5f * i));
                        yield return new WaitForSeconds(0.075f);
                    }
                    Vector3 dieVec1 = playerhitpoint.transform.position - (bulletpoint.transform.position);
                    rigid1.AddForce(dieVec1.normalized * shotspeed1 * 0.5f, ForceMode2D.Impulse);

                }


            }
        else if (bossint == 8)
            while (HP > 0)
            {
                if ((HP / maxHP) > 0.5f)
                {
                    yield return new WaitForSeconds(5f);
                    dieanim.SetTrigger("ack");
                    yield return new WaitForSeconds(1f);
                    if (HP > 0)
                    {
                        for (int i = 0; i < 50 && HP > 0; i++)
                        {

                            GameObject bossbullet1 = objectmanager.MakeObj("bulletenemybace");
                            enemybullet bullet1 = bossbullet1.GetComponent<enemybullet>();
                            bullet1.target = playerhitpoint.transform;
                            bossbullet1.transform.position = bulletpoint1.transform.position;
                            bossbullet1.transform.localScale = new Vector2(0.5f, 0.5f);
                            Rigidbody2D rigid1 = bossbullet1.GetComponent<Rigidbody2D>();
                            Vector3 dieVec1 = playerhitpoint.transform.position - (bulletpoint.transform.position);
                            Vector3 dieVec2 = new Vector3(0, 0.5f);
                            Vector3 dieVec3 = dieVec1 + dieVec2;
                            rigid1.AddForce(dieVec3.normalized * shotspeed1 * 2, ForceMode2D.Impulse);


                            GameObject bossbullet2 = objectmanager.MakeObj("bulletenemybace");
                            enemybullet bullet5 = bossbullet2.GetComponent<enemybullet>();
                            bullet5.target = playerhitpoint.transform;
                            bossbullet2.transform.position = bulletpoint.transform.position;
                            bossbullet2.transform.localScale = new Vector2(0.5f, 0.5f);
                            Rigidbody2D rigid = bossbullet2.GetComponent<Rigidbody2D>();
                            Vector3 dieVec4 = new Vector3(0, -0.5f);
                            Vector3 dieVec5 = dieVec1 + dieVec4;
                            rigid.AddForce(dieVec5.normalized * shotspeed1 * 2, ForceMode2D.Impulse);

                            yield return new WaitForSeconds(0.02f);
                        }
                        GameObject bossbulletb = objectmanager.MakeObj("bulletenemyB");
                        enemybullet bulletb = bossbulletb.GetComponent<enemybullet>();
                        SpriteRenderer sp = bossbulletb.GetComponent<SpriteRenderer>();
                        sp.color = new Color(0, 1, 0, 1);
                        bulletb.target = playerhitpoint.transform;
                        bulletb.poison = true;
                        bulletb.slow = true;
                        bossbulletb.transform.position = bulletpoint1.transform.position;
                        bossbulletb.transform.localScale = new Vector2(4f, 4f);
                        Rigidbody2D rigidb = bossbulletb.GetComponent<Rigidbody2D>();
                        Vector3 dieVecb = playerhitpoint.transform.position - (bulletpoint.transform.position);
                        rigidb.AddForce(dieVecb.normalized * shotspeed1, ForceMode2D.Impulse);


                        if ((HP / maxHP) <= 0.5f)
                        {
                            dieanim.SetTrigger("2page");
                            box.enabled = false;
                        }
                    }
                   
                }
                else
                {
                    box.enabled = true;
                    yield return new WaitForSeconds(8f);
                    dieanim.SetTrigger("2atk");
                    yield return new WaitForSeconds(1.5f);
                    for (int i = 0; i < 95 && HP > 0; i++)
                    {
                        float ran = Random.Range(0.2f, 2);

                        GameObject bulletL = objectmanager.MakeObj("bulletenemybace");
                        enemybullet bullet1 = bulletL.GetComponent<enemybullet>();
                        bulletL.transform.position = 
                            new Vector2(Random.Range(-10,10), bulletpoint1.transform.position.y);
                        bullet1.rotate = true;
                        bulletL.transform.rotation = Quaternion.identity;
                        bulletL.transform.localScale = new Vector2(0.8f, 0.8f);
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidL.AddForce(Vector2.down* shotspeed1*ran, ForceMode2D.Impulse);


                        GameObject bulletLL = objectmanager.MakeObj("bulletenemyB");
                        enemybullet bullet3 = bulletLL.GetComponent<enemybullet>();
                        SpriteRenderer sp1 = bulletLL.GetComponent<SpriteRenderer>();
                        sp1.color = new Color(0, 1, 0, 1);
                        bullet3.rotate = true;
                        bullet3.poison = true;
                        bullet3.slow = true;
                        bulletLL.transform.position = new Vector2(Random.Range(-10, 10), bulletpoint1.transform.position.y);
                        bulletLL.transform.rotation = Quaternion.identity;
                        bulletLL.transform.localScale = new Vector2(1, 1);
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidLL.AddForce(Vector2.down * shotspeed1 * ran, ForceMode2D.Impulse);

                        yield return new WaitForSeconds(0.1f);

                    }
                }


            }
    }
    IEnumerator boxsm()
    {
        for (int i = 0; i < 58; i++)
        {
            box.size = new Vector2(4.85f - (0.0669f * (i + 1)), 1.96f - (0.135f * (i + 1)));
            yield return new WaitForSeconds(0.006f);
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(2f);
        box.enabled = true;
       
        patternindex = patternindex == bossint%5 ? 0 : patternindex + 1;
        curpatterncount = 0;
        if (bossint < 5)
            switch (patternindex)
            {
                case 0:

                    FireFoward();
                    break;
                case 1:
                    FireShot();
                    break;
                case 2:
                    FireArc();
                    break;
                case 3:
                    FireAround();
                    break;
            }
        else if (bossint < 9)
            switch (patternindex)
            {
                case 0:
                    StartCoroutine(FireFollow());
                    break;
                case 1:
                    StartCoroutine(FireArc1());
                    break;
                case 2:
                    FireArc();
                    break;
                case 3:
                    FireAround();
                    break;
            }



    }
    IEnumerator FireFollow()
    {
        for(int i =0;i<Random.Range(3,5) && HP>0;i++)
        {
            GameObject bossbullet = objectmanager.MakeObj("bulletenemybace");
            enemybullet bullet = bossbullet.GetComponent<enemybullet>();
            bullet.target = playerhitpoint.transform;
            bullet.maxfollowint = 1;
            bullet.speed = shotspeed1 * 2;
            bossbullet.transform.position = bulletpoint.transform.position;
            bossbullet.transform.localScale = new Vector2(1, 1);
            Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();

            Vector3 dieVec = playerhitpoint.transform.position - (bulletpoint.transform.position);
            bullet.StartCoroutine(bullet.follow());
            rigid.AddForce(dieVec.normalized * shotspeed1 * 2, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
        

        curpatterncount++;

        StartCoroutine(Think());
    }
    IEnumerator FireArc1()
    {
        
        for(int i = 0; i<5 && HP > 0; i++)
        {
            GameObject bulletL = objectmanager.MakeObj("bulletenemybace");
            bulletL.transform.position = bulletpoint1.transform.position;
            bulletL.transform.rotation = Quaternion.identity;
            bulletL.transform.localScale = new Vector2(1, 1);
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
            Vector2 dieVecL = new Vector2(-1, Mathf.Sin(Mathf.PI * 4 * i / 5));
            rigidL.AddForce(dieVecL.normalized * shotspeed1, ForceMode2D.Impulse);

            GameObject bulletR = objectmanager.MakeObj("bulletenemybace");
            bulletR.transform.position = bulletpoint.transform.position;
            bulletR.transform.rotation = Quaternion.identity;
            bulletR.transform.localScale = new Vector2(1, 1);
            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Vector2 dieVecR = new Vector2(-1, Mathf.Sin(Mathf.PI * -4 * i / 5));
            rigidR.AddForce(dieVecR.normalized * shotspeed1, ForceMode2D.Impulse);

            GameObject bulletLL = objectmanager.MakeObj("bulletenemybace");
            bulletLL.transform.position = bulletpoint1.transform.position;
            bulletLL.transform.rotation = Quaternion.identity;
            bulletLL.transform.localScale = new Vector2(1, 1);
            Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
            Vector2 dieVecLL = new Vector2(-1, Mathf.Sin(Mathf.PI * 6 * i / 5));
            rigidLL.AddForce(dieVecLL.normalized * shotspeed1, ForceMode2D.Impulse);

            GameObject bulletRR = objectmanager.MakeObj("bulletenemybace");
            bulletRR.transform.position = bulletpoint.transform.position;
            bulletRR.transform.rotation = Quaternion.identity;
            bulletRR.transform.localScale = new Vector2(1, 1);
            Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
            Vector2 dieVecRR = new Vector2(-1, Mathf.Sin(Mathf.PI * -6 * i / 5));
            rigidRR.AddForce(dieVecRR.normalized * shotspeed1, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
        }
        
        curpatterncount++;

            StartCoroutine(Think());

    }
    void FireFoward()
    {


        if (HP <= 0)
            return;

        GameObject bossbullet = objectmanager.MakeObj("bulletenemyA");
        bossbullet.transform.position = bulletpoint.transform.position + Vector3.left * 1f;
       
        Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();
       

        Vector3 dieVec = playerhitpoint.transform.position - (bulletpoint.transform.position + Vector3.left * 1f);
       
        rigid.AddForce(dieVec.normalized * shotspeed1*2, ForceMode2D.Impulse);
        
        curpatterncount++;

        if (curpatterncount < maxpatterncount[patternindex])
            Invoke("FireFoward", 1f);
        else
            StartCoroutine(Think());


    }
    void FireShot()
    {
        if (HP <= 0)
            return;
        for(int index=0; index <5; index++)
        {
            GameObject bossbullet = objectmanager.MakeObj("bulletenemyA");
            bossbullet.transform.position = bulletpoint.transform.position;

            Rigidbody2D rigid = bossbullet.GetComponent<Rigidbody2D>();
            Vector2 dieVec = playerhitpoint.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(0f, 2f), Random.Range(-0.5f, 0.5f));
            dieVec += ranVec;
            rigid.AddForce(dieVec.normalized * shotspeed1*2, ForceMode2D.Impulse);
        }
        curpatterncount++;


        if (curpatterncount < maxpatterncount.Length)
            Invoke("FireShot", 1.2f);
        else
            StartCoroutine(Think());


    }
    void FireArc()

    {
        if (HP <= 0)
            return;
      
        GameObject bulletL = objectmanager.MakeObj("bulletenemybace");
        bulletL.transform.position = bulletpoint.transform.position;
        bulletL.transform.localScale = new Vector2(0.5f,0.5f);
        bulletL.transform.rotation = Quaternion.identity;
        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
        Vector2 dieVecL = new Vector2(-1, Mathf.Sin(Mathf.PI * 4 * curpatterncount / maxpatterncount[patternindex]));
        rigidL.AddForce(dieVecL.normalized * shotspeed1, ForceMode2D.Impulse);
        //
        GameObject bulletR = objectmanager.MakeObj("bulletenemybace");
        bulletR.transform.position = bulletpoint.transform.position;
        bulletR.transform.localScale = new Vector2(0.5f, 0.5f);
        bulletR.transform.rotation = Quaternion.identity;
        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Vector2 dieVecR = new Vector2(-1, Mathf.Sin(Mathf.PI * -4 * curpatterncount / maxpatterncount[patternindex]));
        rigidR.AddForce(dieVecR.normalized * shotspeed1, ForceMode2D.Impulse);

        GameObject bulletLL = objectmanager.MakeObj("bulletenemybace");
        bulletLL.transform.position = bulletpoint.transform.position;
        bulletLL.transform.localScale = new Vector2(0.5f, 0.5f);
        bulletLL.transform.rotation = Quaternion.identity;
        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
        Vector2 dieVecLL = new Vector2(-1, Mathf.Sin(Mathf.PI * 6 * curpatterncount / maxpatterncount[patternindex]));
        rigidLL.AddForce(dieVecLL.normalized * shotspeed1, ForceMode2D.Impulse);

        GameObject bulletRR = objectmanager.MakeObj("bulletenemybace");
        bulletRR.transform.position = bulletpoint.transform.position;
        bulletRR.transform.localScale = new Vector2(0.5f, 0.5f);
        bulletRR.transform.rotation = Quaternion.identity;
        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
        Vector2 dieVecRR = new Vector2(-1, Mathf.Sin(Mathf.PI * -6 * curpatterncount / maxpatterncount[patternindex]));
        rigidRR.AddForce(dieVecRR.normalized * shotspeed1, ForceMode2D.Impulse);

       

        curpatterncount++;

        if (curpatterncount < maxpatterncount[patternindex])
            Invoke("FireArc", 0.15f);
        else
            StartCoroutine(Think());


    }
    void FireAround()
    {
        if (HP <= 0)
            return;
        int roundnumaA = 50;
        int roundnumaB = 40;
        int roundnuma = curpatterncount%2==0 ? roundnumaA : roundnumaB;

        for (int index = 0; index < roundnuma; index++)
        {
            GameObject bulletRR = objectmanager.MakeObj("bulletenemybace");
            bulletRR.transform.position = bulletpoint.transform.position;
            bulletRR.transform.localScale = new Vector2(0.5f, 0.5f);
            bulletRR.transform.rotation = Quaternion.identity;
            Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
            Vector2 dieVecRR = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundnuma)
                                         , Mathf.Sin(Mathf.PI * 2 * index / roundnuma));
            rigidRR.AddForce(dieVecRR.normalized * shotspeed1, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundnuma + Vector3.forward*90;
            bulletRR.transform.Rotate(rotVec);
        }
       

        curpatterncount++;

        if (curpatterncount < maxpatterncount[patternindex])
            Invoke("FireAround", 0.7f);
        else
            StartCoroutine(Think());


    }

    void Update()
    {
        if (!isdie && !noatkzon && !isboss)
        {
            Fire();
            Reload();
        }
        else if (gm.fadescript.chapter == 0 || gm.btend)
        {
            HP = -50;
            StartCoroutine(returnsprite());
        }
           
    }
    public void BOSS()
    {
        if (!isboss)
            return;

        if (HP <= 0)
        {
            bossHP.text = string.Format("{0}", 0 + "/" + maxHP);
            bossHPbar.sizeDelta = new Vector2(0, 100);
            if (!bossdie)
            {
                bossdie = true;
                StartCoroutine(diewate());
                StartCoroutine(HPbarf());
            }
        }
        else
        {
            bossHP.text = string.Format("{0}", HP + "/" + maxHP);
            bossHPbar.sizeDelta = new Vector2((HP / maxHP) * 500, 100);
        }
            
    }
    IEnumerator diewate()
    {
        yield return new WaitForSeconds(1f);
        gm.stageend();
    }
    IEnumerator HPbarf()
    {
        yield return new WaitForSeconds(1f);
        bossHPgroup[0].SetActive(false);
        bossHPbar.localScale =new Vector2(1 , 1);
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;
        
        if (enemynum == 2 || enemynum == 5)
        {

            enemybullet enemybulletLogic = bulletobjtA.GetComponent<enemybullet>();
            enemybulletLogic.dmg = this.dmg;


            GameObject bullet = objectmanager.MakeObj("bulletenemyA");
            bullet.transform.position = bulletpoint.transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.localScale = new Vector2(1, 0.2f);

            Vector3 dieVec = playerhitpoint.transform.position - transform.position;
            rigid.AddForce(dieVec.normalized * shotspeed1, ForceMode2D.Impulse);
        }
        else if (enemynum == 4)
        {
            enemybullet enemybulletLogic = bulletobjtA.GetComponent<enemybullet>();
            enemybulletLogic.dmg = this.dmg;

            GameObject bullet = objectmanager.MakeObj("bulletenemyA");
            bullet.transform.position = bulletpoint.transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.localScale = new Vector2(2, 0.4f);

            Vector3 dieVec = playerhitpoint.transform.position - transform.position;
            rigid.AddForce(dieVec.normalized * shotspeed1, ForceMode2D.Impulse);
        }
        else if (enemynum == 24)
            StartCoroutine(num24atk());
        else if (enemynum == 25 &&  HP > 0)
        {
            GameObject bullet = objectmanager.MakeObj("bulletenemyB");
            enemybullet enemybulletLogic = bullet.GetComponent<enemybullet>();
            enemybulletLogic.dmg = this.dmg;

            bullet.transform.position = bulletpoint.transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.localScale = new Vector2(2, 2f);

            Vector3 dieVec = playerhitpoint.transform.position - transform.position;
            rigid.AddForce(dieVec.normalized * shotspeed1, ForceMode2D.Impulse);
        }


        curShotDelay = 0;
    }
    IEnumerator num24atk()
    {
        dieanim.SetTrigger("atk");
        yield return new WaitForSeconds(0.5f);
        if (HP > 0)
        {
            enemybullet enemybulletLogic = bulletobjtA.GetComponent<enemybullet>();
            enemybulletLogic.dmg = this.dmg;

            GameObject bullet = objectmanager.MakeObj("bulletenemyA");
            bullet.transform.position = bulletpoint.transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

            Vector3 dieVec = playerhitpoint.transform.position - bulletpoint.transform.position;

            if (dieVec.x < 0)
                bullet.transform.localScale = new Vector2(2, 2f);
            else if (dieVec.x > 0)
                bullet.transform.localScale = new Vector2(-2, 2f);

            rigid.AddForce(dieVec.normalized * shotspeed1, ForceMode2D.Impulse);
        }
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
    public void onhit()
    {
        if (nodmg)
            return;

        if(!isdie)
        {
            BOSS();

            GameObject randmgtxt = objectmanager.MakeObj("dmg");
            dmgtxt dmglogic = randmgtxt.GetComponent<dmgtxt>();
            player pl = player.GetComponent<player>();
            int ran = Random.Range(1, 101);
            if (ran <= pl.plui[3])
            {
                dmglogic.transform.localScale = new Vector2(0.1f, 0.1f);
                dmglogic.alpha = Color.red;
                hitdmg = pl.dmg * pl.plui[4];
                float Criatkran = Random.Range(hitdmg - (hitdmg * 0.2f),
                    hitdmg + (hitdmg * 0.2f));
                HP -= isdmg = dmglogic.randmgtxt = (int)Criatkran;
            }
            else if (ran > pl.plui[3])
            {
                dmglogic.transform.localScale = new Vector2(0.07f, 0.07f);
                hitdmg = pl.dmg;
                dmglogic.alpha = Color.white;
                float nmatkran = Random.Range(hitdmg - (hitdmg * 0.2f), hitdmg + (hitdmg * 0.2f));
                HP -= isdmg = dmglogic.randmgtxt = (int)nmatkran;
            }
          
            randmgtxt.transform.position = transform.position;
              StartCoroutine(returnsprite());
        }
    }
 
    IEnumerator returnsprite()
    {
        BOSS();
        if(HP > 0 && !isdie && !bossbullet)
        {
            if (bossint == 0 && enemynum != 26)
                dieanim.SetTrigger("hit");
        }
          
        else if (HP <= 0 && !isdie&&!bossbullet)
        {
           
            isdie = true;
            box.enabled = false;
            player pl = player.GetComponent<player>();
            int fran = bossint > 0 ? 0 : Random.Range(0, 50);
            if (fran < 10)//not item;
            {
                gm.enemydeadint++;
                gm.stagepertxt.text =
                    gm.enemydeadint.ToString() + " / " +
                    gm.stageenemyint.ToString();
            }
            else if (fran < 40)//coin
            {
                GameObject itemcoin = objectmanager.MakeObj("itemcoin");
                item item1 = itemcoin.GetComponent<item>();
               
                if (pl.itemtargeting)
                    item1.targeting = true;
                else
                    item1.targeting = false;

                item1.target = playerhitpoint;
                itemcoin.transform.position = gameObject.transform.position;
                gm.enemydeadint++;
                gm.stagepertxt.text =
                    gm.enemydeadint.ToString() + " / " +
                    gm.stageenemyint.ToString();

            }
            else if (fran < 45)//heal
            {
                GameObject itemheal = objectmanager.MakeObj("itemheal");
                item item2 = itemheal.GetComponent<item>();
                if (pl.itemtargeting)
                    item2.targeting = true;
                else
                    item2.targeting = false;

                item2.target = playerhitpoint;
                itemheal.transform.position = gameObject.transform.position;
                gm.enemydeadint++;
                gm.stagepertxt.text =
                    gm.enemydeadint.ToString() + " / " +
                    gm.stageenemyint.ToString();
            }

            else if (fran < 50)//soul
            {
                GameObject soul = objectmanager.MakeObj("itemsoul");
                 item item3 = soul.GetComponent<item>();
                if (pl.itemtargeting)
                    item3.targeting = true;
                else
                    item3.targeting = false;

                item3.target = playerhitpoint;
                soul.transform.position = gameObject.transform.position;
                gm.enemydeadint++;
                gm.stagepertxt.text =
                    gm.enemydeadint.ToString() + " / " +
                    gm.stageenemyint.ToString();
            }
            if(gm.enemydeadint >= gm.stageenemyint &&
                gm.stage%5!=0)
                gm.stageend();
            yield return new WaitForSecondsRealtime(0.1f);
            dieanim.SetTrigger("dodie");
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !isboss)
        {
            if (bossbullet)
            {
                gameObject.SetActive(false);
                rg.velocity = new Vector2(0,0);
            }
               
            else
            {
                int enemypoint = Random.Range(0, 9);
                transform.rotation = Quaternion.identity;
                transform.position = gm.spawn1points[enemypoint].position;
                if (enemypoint == 5 || enemypoint == 6)
                    rg.velocity = new Vector2(speed * (-1), -0.5f);
                else if (enemypoint == 7 || enemypoint == 8)
                    rg.velocity = new Vector2(speed * (-1), 0.5f);
                else
                    rg.velocity = new Vector2(speed * (-1), 0);
                if (enemynum == 26)
                    StartCoroutine(enemynum26());
                else if (enemynum == 21)
                    StartCoroutine(enemynum21());
                else if (enemynum == 22)
                    StartCoroutine(enemynum22());
                else if (enemynum == 25)
                    StartCoroutine(enemynum25());

            }
            
        }
        else if (collision.gameObject.layer == 6)
        {
            bullet bulletdmg = collision.gameObject.GetComponent<bullet>();
            onhit();
            if(!bulletdmg.weapon2)
            {
                collision.gameObject.SetActive(false);
                collision.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
          
        }
        else if (collision.gameObject.tag == "boom")
        {
            onhit();
        }
        else if (collision.gameObject.layer == 10)
        {
            if (!pl.ishit && !pl.isbooming && !gm.btend)
            {
                pl.ishit = true;

                int ran = Random.Range(0, 10 + pl.evasion);
                if (ran <= 10)
                {
                    if (pl.defense < 1 + (int)dmg - pl.plui[5])
                        pl.life -= 1 + (int)dmg - pl.plui[5];
                    else
                        pl.life -= 1;

                }
                pl.StartCoroutine(pl.ishitfals());
                if (pl.life > 0)
                {
                    pl.catam[pl.catint].SetTrigger("dohit");
                    pl.playeran.SetTrigger("dohit");
                }
            }
           
            pl.StartCoroutine(pl.txt());
        }
      

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && enemyname != "10")
        {
            noatkzon = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && enemyname != "10")
        {
            noatkzon = false;
        }
    }
}
