using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundmanager : MonoBehaviour
{
    public static soundmanager Instance;
    public Text[] txt;
    public AudioSource[] backgroundmusic;
    public AudioSource[] efmusic;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void backgroundmusicvolume(float volume)
    {
        backgroundmusic[0].volume = volume;
        if(volume<=0)
            txt[0].color = new Color(0, 0, 0, 0.5f);
        
        else
            txt[0].color = new Color(1, 1, 1, 1);
    }
    public void efmusicmusicvolume(float volume)
    {
        efmusic[0].volume = volume;
        if (volume <= 0)
            txt[1].color = new Color(0, 0, 0, 0.5f);

        else
            txt[1].color = new Color(1, 1, 1, 1);
    }
}
