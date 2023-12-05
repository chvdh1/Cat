using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    Animator anim;
     void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Invoke("disable", 2f);
    }
    void disable()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void startexplosion(string target)
    {
        anim.SetTrigger("onexplosion");

        switch(target)
        { 
                    
            case "S":
            case "F":
                transform.localScale = Vector3.one * 0.7f;
                break;

            case "M":
            case "P":
                transform.localScale = Vector3.one * 1f;
                break;

            case "L":
                transform.localScale = Vector3.one * 2f;
                break;

            case "B":
                transform.localScale = Vector3.one * 3f;
                break;
        }
    }
}
