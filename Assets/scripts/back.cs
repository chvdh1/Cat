using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    public float speed;
    public int startindex;
    public int endindex;
    public GameManager gameManager;
    public Transform[] sprits;
    public SpriteRenderer[] spritscolor;
    public Sprite[] stagesprits;
    public bool stop;
   public float viewheight;


    public static back Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        viewheight = Camera.main.orthographicSize * 3.5f;
    }

    void Update()
    {
        if (gameManager.stage >= 1)
        {
            if(!stop)
            {
                Move();
                Scrolling();
            }
        }
            
    }

    void Move()
    {
        Vector3 curpos = transform.position;
        Vector3 nextpos = Vector3.left * speed * Time.deltaTime;
        transform.position = curpos + nextpos;
    }

    void Scrolling()
    {
        if (gameManager.data == null)
            return;

        

        if (sprits[endindex].position.x < viewheight * (-1))
        {
            Vector3 backspritepos = sprits[startindex].localPosition;
            sprits[endindex].transform.localPosition = backspritepos + Vector3.right * 6.7f;

            if (endindex < sprits.Length-1)
                endindex++;
            else
                endindex = 0;

            if (startindex < sprits.Length-1)
                startindex++;
            else
                startindex = 0;
        }
    }
    public void sprit()
    {
        if (gameManager.data.chapterindex == 2)
        {
            if (gameManager.stage >= 11)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.5f, 0.45f, 0.55f, 1);
            else if (gameManager.stage >= 6)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.6f, 0.6f, 0.2f, 1);
            else
                for (int i = 0; i < spritscolor.Length; i++)
                {
                    spritscolor[i].sprite = stagesprits[0];
                    spritscolor[i].color = new Color(1, 1, 1, 1);
                }
        }
        else if (gameManager.data.chapterindex == 3)
        {
            if (gameManager.stage >= 11)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.5f, 0.45f, 0.55f, 1);
            else if (gameManager.stage >= 6)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.6f, 0.6f, 0.2f, 1);
            else
                for (int i = 0; i < spritscolor.Length; i++)
                {
                    spritscolor[i].sprite = stagesprits[1];
                    spritscolor[i].color = new Color(1, 1, 1, 1);
                }
        }
        else if (gameManager.data.chapterindex == 4)
        {
            if (gameManager.stage >= 11)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.5f, 0.45f, 0.55f, 1);
            else if (gameManager.stage >= 6)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.6f, 0.6f, 0.2f, 1);
            else
                for (int i = 0; i < spritscolor.Length; i++)
                {
                    spritscolor[i].sprite = stagesprits[2];
                    spritscolor[i].color = new Color(1, 1, 1, 1);
                }
        }
        else if (gameManager.data.chapterindex == 5)
        {
            if (gameManager.stage >= 11)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.5f, 0.45f, 0.55f, 1);
            else if (gameManager.stage >= 6)
                for (int i = 0; i < spritscolor.Length; i++)
                    spritscolor[i].color = new Color(0.6f, 0.6f, 0.2f, 1);
            else
                for (int i = 0; i < spritscolor.Length; i++)
                {
                    spritscolor[i].sprite = stagesprits[3];
                    spritscolor[i].color = new Color(1, 1, 1, 1);
                }
        }

    }
}
