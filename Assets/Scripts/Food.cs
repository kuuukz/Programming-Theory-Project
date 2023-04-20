using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Player playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Carrot")
        {
            Destroy(gameObject);
            playerScript.gotCarrot = true;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Cookie")
        {
            Destroy(gameObject);
            playerScript.gotCookie = true;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Pizza")
        {
            Destroy(gameObject);
            playerScript.gotPizza = true;
        }
    }
}
