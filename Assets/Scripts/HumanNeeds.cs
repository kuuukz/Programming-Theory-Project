using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeds : Dialogue
{
    public override void Speech()
    {
        if (!humanQuest)
        {
            dialogueText.text = $"Hello {menuScript.PlayerName}! Could you bring me a pizza?";
            humanQuest = true;
            SpawnFood();
        }
        else if (humanQuest)
        {
            dialogueText.text = "I'm waiting for pizza.";
        }

        if (playerScript.gotPizza)
        {
            dialogueText.text = "Grazie mille! I like it!";
            playerScript.gotPizza = false;
            humanQuest = false;
            menuScript.AddPoint(1);
        }
    }
}


