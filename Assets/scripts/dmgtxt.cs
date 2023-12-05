using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dmgtxt : MonoBehaviour
{
    public float movespeed;
    TextMeshPro text;
    public Color alpha;
    public int randmgtxt;
    

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
         alpha = text.color;
        
    }
 

    void Update()
    {
        text.text = randmgtxt.ToString();
        transform.Translate(new Vector2(0, movespeed * Time.deltaTime));
        text.color = alpha;
    }
     
    public void setf()
    {
        gameObject.SetActive(false);
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            alpha.a = 1;
            gameObject.SetActive(false);
        }
    }
    
}
