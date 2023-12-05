using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
   /** public float power;
    public float movespeed;
    public float attspeed;
    public float criper;
    public float cridmg;
    public float def;
    public float getper;
    public float healper;
    public float skill;
    public float life;
    public float sellper;
    public float wtf;
    public float maxHP;
    public float HPper;**/
    public bool uiopening1;
    public bool uiopening2;
    public bool uiopening3;
    public bool uiopening4;
    public bool ui1bool;
    public bool ui1bool1;
    public bool ui1bool2;
    public bool ui1bool3;
    public bool ui1bool4;
    public bool ui1bool5;
    public bool ui1bool6;
    public bool ui1bool7;
    public bool ui1bool8;
    public bool ui1bool9;
    public bool ui1bool10;
    public bool ui1bool11;
    public bool ui1bool12;
    public bool ui1bool13;
    public bool ui1bool14;
    public bool ui1bool15;
    public bool ui1bool16;
    public bool ui1bool17;
    public bool ui1bool18;
    public bool ui1bool19;
    public bool ui1bool20;
    public bool ui1bool21;
    public bool ui1bool22;
    public bool ui1bool23;
    public bool ui1bool24;
    public bool ui1bool25;
    public bool ui1bool26;
    public bool ui1bool27;
    public bool ui1bool28;
    public bool ui1bool29;
    public bool ui1bool30;
    public bool ui1bool31;
    public bool ui1bool32;
    public bool codeonly1;
    public bool codeonly2;
    public bool moveset;
    public bool introset;
    public int plsoul;

}
public class jsondata : MonoBehaviour
{
    public static jsondata Instance;
    public datamanager dm;
    public player pl;
    public string path;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        path = Path.Combine(Application.persistentDataPath, "database.cat");
        load();
    }
    public void load()
    {
        SaveData savedata = new SaveData();

        if(!File.Exists(path))
        {
            for(int i=0;i<50;i++)
            {
                if(i<dm.mainbool.Length)
                {
                    if (i == 2 || i == 6 || i == 7 || i == 8 || i == 10 || i == 11)
                        dm.mainbool[i] = 1;
                    else
                        dm.mainbool[i] = 0;

                }
                if (i < dm.uiopening.Length)
                    dm.uiopening[i] = false;
                if (i < dm.ui1bool.Length)
                    dm.ui1bool[i] = false;
                if (i < dm.codeonly.Length)
                    dm.codeonly[i] = false;
                if (i < dm.plbuff.Length)
                    dm.plbuff[i] = 0;
            }
            dm.moveset = false;
            dm.chapterindex = 0;
            pl.soul = 0;
            Save();
        }
        else
        {
            string loadjson = File.ReadAllText(path);
            savedata = JsonUtility.FromJson<SaveData>(loadjson);
            if (savedata != null)
            {
                dm.codeonly[0] = savedata.codeonly1;
                dm.codeonly[1] = savedata.codeonly2;
                dm.uiopening[0] = savedata.uiopening1;
                dm.uiopening[1] = savedata.uiopening2;
                dm.uiopening[2] = savedata.uiopening3;
                dm.uiopening[3] = savedata.uiopening4;
                dm.ui1bool[0] = savedata.ui1bool;
                dm.ui1bool[1] = savedata.ui1bool1;
                dm.ui1bool[2] = savedata.ui1bool2;
                dm.ui1bool[3] = savedata.ui1bool3;
                dm.ui1bool[4] = savedata.ui1bool4;
                dm.ui1bool[5] = savedata.ui1bool5;
                dm.ui1bool[6] = savedata.ui1bool6;
                dm.ui1bool[7] = savedata.ui1bool7;
                dm.ui1bool[8] = savedata.ui1bool8;
                dm.ui1bool[9] = savedata.ui1bool9;
                dm.ui1bool[10] = savedata.ui1bool10;
                dm.ui1bool[11] = savedata.ui1bool11;
                dm.ui1bool[12] = savedata.ui1bool12;
                dm.ui1bool[13] = savedata.ui1bool13;
                dm.ui1bool[14] = savedata.ui1bool14;
                dm.ui1bool[15] = savedata.ui1bool15;
                dm.ui1bool[16] = savedata.ui1bool16;
                dm.ui1bool[17] = savedata.ui1bool17;
                dm.ui1bool[18] = savedata.ui1bool18;
                dm.ui1bool[19] = savedata.ui1bool19;
                dm.ui1bool[20] = savedata.ui1bool20;
                dm.ui1bool[21] = savedata.ui1bool21;
                dm.ui1bool[22] = savedata.ui1bool22;
                dm.ui1bool[23] = savedata.ui1bool23;
                dm.ui1bool[24] = savedata.ui1bool24;
                dm.ui1bool[25] = savedata.ui1bool25;
                dm.ui1bool[26] = savedata.ui1bool26;
                dm.ui1bool[27] = savedata.ui1bool27;
                dm.ui1bool[28] = savedata.ui1bool28;
                dm.ui1bool[29] = savedata.ui1bool29;
                dm.ui1bool[30] = savedata.ui1bool30;
                dm.ui1bool[31] = savedata.ui1bool31;
                dm.ui1bool[32] = savedata.ui1bool32;

                pl.soul = savedata.plsoul;
                dm.moveset = savedata.moveset;
                dm.introset = savedata.introset;
            }
        }
    }
    public void Save()
    {
        SaveData savedata = new SaveData();
        savedata.codeonly1 = dm.codeonly[0];
        savedata.codeonly2 = dm.codeonly[1];

        savedata.uiopening1 = dm.uiopening[0];
        savedata.uiopening2 = dm.uiopening[1];
        savedata.uiopening3 = dm.uiopening[2];
        savedata.uiopening4 = dm.uiopening[3];

        savedata.ui1bool = dm.ui1bool[0];
        savedata.ui1bool1 = dm.ui1bool[1];
        savedata.ui1bool2 = dm.ui1bool[2];
        savedata.ui1bool3 = dm.ui1bool[3];
        savedata.ui1bool4 = dm.ui1bool[4];
        savedata.ui1bool5 = dm.ui1bool[5];
        savedata.ui1bool6 = dm.ui1bool[6];
        savedata.ui1bool7 = dm.ui1bool[7];
        savedata.ui1bool8 = dm.ui1bool[8];
        savedata.ui1bool9 = dm.ui1bool[9]; 
        savedata.ui1bool10= dm.ui1bool[10];
        savedata.ui1bool11= dm.ui1bool[11];
        savedata.ui1bool12= dm.ui1bool[12]; 
        savedata.ui1bool13= dm.ui1bool[13];
        savedata.ui1bool14= dm.ui1bool[14];
        savedata.ui1bool15= dm.ui1bool[15];
        savedata.ui1bool16= dm.ui1bool[16];
        savedata.ui1bool17= dm.ui1bool[17];
        savedata.ui1bool18= dm.ui1bool[18];
        savedata.ui1bool19= dm.ui1bool[19];
        savedata.ui1bool20= dm.ui1bool[20];
        savedata.ui1bool21 = dm.ui1bool[21];
        savedata.ui1bool22= dm.ui1bool[22];
        savedata.ui1bool23= dm.ui1bool[23];
        savedata.ui1bool24= dm.ui1bool[24];
        savedata.ui1bool25= dm.ui1bool[25];
        savedata.ui1bool26= dm.ui1bool[26];
        savedata.ui1bool27= dm.ui1bool[27];
        savedata.ui1bool28= dm.ui1bool[28];
        savedata.ui1bool29= dm.ui1bool[29];
        savedata.ui1bool30= dm.ui1bool[30];
        savedata.ui1bool31 = dm.ui1bool[31];
        savedata.ui1bool32 = dm.ui1bool[32];
        savedata.moveset = dm.moveset;
        savedata.introset = dm.introset; 

        savedata.plsoul = (int)pl.soul;

        string json = JsonUtility.ToJson(savedata, true);
        File.WriteAllText(path, json);
    }
}



