using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Position_Move : MonoBehaviour
{
    [SerializeField] private Vector2[] pointsArray = new Vector2[0];
    [SerializeField] private bool inactive;
    [SerializeField] private bool behaviorType = false;
    [SerializeField] private float speed = 10.0f;
    private int currentLocation;

    private void Start()
    {
        if (!inactive)
        {
            if (behaviorType!)
            {
                //StartCoroutine
            }
            else
            {
                //iterate through Vector2 array of positions then iterate backwards.
            }
        }
        else
        {
            // stop moving
        }
    }

    public void Activate()
    {
        inactive = !inactive;
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoopMovement()
    {
        if (behaviorType == true)
        {
            if (inactive)
            {
                yield return ReverseMovement();
            }
            if (!inactive)
            {
                yield return ForwardMovement();
            }
        }

        //if (pointsArray[pointsArray.Length-1] == pointsArray[currentLocation] || pointsArray[0] == pointsArray[currentLocation])
    }
    IEnumerator ForwardMovement()
    {
        float step = speed * Time.deltaTime;
        //moves up in array
        for (int i = currentLocation; i< pointsArray.Length;  i++)
        {
            //transform.position = Vector2.MoveTowards()
        }
        yield return null;

    }
    IEnumerator ReverseMovement()
    {
        //moves down in array
        for (int i = currentLocation; i > 0; i--)
        {

        }
        yield return null;
    }

}
