using UnityEngine;
using UnityEngine.UI;

public class SliderControlledMovement : MonoBehaviour
{
    public Slider movementSlider; 
    public float speed = 5f;      
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
        if (movementSlider != null)
        {
            // Get the slider value (-1 for left, 0 for stop, 1 for right)
            float direction = movementSlider.value;

            // Move the character
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            // Update character orientation
            if (direction > 0)
            {
               
                spriteRenderer.flipX = false;
            }
            else if (direction < 0)
            {
                
                spriteRenderer.flipX = true;
            }
            // When direction is 0, the character keeps its last orientation.
        }
    }
}



