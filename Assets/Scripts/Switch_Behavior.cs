using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch_Behavior : MonoBehaviour
{
    //[SerializeReference] private GameObject[] activatables = new GameObject[0];
    [SerializeField] private UnityEvent action;
    [SerializeField] private bool repeatable;
    private bool switched = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (repeatable || switched != true)
        {
            if (other.gameObject.tag == "Player")
            {
                action.Invoke();
                switched = true;
            }
        }

    }
    private void Awake()
    {
        if(action == null)
        {
            action = new UnityEvent();
        }
    }
}
