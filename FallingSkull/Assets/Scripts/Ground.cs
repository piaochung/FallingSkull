using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Block")
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Item")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
