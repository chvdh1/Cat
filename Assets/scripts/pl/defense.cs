using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    public player pl;
    Collider2D box;
         

    void Awake()
    {
        box = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemybullet")
        {
            pl.atkdmg += 0.2f;
            pl.defcount = 2;
            StartCoroutine(defimcolf());
            pl.gm.defim.color = new Color(1, 1, 0, 1);
        }
    }
    IEnumerator defimcolf()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        pl.gm.defim.color = new Color(1, 1, 1, 1);
    }

}
