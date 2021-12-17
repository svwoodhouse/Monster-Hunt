using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(audio.gameObject);
            Destroy(gameObject, 0.1f);
        }
    }
}
