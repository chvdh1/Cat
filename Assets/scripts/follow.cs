using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour


{
    public float maxShotDelay;
    public float curShotDelay;
    public ObjectManager objectmanager;

    public Vector3 followpos;
    public int followdelay;
    public Transform parent;
    public Queue<Vector3> parentpos;

    // Update is called once per frame

    void Awake()
    {
        parentpos = new Queue<Vector3>();
    }

    void Update()

    {
        watch();
        Follow();
        Fire();
        Reload();

    }
    void watch()
    {
        //Queue = QFIFO (first input first out)
        //input pos
        if(!parentpos.Contains(parent.position))
        parentpos.Enqueue(parent.position);


        //output pos
        if (parentpos.Count > followdelay)
            followpos = parentpos.Dequeue();

        else if (parentpos.Count < followdelay)
            followpos = parent.position;
    }

    void Follow()
    {
        transform.position = followpos;
    }
    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (curShotDelay < maxShotDelay)
            return;

       
                GameObject bullet = objectmanager.MakeObj("followbullet");
                bullet.transform.position = transform.position;
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        curShotDelay = 0;
    }



    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

}
