using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))//çarptýðý nesne player deðilse

        {
            Destroy(gameObject);//oku yok et
                if(collision.gameObject.CompareTag("Enemy"))//çarptýðý nesne düþman ise
                    {
                        Destroy(collision.gameObject); //çarptýðý düsmaný yok et
                    }
        }
    }
}
