using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;          
    private int direction = -1;     
    private bool isStopped = false;  

    public float leftBoundary = 0f; 
    public float rightBoundary = 68f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            UnityEngine.Debug.LogError("SpriteRenderer not found on the character!");
        }
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

        
        isStopped = Input.GetMouseButton(0);

        
        if (!isStopped)
        {
            Vector3 newPosition = transform.position + Vector3.right * direction * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);
            transform.position = newPosition;

            
            spriteRenderer.flipX = direction == -1;
        }
    }
}

