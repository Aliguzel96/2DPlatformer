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
    public bool onGround; //zemin �zerinde mi
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

        mySpeedX = Input.GetAxis("Horizontal");//-1 1 aras�nda de�er verir
        myAnimator.SetFloat("speed", Mathf.Abs(mySpeedX)); //Animator i�erisindeki speed de�eri ile ba�lant� kurduk.
                                                           //-> mutlak de�erini alarak h�z�n skaler d�erini ald�k ve direction �zelli�inden kurtulduk
                                                           //anim i�erisindeki speed parametresine "mySpeedX" de�erini verdik=
        myRigidbody.velocity = new Vector2(mySpeedX * speed, myRigidbody.velocity.y);
        jump();

        #region player'in y�nlere g�re v�cudunun d�nmesi
        if (mySpeedX > 0)//sa�a gidiyorsa y�n� ayn� kals�n
        {
            //transform.localScale = new Vector3(1f, 1f, 1f); -> 1,1,1 �eklinde kullan�lan vekt�rler bize dinamiklik kazand�rmaz
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (mySpeedX < 0)//sola gidiyorsa x ekesinin simetri�ini al�yoruzki karakter sola d�ns�n
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f); -> -1 ile x eksinin simetri�i
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        #endregion


        #region player'in ok atmas�



        if (Input.GetMouseButtonDown(0))
        {
            if (attacked == false)
            {
                attacked = true;
                myAnimator.SetTrigger("Attack");//atak animat�r�n� tetikledik
                Invoke("Fire", 0.5f);//Invoke fonks �al��mas�n� erteliyor (yar�m saniye eretelettik ��nk� animasyon ba�lamadan ok yerinden ��k�yordu

            }
        }

        #endregion

        #region art arda at��lar� engelleme ve at��lar aras�nda bir bekleme yapma
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


        if (transform.localScale.x > 0) //karakter sa�a hareket ediyorsa, ok da ayn� y�nde ��ks�n
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
        }
        else//karakter sola gidiyor, ok ta sola gitsin
        {
            //ok saola gidiyor ancak ucu sa�a bak�yor, bunu da d�zeltmemiz laz�m
            Vector3 okumuzScale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzScale.x, okumuzScale.y, okumuzScale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
        }


    }

    #region �l�m animasyonu

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }

    }

    void Die()
    {
        myAnimator.SetFloat("Speed", 0);//�l�nce h�z s�f�rlans�n
        myAnimator.SetTrigger("Die");//�l�m anim �al��s�n

        myRigidbody.constraints = RigidbodyConstraints2D.FreezePosition; //x ve y eksenlerindeki haraketleri d�nd�r

        enabled = false; //bu scripti etkisiz k�l (script i�erisinde sa� ve sola bas�nca karakter scale bazl� olarak d�n�yordu ve �l�m anim yar�m kal�yordu)
        
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
            else//iki defa �st �ste z�plama yapmak i�in: (karakter zeminde de�ilse, havada ise)
            {
                if (canDoubleJump == true)//�ift z�plamay� a�
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);//bir z�plama daha ekle
                    canDoubleJump = false;//daha fazla z�plama olmas�n diye double z�plamay� kapat 
                }
            }


        }



    }
    #endregion

}


