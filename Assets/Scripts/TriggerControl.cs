using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    public GameObject player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger'a girdi"); //zemine de�di
        player.GetComponent<PlayerController>().onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)//trigger dan ��k�nca �al���r
    {
        //Debug.Log("Triggerdan ��kt�"); //zemin �zerinde de�il (havada)
        player.GetComponent<PlayerController>().onGround = false;


    }
}
