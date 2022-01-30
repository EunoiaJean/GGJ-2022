using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Behavior : MonoBehaviour
{
    public void Activate()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_Movement playerM = other.gameObject.GetComponent<Player_Movement>();
            playerM.Alive = false;
        }
    }
}
