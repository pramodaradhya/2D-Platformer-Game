using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycontroller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
#pragma warning disable CS0642 // Possible mistaken empty statement
        if (collision.gameObject.GetComponent<playercontroller>() != null);
#pragma warning restore CS0642 // Possible mistaken empty statement
        {
            playercontroller playercontroller = collision.gameObject.GetComponent<playercontroller>();
            playercontroller.PickUpKey();
            Destroy(gameObject);
            }
    }
}
