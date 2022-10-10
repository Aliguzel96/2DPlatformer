using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeValue;
    [SerializeField] float time;
    private bool gameActive;

    void Start()
    {
        gameActive = true;
        timeValue.text = time.ToString();//ba�lang��taki time de�erini yazd�rd�k
    }

    // Update is called once per frame
    void Update()
    {

        if(gameActive == true)//s�re s�f�r olunca geriye do�ru say�yor ve animasyon tekrar tekrar oynat�l�yor bunu �nlemek i�in bu kontrol� sa�lad�k
        {
            time -= Time.deltaTime; //iki frame aras�ndaki ge�i� s�resi
            timeValue.text = ((int)time).ToString();//time de�erini float tan�mlamak zorunday�z ancak burada int'e �evirebiliriz

        }

        if (time < 0)
        {
            gameActive=false;
            GetComponent<PlayerController>().Die();
            time = 0;
            
        }
    }
}
