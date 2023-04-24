using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour // INHERITANCE (PARENT)
{
    public GameObject text;
    public TextMeshProUGUI dialogueText;

    public GameObject food;
    public Player playerScript;
    public Menu menuScript;

    public bool horseQuest;
    public bool chickenQuest;
    public bool humanQuest;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        menuScript = GameObject.Find("MenuManager").GetComponent<Menu>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            Speech(); // ABSTRACTION
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }

    public virtual void Speech()
    {
        dialogueText.text = "text";
    }

    public void SpawnFood()
    {
        Instantiate(food, GenerateRandomPosition(), transform.rotation);
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 spawnPosition = new Vector3(RandomPositionX(), 0, RandomPositionZ());
        return spawnPosition;
    }

    float RandomPositionX()
    {
        float spawnRangeX = 9;
        float positionX = Random.Range(spawnRangeX, -spawnRangeX);
        return positionX;
    }

    float RandomPositionZ()
    {
        float spawnRangeZ = 2;
        float positionZ = Random.Range(spawnRangeZ, -spawnRangeZ);
        return positionZ;
    }
}
