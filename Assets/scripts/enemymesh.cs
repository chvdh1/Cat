using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymesh : MonoBehaviour
{
    CapsuleCollider2D box;
    public GameObject enemyobj;
    enemy enemy;
    Rigidbody2D rg;


    private void Awake()
    {
        enemy = enemyobj.GetComponent<enemy>();
        box = GetComponent<CapsuleCollider2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int enemypoint = Random.Range(0, 9);
        transform.rotation = Quaternion.identity;
        transform.position = enemy.gm.spawn1points[enemypoint].position;
        if (enemypoint == 5 || enemypoint == 6)
            rg.velocity = new Vector2(enemy.speed * (-1), -0.5f);
        else if (enemypoint == 7 || enemypoint == 8)
            rg.velocity = new Vector2(enemy.speed * (-1), 0.5f);
        else
            rg.velocity = new Vector2(enemy.speed * (-1), 0);
    }
}
