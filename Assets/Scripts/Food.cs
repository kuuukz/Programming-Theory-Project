using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Player playerScript;

    private MeshRenderer foodMesh;
    private AudioSource foodAudio;
    [SerializeField] AudioClip foodPicking;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        foodMesh = GetComponent<MeshRenderer>();
        foodAudio = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Carrot")
        {
            foodAudio.PlayOneShot(foodPicking, 1.0f);
            Destroy(gameObject, 0.1f);
            playerScript.gotCarrot = true;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Cookie")
        {
            foodAudio.PlayOneShot(foodPicking, 1.0f);
            Destroy(gameObject, 0.1f);
            playerScript.gotCookie = true;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Pizza")
        {
            foodAudio.PlayOneShot(foodPicking, 1.0f);
            Destroy(gameObject, 0.1f);
            playerScript.gotPizza = true;
        }
    }
}
