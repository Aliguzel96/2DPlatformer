using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class arrowController : MonoBehaviour
{

    [SerializeField] GameObject effect;
    


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))//çarptýðý nesne player deðilse

        {
            Destroy(gameObject);//oku yok et
                if(collision.gameObject.CompareTag("Enemy"))//çarptýðý nesne düþman ise
             {

                Destroy(collision.gameObject); //çarptýðý düsmaný yok et

                GameObject.Find("LevelManager").GetComponent<levelManager>().AddScore(100);
                Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);//ölünce efekt çýksýn
               

            }
        }
    }

    private void OnBecameInvisible()//oyun içerisinde görünmez olduðu anda çalýþýr (oklar sahneden çýkýnca yok olsun)
    {
        Destroy(gameObject);
    }
}
