using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class datamanager : MonoBehaviour
{
    public static datamanager Instance;
    public jsondata jsondata;
    public GameManager gm;
    public float[] mainbool;
    public bool[] uiopening;
    public bool[] ui1bool;
    public bool[] codeonly;
    public bool moveset;
    public bool introset;
    public bool[] stage;
    public bool[] tutorial;
    public int chapterindex;
    //soul 값은 플레이어에게 직접
    public int[] plbuff;

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
   
}



