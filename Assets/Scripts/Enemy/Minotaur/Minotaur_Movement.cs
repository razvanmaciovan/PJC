using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Movement : MonoBehaviour
{
    public Animator animator;
    public float horizontalMoveSpeed;
    public float health = 100;
    public bool b_Attack1   = false;
    public bool b_Charge    = false;
    public bool b_Spin      = false;
    public bool b_Stab      = false;
    public bool b_Stomp     = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // set speed in animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoveSpeed));
        // tell animator if minotaur is attacking
        animator.SetBool("b_Attack1", b_Attack1);
        animator.SetBool("b_Charge", b_Charge);
        animator.SetBool("b_Spin", b_Spin);
        animator.SetBool("b_Stab", b_Stab);
        animator.SetBool("b_Stomp", b_Stomp);
        // set health of minotaur in animator
        animator.SetFloat("Health", Mathf.Abs(health));
    }
}
