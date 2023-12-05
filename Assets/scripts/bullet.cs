using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bullet : MonoBehaviour
{
    public float bulletdmg;
    public bool isRotate;
    public bool weapon2;
    public int num;
    public bool active = false;
    public GameObject obj;

    public void objtrue()
    {
        obj.SetActive(true);
        bullet logic = obj.GetComponent<bullet>();
        if(weapon2)
        {
            logic.weapon2 = true;
        }
    }


    private void FixedUpdate()
    {if(!isRotate)
        {
            transform.Rotate(Vector3.forward * -10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
            active = false;
            weapon2 = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}

