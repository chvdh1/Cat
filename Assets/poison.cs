using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    void Update()
    {
        if(gameObject.activeSelf)
        transform.Rotate(Vector3.forward * -10);
    }
    public void af()
    {
        gameObject.SetActive(false);
    }
}
