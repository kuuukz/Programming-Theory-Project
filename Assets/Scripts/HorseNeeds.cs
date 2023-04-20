using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseNeeds : Dialogue
{
    public override void Speech()
    {
        if (!horseQuest)
        {
            dialogueText.text = $"Hello {menuScript.PlayerName}! Could you bring me a carrot?";
            horseQuest = true;
            SpawnFood();
        }
        else if (horseQuest)
        {
            dialogueText.text = "I'm waiting for carrot.";
        }

        if (playerScript.gotCarrot)
        {
            dialogueText.text = "Thank you! It's so yummy!";
            playerScript.gotCarrot = false;
            horseQuest = false;
            menuScript.AddPoint(1);
        }
    }
}
