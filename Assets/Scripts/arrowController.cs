using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))//�arpt��� nesne player de�ilse

        {
            Destroy(gameObject);//oku yok et
                if(collision.gameObject.CompareTag("Enemy"))//�arpt��� nesne d��man ise
                    {
                        Destroy(collision.gameObject); //�arpt��� d�sman� yok et
                    }
        }
    }
}
