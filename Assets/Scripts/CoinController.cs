using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    //private void Update()
    //{
    //    transform.Rotate(new Vector3(0f, 2f, 0));//her frame'de y ekseni etraf�nda 20 birim d�ns�n (coin i�in g�rsel zenginlik)

    //}

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 15f, 0));//her frame'de y ekseni etraf�nda 20 birim d�ns�n (coin i�in g�rsel zenginlik)
    }

    private void OnTriggerEnter2D(Collider2D collision)//coin'in IsTrigger'i a��k oldu�u i�in collider ile yakalayamay�z bu y�zden trigger kulland�k
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int score = int.Parse(scoreText.text);//skor text'ini int'e �evirip score de�i�kenine atad�k
            score += 50;
            scoreText.text = score.ToString();
            Destroy(gameObject);
        }
    }

}
