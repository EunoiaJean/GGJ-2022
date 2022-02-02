using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform_Behavior : MonoBehaviour
{
    [SerializeField] private Vector2[] pointsArray = new Vector2[0];
    [SerializeField] private bool inactive;
    [SerializeField] [Range(1,2)] private int behaviorType = 1;
    [SerializeField] private float speed = 0.1f;
    private int arrayLocation = 0;

    private void Start()
    {
        if(pointsArray != null || pointsArray.Length >= 2)
        {
            if (behaviorType == 1)
            {
                StartCoroutine(BehaviorOne());
            }
            else
            {
                StartCoroutine(BehaviorTwo());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(gameObject.transform,true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }

    public void Activate()
    {
        inactive = !inactive;
    }

    IEnumerator BehaviorOne()
    {
        while (true)
        {
            for (int i = arrayLocation; i < pointsArray.Length; i++)
            {
                while (Vector2.Distance(transform.position, pointsArray[i]) > 0.01f)
                {
                    // interrupt
                    while (inactive)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    transform.position = Vector2.MoveTowards(transform.position, pointsArray[i], speed);
                    arrayLocation = i;
                    yield return new WaitForFixedUpdate();
                }
            }

            yield return StartCoroutine(ReverseMovementOne());   
        }

    }
    IEnumerator ReverseMovementOne()
    {

        for (int i = pointsArray.Length-1; i >= 0; i--)
        {
            while (Vector2.Distance(transform.position, pointsArray[i]) > 0.01f)
            {
                //interrupt
                while (inactive)
                {
                    yield return new WaitForFixedUpdate();
                }

                transform.position = Vector2.MoveTowards(transform.position, pointsArray[i], speed);
                arrayLocation = i;
                yield return new WaitForFixedUpdate();
            }
        }
    }

    IEnumerator BehaviorTwo()
    {
        while (true)
        {

            for (int i = arrayLocation; i < pointsArray.Length; i ++)
            {
                while (Vector2.Distance(transform.position, pointsArray[i]) > 0.01f)
                {
                    if (inactive)
                    {
                        break;
                    }
                    transform.position = Vector2.MoveTowards(transform.position, pointsArray[i], speed);
                    yield return new WaitForFixedUpdate();
                }


                if (inactive)
                {
                    break;
                }

                arrayLocation = i;

            }

            if (inactive)
            {
                yield return StartCoroutine(ReverseMovementTwo());
            }
            yield return new WaitForFixedUpdate();   
        }

    }

    IEnumerator ReverseMovementTwo()
    {
        //moves down in array
        for (int i = arrayLocation; i >= 0; i--)
        {
            while (Vector2.Distance(transform.position, pointsArray[i]) > 0.01f)
            {
                if (!inactive)
                {
                    break;
                }
                transform.position = Vector2.MoveTowards(transform.position, pointsArray[i], speed);
                yield return new WaitForFixedUpdate();
            }


            if (!inactive)
            {
                break;
            }
            arrayLocation = i;
        }
        yield return null;
    }
}
