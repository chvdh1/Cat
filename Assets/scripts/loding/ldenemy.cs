using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ldenemy : MonoBehaviour
{
    public Transform[] pos;
    public int x;
    public int sp;
    public int sc;
    Rigidbody2D rg;
    SpriteRenderer sprit;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sprit = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rg.velocity = new Vector2(sp * (-1)+(-1), 0);
        if (transform.position.x <= x)
        {
            int ran = Random.Range(0, 7);
            sc = Random.Range(2, 5);
            gameObject.transform.localScale = new Vector2(sc, sc);
            gameObject.transform.position = pos[ran].position;
            sp = Random.Range(3, 8);
            if (ran ==3)
                sprit.sortingOrder = 10;
            else if (ran == 4)
                sprit.sortingOrder = 11;
            else if (ran == 5)
                sprit.sortingOrder = 12;
            else if (ran == 6)
                sprit.sortingOrder = 13;
            else
                sprit.sortingOrder = 0;
        }
    }
}
