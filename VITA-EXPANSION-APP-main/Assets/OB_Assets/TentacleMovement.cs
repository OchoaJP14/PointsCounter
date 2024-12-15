using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TentacleMovement : MonoBehaviour
{
    public Slider movementSlider;
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    // Define boundaries for the character's movement
    public float leftBoundary = -10f;
    public float rightBoundary = 58f;

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
        if (movementSlider != null)
        {

            float direction = -movementSlider.value;


            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            //boundaries
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
            transform.position = clampedPosition;


         
        }
    }
}
