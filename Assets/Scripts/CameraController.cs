using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
       //playerTransform = GameObject.Find("Player").transform; //transformu bulma iþlemini bu þekilde de yapabilirdik ancak performans düþer
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);//böyle yaparsak kamera oyuncuyu takip eder
                                                                                                                 //ancak sahne sýnýrlarý olmadýðý için dýþýndaki alanlarý da ekranda gösterir
        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, minX, maxX), transform.position.y, transform.position.z); //Clamp yardýmý ile sýnýrlar belirledik
    }
}
