using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private int playerscore;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("OpenChest");
            Destroy(gameObject, 0.5f);
        }
    }
}
