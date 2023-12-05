using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public RectTransform maxpos;
    public RectTransform txtpos;

    void Update()
    {
        txtpos = maxpos;
    }
}
