using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float dmg;
    public float speed;
    public int bulletint;
    public int maxfollowint, followint, followdel, followf;
    public bool stopbullet;
    public bool notf;
    public bool poison;
    public bool slow;
    public bool rotate;
    public Vector2 pos;
    public Transform target;
    Rigidbody2D rg;
    
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.forward * -10);

        if(bulletint == 3 && gameObject.activeSelf && gameObject.transform.position.y < pos.y)
        {
            gameObject.SetActive(false);
            rg.velocity = new Vector2(0, 0);
        }
           
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8||
            collision.gameObject.tag == "Player"||
            collision.gameObject.tag == "boom"||
             collision.gameObject.tag == "def")
        {
            bulletReset();

       }
        if (collision.gameObject.layer == 8)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            followint = 0;
            gameObject.SetActive(false);
        }

    }
    private void bulletReset()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        followint = 0;
        if (bulletint == 0)
        {
            gameObject.SetActive(false);
            transform.localScale = new Vector3(1, 0.2f, 1);
        }
        else if (bulletint == 1)
        {
            if(!notf)
            gameObject.SetActive(false);
        }

    }
    public IEnumerator follow()
    {
        yield return new WaitForSeconds(1);
        while(followint < maxfollowint)
        {
            Vector2 dieVec = target.transform.position - transform.position;
            rg.velocity = dieVec.normalized * speed;

            followint++;
            yield return new WaitForSeconds(followdel);
        }
        yield return new WaitForSeconds(followf);
        gameObject.SetActive(false);
    }
}


