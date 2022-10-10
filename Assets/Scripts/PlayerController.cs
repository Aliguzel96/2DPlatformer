using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float mySpeedX;
    private float mySpeedY;
    [SerializeField] float speed;
    private Rigidbody2D myRigidbody;
    [SerializeField] int jumpForce;
    private Vector3 defaultLocalScale;
    public bool onGround; //zemin üzerinde mi
    private bool canDoubleJump;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject arrowPoint;
    [SerializeField] bool attacked;
    private float currentAttackTimer;
    private float defaultAttackTimer;
    private Animator myAnimator;


    void Start()
    {
        attacked = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        defaultLocalScale = transform.localScale;
        currentAttackTimer = 0;
        defaultAttackTimer = 1;
        myAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        mySpeedX = Input.GetAxis("Horizontal");//-1 1 arasýnda deðer verir
        myAnimator.SetFloat("speed", Mathf.Abs(mySpeedX)); //Animator içerisindeki speed deðeri ile baðlantý kurduk.
                                                           //-> mutlak deðerini alarak hýzýn skaler dðerini aldýk ve direction özelliðinden kurtulduk
                                                           //anim içerisindeki speed parametresine "mySpeedX" deðerini verdik=
        myRigidbody.velocity = new Vector2(mySpeedX * speed, myRigidbody.velocity.y);
        jump();

        #region player'in yönlere göre vücudunun dönmesi
        if (mySpeedX > 0)//saða gidiyorsa yönü ayný kalsýn
        {
            //transform.localScale = new Vector3(1f, 1f, 1f); -> 1,1,1 þeklinde kullanýlan vektörler bize dinamiklik kazandýrmaz
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (mySpeedX < 0)//sola gidiyorsa x ekesinin simetriðini alýyoruzki karakter sola dönsün
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f); -> -1 ile x eksinin simetriði
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        #endregion


        #region player'in ok atmasý



        if (Input.GetMouseButtonDown(0))
        {
            if (attacked == false)
            {
                attacked = true;
                myAnimator.SetTrigger("Attack");//atak animatörünü tetikledik
                Invoke("Fire", 0.5f);//Invoke fonks çalýþmasýný erteliyor (yarým saniye eretelettik çünkü animasyon baþlamadan ok yerinden çýkýyordu

            }
        }

        #endregion

        #region art arda atýþlarý engelleme ve atýþlar arasýnda bir bekleme yapma
        if (attacked == true)
        {
            currentAttackTimer -= Time.deltaTime;
        }
        else
        {
            currentAttackTimer = defaultAttackTimer;
        }

        if (currentAttackTimer < 0)
        {
            attacked = false;
        }
        #endregion
    }
    void Fire()
    {
        GameObject okumuz = Instantiate(arrow, arrowPoint.transform.position, Quaternion.identity);


        if (transform.localScale.x > 0) //karakter saða hareket ediyorsa, ok da ayný yönde çýksýn
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
        }
        else//karakter sola gidiyor, ok ta sola gitsin
        {
            //ok saola gidiyor ancak ucu saða bakýyor, bunu da düzeltmemiz lazým
            Vector3 okumuzScale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzScale.x, okumuzScale.y, okumuzScale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
        }


    }

    #region ölüm animasyonu

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }

    }

    void Die()
    {
        myAnimator.SetFloat("Speed", 0);//ölünce hýz sýfýrlansýn
        myAnimator.SetTrigger("Die");//ölüm anim çalýþsýn

        myRigidbody.constraints = RigidbodyConstraints2D.FreezePosition; //x ve y eksenlerindeki haraketleri döndür

        enabled = false; //bu scripti etkisiz kýl (script içerisinde sað ve sola basýnca karakter scale bazlý olarak dönüyordu ve ölüm anim yarým kalýyordu)
        
    }

    #endregion




    #region Jump fonksiyonu
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround == true)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                canDoubleJump = true;
                myAnimator.SetTrigger("Jump");//jump animasyonunu set ettik
            }
            else//iki defa üst üste zýplama yapmak için: (karakter zeminde deðilse, havada ise)
            {
                if (canDoubleJump == true)//çift zýplamayý aç
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);//bir zýplama daha ekle
                    canDoubleJump = false;//daha fazla zýplama olmasýn diye double zýplamayý kapat 
                }
            }


        }



    }
    #endregion

}


