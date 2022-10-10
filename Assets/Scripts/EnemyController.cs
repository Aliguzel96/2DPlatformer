using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] bool onGround;
    [SerializeField] float speed;
    private float width;
    private Rigidbody2D myBody;
    [SerializeField] LayerMask engel;//raycastin etkileþime girmesini istediðimiz layer'i belirledik
    private static int totalEnemyNumber = 0; //static anahtar kelimesi class'a ait bir deðiþkeni simgeler, bu class'tan kaç tane obje türediðini tutar
                                             //Sýnýf ile ilgili sayý iþlemlerini static ile yapabiliriz

    void Start()
    {

        width = GetComponent<SpriteRenderer>().bounds.extents.x; //mevcut sprite'ýn köþelerinin arasýnda kalan x ekseninin yarýsýný verir
                                                                 //Bu bize sprite'ýn yarýsýný bulmamýz için gerekecek çünkü ýþýný objenin en uç noktalarýna çizdirmemiz gerekiyor
                                                                 //mevcut iþlemle x ekseninin yarý çapýný aldýk þimdi de bu deðeri 2'ye bölersek istediðimiz sonuca ulaþabiliriz

        myBody = GetComponent<Rigidbody2D>();
        totalEnemyNumber++;
        Debug.Log("Dusman ismi: " +gameObject.name + " oluþtu -" + " oyundaki toplam düþman sayýsý: " + totalEnemyNumber);


    }


    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f);// Bu bize sprite'ýn tam orjin noktasýndan aþaðýya doðru bir ýþýn verir
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2), Vector2.down, 2f, engel);//Bize lazým olansa sprite'ýn en uç noktasýnda çizdirmek
                                                                                                                   //orjin noktasýndaki sprite in x ekseninin yarýsýnýn yarýsýný ekle
        
        if(hit.collider != null)//herhangibir yere çarpmýyorsa
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        Flip();
        
    }

    private void OnDrawGizmos()//Çizdirmek istedðimiz raycast ýþýnýný sadece test amaçlý göstermek için bu fonks. kullanýrýz
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -2f, 0));//iki parametre alýr (nereden nereye diye) --> bu orjin noktasýndan çizdirir
        Vector3 playerRealPos = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(playerRealPos, playerRealPos + new Vector3(0, -2f, 0));


    }

    void Flip()
    {
        if (!onGround)//obje zemin üzerinde deðilse
        {
            transform.eulerAngles += new Vector3(0, 180, 0);//y açýsýný deðiþtir, böylelikle hit noktasý diðer uca gidiyor ve haraket sonsuzluk kazanýyor (sürekli 180derece ekliyor)
        }
        myBody.velocity = new Vector2(transform.right.x * speed, 0);//sað tarafa 5f kuvvetinde hareket
    }

}
