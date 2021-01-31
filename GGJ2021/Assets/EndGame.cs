using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : InteractableObject
{
    bool gameHasEnded = false;

    public void End()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Application.Quit();
        }
        
    }

    public override void Interact()
    {
        End();
    }
}
