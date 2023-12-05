using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeram : MonoBehaviour
{
    public player pl;
    public Collider2D box;

    public void offboomeffect()
    {
        pl.isbooming = false;
        pl.Boom = pl.Boomcooldown;
        pl.StartCoroutine(pl.boomEffect());
        pl.StartCoroutine(pl.txt());
    }
    public void offdefeffect()
    {
        pl.isdef = false;
        pl.defcol = pl.defcooldown;
        pl.StartCoroutine(pl.defEffect());
        pl.StartCoroutine(pl.txt());
    }
    public void offatkeffect()
    {
        pl.isatk = false;
        pl.atkcol = pl.atkcooldown;
        pl.StartCoroutine(pl.atkEffect());
        pl.StartCoroutine(pl.txt());
    }
    public void setactf()
    {
        gameObject.SetActive(false);
    }
    public void colin()
    {
        box.enabled = true;
    }
    public void colout()
    {
        box.enabled = false;
        pl.playeran.SetTrigger("doboomend");
        offboomeffect();
    }
    
}
