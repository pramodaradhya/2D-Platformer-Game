﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<playercontroller>() != null) 

        {
            playercontroller playercontroller = collision.gameObject.GetComponent<playercontroller>();
            playercontroller.Killplayer();
           
        }
    }
}
