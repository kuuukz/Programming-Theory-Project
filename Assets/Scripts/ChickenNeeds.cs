using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNeeds : Dialogue // INHERITANCE (CHILD)
{
    public override void Speech() // POLYMORPHISM
    {
        if (!chickenQuest)
        {
            dialogueText.text = $"Hello {menuScript.PlayerName}! Could you bring me a cookie?";
            chickenQuest = true;
            SpawnFood();
        }
        else if (chickenQuest)
        {
            dialogueText.text = "I'm waiting for cookie.";
        }

        if (playerScript.gotCookie)
        {
            dialogueText.text = "Thank you! It's delicious!";
            playerScript.gotCookie = false;
            chickenQuest = false;
            menuScript.AddPoint(1);
            Jump();
        }
    }

    void Jump()
    {
        Rigidbody chickenRb;
        chickenRb = GetComponentInParent<Rigidbody>();
        float jumpForce = 300;
        chickenRb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
    }
}
