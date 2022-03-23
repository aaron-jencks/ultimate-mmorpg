using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public bool collision = false;
    
    public float horizontal;
    public float vertical;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void onTriggerEnter2D(Collider2D col) {
        collision = true;
    }

    private void onTriggerExit2D(Collider2D col) {
        collision = false;
    }

    private void FixedUpdate() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0) {
            float newRotation = 0f;
            if(horizontal > 0) {
                if(vertical > 0) {
                    newRotation = -45;
                } else if(vertical < 0) {
                    newRotation = -135;
                } else {
                    newRotation = -90;
                }
            } else if(horizontal < 0) {
                if(vertical > 0) {
                    newRotation = 45;
                } else if(vertical < 0) {
                    newRotation = 135;
                } else {
                    newRotation = 90;
                }
            } else if(vertical < 0) {
                newRotation = 180;
            }
            
            Vector3 eulerAngles = new Vector3(0, 0, newRotation);
            transform.eulerAngles = eulerAngles;
        }

        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }
}
