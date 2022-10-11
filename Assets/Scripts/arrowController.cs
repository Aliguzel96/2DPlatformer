using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class arrowController : MonoBehaviour
{

    [SerializeField] GameObject effect;
    


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))//�arpt��� nesne player de�ilse

        {
            Destroy(gameObject);//oku yok et
                if(collision.gameObject.CompareTag("Enemy"))//�arpt��� nesne d��man ise
             {

                Destroy(collision.gameObject); //�arpt��� d�sman� yok et

                GameObject.Find("LevelManager").GetComponent<levelManager>().AddScore(100);
                Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);//�l�nce efekt ��ks�n
               

            }
        }
    }

    private void OnBecameInvisible()//oyun i�erisinde g�r�nmez oldu�u anda �al���r (oklar sahneden ��k�nca yok olsun)
    {
        Destroy(gameObject);
    }
}
