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
    //    transform.Rotate(new Vector3(0f, 2f, 0));//her frame'de y ekseni etrafýnda 20 birim dönsün (coin için görsel zenginlik)

    //}

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 15f, 0));//her frame'de y ekseni etrafýnda 20 birim dönsün (coin için görsel zenginlik)
    }

    private void OnTriggerEnter2D(Collider2D collision)//coin'in IsTrigger'i açýk olduðu için collider ile yakalayamayýz bu yüzden trigger kullandýk
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int score = int.Parse(scoreText.text);//skor text'ini int'e çevirip score deðiþkenine atadýk
            score += 50;
            scoreText.text = score.ToString();
            Destroy(gameObject);
        }
    }

}
