using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    public GameObject player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger'a girdi"); //zemine deðdi
        player.GetComponent<PlayerController>().onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)//trigger dan çýkýnca çalýþýr
    {
        //Debug.Log("Triggerdan çýktý"); //zemin üzerinde deðil (havada)
        player.GetComponent<PlayerController>().onGround = false;


    }
}
