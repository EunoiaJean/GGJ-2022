using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Collision : MonoBehaviour
{
    Player_Movement playerM;
    bool enteredAlive;
    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerM = other.gameObject.GetComponentInParent<Player_Movement>();
            enteredAlive = playerM.Alive;
            if (enteredAlive)
            {
                playerM.Alive = false;
            }
        }
    }
    private void OnTriggerExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!enteredAlive && playerM.Alive == false)
            {
                playerM.Alive = true;
                playerM.controller.doubleJump = 1;
            }
        }
    }
}
