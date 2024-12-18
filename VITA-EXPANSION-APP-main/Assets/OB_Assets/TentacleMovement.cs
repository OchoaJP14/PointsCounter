using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TentacleMovement : MonoBehaviour
{
    public float speed = 5f;
    private int direction = -1;
    private bool isStopped = false;

    public float leftBoundary = -10f;
    public float rightBoundary = 58f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!isStopped)
            {

                direction *= -1;
            }
        }


        if (Input.GetMouseButton(0))
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }


        if (!isStopped)
        {
            Vector3 newPosition = transform.position + Vector3.right * direction * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);
            transform.position = newPosition;

        }
    }
}
