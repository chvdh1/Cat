using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int[] wphasset;
    public float wpattackspeed;
    public float wpBoomcooldown;
    public float wpCri;
    public float wpCridmg;
    public float wpgetper;
    public float wphealper;
    public float wpmaxlife;
    public float wplife;
    public float wppower;
    public float wpperpower;
    public float wpspeed;
    public float wpshotspeed;
    public float wpdefense;



    public enum Type { coin, churoo, soul, heal, wood, br, sv, gd ,weapon, normal, Rare, unique, Legendary };
    public Type type;
    public int typeint;
    public string vltype;
    public string weaponname;
    public string weaponinformation;
    public int velue;
    public float speed;
    public bool onlyone;
    public GameObject target;
    public bool targeting;
    public bool box;
    public bool weapon;
    public int weaponpos;
    public int thiscoin;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        onlyone = true;
    }

    void OnEnable()
    {
        if(!targeting && !weapon)
        {
            rigid.velocity = Vector2.left * speed * 2;
        }
        
        onlyone = true;

        if (targeting && !box && !weapon)
            StartCoroutine(findtarge());
        
    }

    IEnumerator findtarge()
    {
        yield return new WaitForSeconds(0.5f);
      
        Vector3 curpos = new Vector3(transform.position.x, transform.position.y,0);
        Vector3 nextpos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        rigid.velocity = (nextpos - curpos).normalized*speed*3;
        StartCoroutine(findtarge());
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
        }     
    }

   

}
