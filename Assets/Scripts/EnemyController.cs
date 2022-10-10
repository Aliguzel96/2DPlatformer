using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] bool onGround;
    [SerializeField] float speed;
    private float width;
    private Rigidbody2D myBody;
    [SerializeField] LayerMask engel;//raycastin etkile�ime girmesini istedi�imiz layer'i belirledik
    private static int totalEnemyNumber = 0; //static anahtar kelimesi class'a ait bir de�i�keni simgeler, bu class'tan ka� tane obje t�redi�ini tutar
                                             //S�n�f ile ilgili say� i�lemlerini static ile yapabiliriz

    void Start()
    {

        width = GetComponent<SpriteRenderer>().bounds.extents.x; //mevcut sprite'�n k��elerinin aras�nda kalan x ekseninin yar�s�n� verir
                                                                 //Bu bize sprite'�n yar�s�n� bulmam�z i�in gerekecek ��nk� ���n� objenin en u� noktalar�na �izdirmemiz gerekiyor
                                                                 //mevcut i�lemle x ekseninin yar� �ap�n� ald�k �imdi de bu de�eri 2'ye b�lersek istedi�imiz sonuca ula�abiliriz

        myBody = GetComponent<Rigidbody2D>();
        totalEnemyNumber++;
        Debug.Log("Dusman ismi: " +gameObject.name + " olu�tu -" + " oyundaki toplam d��man say�s�: " + totalEnemyNumber);


    }


    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f);// Bu bize sprite'�n tam orjin noktas�ndan a�a��ya do�ru bir ���n verir
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2), Vector2.down, 2f, engel);//Bize laz�m olansa sprite'�n en u� noktas�nda �izdirmek
                                                                                                                   //orjin noktas�ndaki sprite in x ekseninin yar�s�n�n yar�s�n� ekle
        
        if(hit.collider != null)//herhangibir yere �arpm�yorsa
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        Flip();
        
    }

    private void OnDrawGizmos()//�izdirmek isted�imiz raycast ���n�n� sadece test ama�l� g�stermek i�in bu fonks. kullan�r�z
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -2f, 0));//iki parametre al�r (nereden nereye diye) --> bu orjin noktas�ndan �izdirir
        Vector3 playerRealPos = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(playerRealPos, playerRealPos + new Vector3(0, -2f, 0));


    }

    void Flip()
    {
        if (!onGround)//obje zemin �zerinde de�ilse
        {
            transform.eulerAngles += new Vector3(0, 180, 0);//y a��s�n� de�i�tir, b�ylelikle hit noktas� di�er uca gidiyor ve haraket sonsuzluk kazan�yor (s�rekli 180derece ekliyor)
        }
        myBody.velocity = new Vector2(transform.right.x * speed, 0);//sa� tarafa 5f kuvvetinde hareket
    }

}
