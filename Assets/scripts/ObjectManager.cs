using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameManager gm;

    public GameObject enemySPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemyLPrefab;
    public GameObject enemy4Prefab;
    public GameObject enemy5Prefab;
    public GameObject enemy6Prefab;
    public GameObject enemyBPrefab;
    public GameObject miniB1Prefab;
    public GameObject miniB2Prefab;
    public GameObject miniB3Prefab;

    public GameObject Brange1Prefab;
    public GameObject Brange2Prefab;

    public GameObject itemcoinPrefab;
    public GameObject itemchurooPrefab;
    public GameObject itemsoulPrefab;
    public GameObject itemhealPrefab;

   
    public GameObject[] bulletPlayerAPrefab;

    public GameObject poisonPrefab;
    public GameObject bulletenemybacePrefab;
    public GameObject bulletenemyAPrefab;
    public GameObject bulletenemyBPrefab;
    public GameObject B4bulletPrefab;
    public GameObject MBB10Prefab;
    public GameObject MBB11Prefab;
    public GameObject MBB12Prefab;
    public GameObject MBB2Prefab;
    public GameObject MBB3Prefab;

    public GameObject dmgPrefab;



    GameObject[] enemyS;
    GameObject[] enemyM;
    GameObject[] enemyL;
    GameObject[] enemy4;
    GameObject[] enemy5;
    GameObject[] enemy6;
    GameObject[] enemyB;
    GameObject[] miniB1;
    GameObject[] miniB2;
    GameObject[] miniB3;

    GameObject[] Brange1;
    GameObject[] Brange2;

    GameObject[] itemcoin;
    GameObject[] itemchuroo;
    GameObject[] itemsoul;
    GameObject[] itemheal;

   
    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayer2A;

    GameObject[] poison;
    GameObject[] bulletenemybace;
    GameObject[] bulletenemyA;
    GameObject[] bulletenemyB;
    GameObject[] B4bullet;
    GameObject[] MBB10;
    GameObject[] MBB11;
    GameObject[] MBB12;
    GameObject[] MBB2;
    GameObject[] MBB3;

    GameObject[] dmg;

    GameObject[] targetpool;
    void Awake()
    {
        if (gm == null)
            gm = GameObject.Find("gamemanager").GetComponent<GameManager>();
        
        StartCoroutine(findgm());
    }
    IEnumerator findgm()
    {
        while (gm == null)
            yield return new WaitForFixedUpdate();
        gm.objectmanager = this;
        while (gm.objectmanager == null)
            yield return new WaitForFixedUpdate();

        StartCoroutine(Generate1());
        StartCoroutine(Generate());
    }
    private void Update()
    {
        if (gm != null && gm.objectmanager != null)
            return;

        gm.objectmanager = this;
    }
    IEnumerator Generate1()
    {
        yield return new WaitForSeconds(0.01f);
        
        enemyS = new GameObject[100];
        enemyM = new GameObject[100];
        enemyL = new GameObject[300];
        enemy4 = new GameObject[300];
        enemy5 = new GameObject[300];
        enemy6 = new GameObject[300];
        enemyB = new GameObject[1];
        miniB1 = new GameObject[1];
        miniB2 = new GameObject[1];
        miniB3 = new GameObject[1];

        Brange1 = new GameObject[10];
        Brange2 = new GameObject[10];

        itemcoin = new GameObject[100];
        itemchuroo = new GameObject[100];
        itemsoul = new GameObject[100];
        itemheal = new GameObject[100];


        poison = new GameObject[10];
        bulletenemybace = new GameObject[1000];
        bulletenemyB = new GameObject[1000];
        bulletenemyA = new GameObject[1000];
        B4bullet = new GameObject[20];
        MBB10 = new GameObject[10];
        MBB11 = new GameObject[10];
        MBB12 = new GameObject[10];
        MBB2 = new GameObject[10];
        MBB3 = new GameObject[10];

        bulletPlayerA = new GameObject[200];
        bulletPlayer2A = new GameObject[200];
        dmg = new GameObject[500];

    }
    IEnumerator Generate()
    {
        yield return new WaitForSeconds(0.02f);
        
        // enemy
        for (int index = 0; index< enemyS.Length; index++)
        {
            enemyS[index] = Instantiate(enemySPrefab);
            enemyS[index].SetActive(false);
        }
        for (int index = 0; index < enemyM.Length; index++)
        {
            enemyM[index] = Instantiate(enemyMPrefab);
            enemyM[index].SetActive(false);
        }
        for (int index = 0; index < enemyL.Length; index++)
        {
            enemyL[index] = Instantiate(enemyLPrefab);
            enemyL[index].SetActive(false);
        }
        for (int index = 0; index < enemy4.Length; index++)
        {
            enemy4[index] = Instantiate(enemy4Prefab);
            enemy4[index].SetActive(false);
        }
        for (int index = 0; index < enemy5.Length; index++)
        {
            enemy5[index] = Instantiate(enemy5Prefab);
            enemy5[index].SetActive(false);
        }
        for (int index = 0; index < enemy6.Length; index++)
        {
            enemy6[index] = Instantiate(enemy6Prefab);
            enemy6[index].SetActive(false);
        }
        for (int index = 0; index < enemyB.Length; index++)
        {
            enemyB[index] = Instantiate(enemyBPrefab);
            enemyB[index].SetActive(false);
        }
        for (int index = 0; index < miniB1.Length; index++)
        {
            miniB1[index] = Instantiate(miniB1Prefab);
            miniB1[index].SetActive(false);
        }
        for (int index = 0; index < miniB2.Length; index++)
        {
            miniB2[index] = Instantiate(miniB2Prefab);
            miniB2[index].SetActive(false);
        }
        for (int index = 0; index < miniB3.Length; index++)
        {
            miniB3[index] = Instantiate(miniB3Prefab);
            miniB3[index].SetActive(false);
        }


        // item
        for (int index = 0; index < itemcoin.Length; index++)
        {
            itemcoin[index] = Instantiate(itemcoinPrefab);
            itemcoin[index].SetActive(false);
        }

        for (int index = 0; index < itemchuroo.Length; index++)
        {
            itemchuroo[index] = Instantiate(itemchurooPrefab);
            itemchuroo[index].SetActive(false);
        }
        for (int index = 0; index < itemsoul.Length; index++)
        {
            itemsoul[index] = Instantiate(itemsoulPrefab);
            itemsoul[index].SetActive(false);
        }
        for (int index = 0; index < itemheal.Length; index++)
        {
            itemheal[index] = Instantiate(itemhealPrefab);
            itemheal[index].SetActive(false);
        }



        // bullet
        for (int index = 0; index < poison.Length; index++)
        {
            poison[index] = Instantiate(poisonPrefab);
            poison[index].SetActive(false);
        }
        for (int index = 0; index < bulletenemybace.Length; index++)
        {
            bulletenemybace[index] = Instantiate(bulletenemybacePrefab);
            bulletenemybace[index].SetActive(false);
        }
        
        for (int index = 0; index < bulletenemyA.Length; index++)
        {
            bulletenemyA[index] = Instantiate(bulletenemyAPrefab);
            bulletenemyA[index].SetActive(false);
        }
        for (int index = 0; index < bulletenemyB.Length; index++)
        {
            bulletenemyB[index] = Instantiate(bulletenemyBPrefab);
            bulletenemyB[index].SetActive(false);
        }
        for (int index = 0; index < Brange1.Length; index++)
        {
            Brange1[index] = Instantiate(Brange1Prefab);
            Brange1[index].SetActive(false);
        }
        for (int index = 0; index < Brange2.Length; index++)
        {
            Brange2[index] = Instantiate(Brange2Prefab);
            Brange2[index].SetActive(false);
        }
        for (int index = 0; index < B4bullet.Length; index++)
        {
            B4bullet[index] = Instantiate(B4bulletPrefab);
            B4bullet[index].SetActive(false);
        }
        for (int index = 0; index < MBB10.Length; index++)
        {
            MBB10[index] = Instantiate(MBB10Prefab);
            MBB10[index].SetActive(false);
        }
        for (int index = 0; index < MBB11.Length; index++)
        {
            MBB11[index] = Instantiate(MBB11Prefab);
            MBB11[index].SetActive(false);
        }
        for (int index = 0; index < MBB12.Length; index++)
        {
            MBB12[index] = Instantiate(MBB12Prefab);
            MBB12[index].SetActive(false);
        }
        for (int index = 0; index < MBB2.Length; index++)
        {
            MBB2[index] = Instantiate(MBB2Prefab);
            MBB2[index].SetActive(false);
        }
        for (int index = 0; index < MBB3.Length; index++)
        {
            MBB3[index] = Instantiate(MBB3Prefab);
            MBB3[index].SetActive(false);
        }



        for (int index = 0; index < bulletPlayerA.Length; index++)
        {
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab[0]);
            bulletPlayerA[index].SetActive(false);
        }
       
        for (int index = 0; index < bulletPlayer2A.Length; index++)
        {
            bulletPlayer2A[index] = Instantiate(bulletPlayerAPrefab[1]);
            bulletPlayer2A[index].SetActive(false);
        }



        for (int index = 0; index < dmg.Length; index++)
        {
            dmg[index] = Instantiate(dmgPrefab);
            dmg[index].SetActive(false);
        }




    }
    public void bullet1Player()
    {
            player logic = gm.player.GetComponent<player>();
        int i = logic.weaponnum;
        
        for (int index = 0; index < bulletPlayerA.Length; index++)
        {
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab[i]);
            bulletPlayerA[index].SetActive(false);
        }
       
    }
    public void bullet2Player()
    {
        player logic = gm.player.GetComponent<player>();
        int i = (logic.weapon2num-1);
        
        for (int index = 0; index < bulletPlayer2A.Length; index++)
        {
            bulletPlayer2A[index] = Instantiate(bulletPlayerAPrefab[i]);
            bulletPlayer2A[index].SetActive(false);
        }

    }
    public GameObject MakeObj(string type)
    {
        switch(type)
        {

            case "1":
                targetpool = enemyS;
                break;
            case "2":
                targetpool = enemyM;
                break;
            case "3":
                targetpool = enemyL;
                break;
            case "4":
                targetpool = enemy4;
                break;
            case "5":
                targetpool = enemy5;
                break;
            case "6":
                targetpool = enemy6;
                break;
            case "B":
                targetpool = enemyB;
                break;
            case "miniB1":
                targetpool = miniB1;
                break;
            case "miniB2":
                targetpool = miniB2;
                break;
            case "miniB3":
                targetpool = miniB3;
                break;



            case "itemcoin":
                targetpool = itemcoin;
                break;
            case "itemchuroo":
                targetpool = itemchuroo;
                break;
            case "itemsoul":
                targetpool = itemsoul;
                break;
            case "itemheal":
                targetpool = itemheal;
                break;


            case "Brange1":
                targetpool = Brange1;
                break;

            case "Brange2":
                targetpool = Brange2;
                break;




            case "poison":
                targetpool = poison;
                break;

            case "bulletenemybace":
                targetpool = bulletenemybace;
                break;
            case "bulletenemyA":
                targetpool = bulletenemyA;
                break;
            case "bulletenemyB":
                targetpool = bulletenemyB;
                break;
            case "B4bullet":
                targetpool = B4bullet;
                break;
            case "MBB10":
                targetpool = MBB10;
                break;
            case "MBB11":
                targetpool = MBB11;
                break;
            case "MBB12":
                targetpool = MBB12;
                break;
            case "MBB2":
                targetpool = MBB2;
                break;
            case "MBB3":
                targetpool = MBB3;
                break;





            case "bulletPlayerA":
                targetpool = bulletPlayerA;
                break;
            case "bulletPlayer2A":
                targetpool = bulletPlayer2A;
                break;

            case "dmg":
                targetpool = dmg;
                break;

        }
        for (int index = 0; index < targetpool.Length; index++)
        {
            if (!targetpool[index].activeSelf)
            {
                targetpool[index].SetActive(true);
                return targetpool[index];
            }
        }

        return null;
    }
    public GameObject[] Getpool(string type)
    {
        switch (type)
        {

            case "1":
                targetpool = enemyS;
                break;
            case "2":
                targetpool = enemyM;
                break;
            case "3":
                targetpool = enemyL;
                break;
            case "4":
                targetpool = enemy4;
                break;
            case "5":
                targetpool = enemy5;
                break;
            case "6":
                targetpool = enemy6;
                break;
            case "B":
                targetpool = enemyB;
                break;
            case "miniB1":
                targetpool = miniB1;
                break;
            case "miniB2":
                targetpool = miniB2;
                break;
            case "miniB3":
                targetpool = miniB3;
                break;



            case "itemcoin":
                targetpool = itemcoin;
                break;
            case "itemchuroo":
                targetpool = itemchuroo;
                break;
            case "itemsoul":
                targetpool = itemsoul;
                break;
            case "itemheal":
                targetpool = itemheal;
                break;


            case "Brange1":
                targetpool = Brange1;
                break;

            case "Brange2":
                targetpool = Brange2;
                break;



            case "poison":
                targetpool = poison;
                break;
            case "bulletenemybace":
                targetpool = bulletenemybace;
                break;
            case "bulletenemyA":
                targetpool = bulletenemyA;
                break;
            case "bulletenemyB":
                targetpool = bulletenemyB;
                break;
            case "B4bullet":
                targetpool = B4bullet;
                break;
            case "MBB10":
                targetpool = MBB10;
                break;
            case "MBB11":
                targetpool = MBB11;
                break;
            case "MBB12":
                targetpool = MBB12;
                break;
            case "MBB2":
                targetpool = MBB2;
                break;
            case "MBB3":
                targetpool = MBB3;
                break;



            case "bulletPlayerA":
                targetpool = bulletPlayerA;

                break;
            case "bulletPlayer2A":
                targetpool = bulletPlayer2A;
                break;

            case "dmg":
                targetpool = dmg;
                break;

        }
        return targetpool;
    }



}
