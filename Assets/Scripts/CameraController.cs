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
       //playerTransform = GameObject.Find("Player").transform; //transformu bulma i�lemini bu �ekilde de yapabilirdik ancak performans d��er
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);//b�yle yaparsak kamera oyuncuyu takip eder
                                                                                                                 //ancak sahne s�n�rlar� olmad��� i�in d���ndaki alanlar� da ekranda g�sterir
        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, minX, maxX), transform.position.y, transform.position.z); //Clamp yard�m� ile s�n�rlar belirledik
    }
}
