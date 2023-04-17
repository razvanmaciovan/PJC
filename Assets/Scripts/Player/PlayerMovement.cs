using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerCtrl;

    private const float initialSpeed = 40f;

    public float runSpeed = initialSpeed;
    public float dashSpeed;
    public float dashLength = .5f;
    public float dashCooldown = 1f;
    private float dashCounter, dashCoolCounter;

    float horizontalMove = 0f;
    
    bool jump   = false;
    bool crouch = false;

    // Update is called once per frame
    void Update() 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } 
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                runSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter < 0)
            {
                runSpeed = initialSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Move player
        playerCtrl.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
