using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ldback : MonoBehaviour
{
    public float speed;
    public int startindex;
    public int endindex;
    public Transform[] sprits;
    public SpriteRenderer[] spritscolor;
    public float viewheight;

    private void Awake()
    {
        viewheight = Camera.main.orthographicSize * 3.5f;
    }

    void Update()
    {
        Move();
        Scrolling();
    }

    void Move()
    {
        Vector3 curpos = transform.position;
        Vector3 nextpos = Vector3.left * speed * Time.deltaTime;
        transform.position = curpos + nextpos;
    }

    void Scrolling()
    {
        
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
}
