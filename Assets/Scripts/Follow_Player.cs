using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
  [SerializeField] private Transform player;
  [SerializeField] private float cameraSpeed = 0.125f;
  [SerializeField] private Vector3 offset;

  void FixedUpdate () 
  {
    Vector3 desiredPosition = player.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
    transform.position = smoothedPosition;
  }
}
