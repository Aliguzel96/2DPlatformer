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
        timeValue.text = time.ToString();//baþlangýçtaki time deðerini yazdýrdýk
    }

    // Update is called once per frame
    void Update()
    {

        if(gameActive == true)//süre sýfýr olunca geriye doðru sayýyor ve animasyon tekrar tekrar oynatýlýyor bunu önlemek için bu kontrolü saðladýk
        {
            time -= Time.deltaTime; //iki frame arasýndaki geçiþ süresi
            timeValue.text = ((int)time).ToString();//time deðerini float tanýmlamak zorundayýz ancak burada int'e çevirebiliriz

        }

        if (time < 0)
        {
            gameActive=false;
            GetComponent<PlayerController>().Die();
            time = 0;
            
        }
    }
}
