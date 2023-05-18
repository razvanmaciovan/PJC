using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurIdle : StateMachineBehaviour
{
    public float attackRange = 3f;

    Transform player;
    Rigidbody2D rb;
    MinotaurMovement boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<MinotaurMovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) >= 3*attackRange)
        {
            animator.SetTrigger("Charge");
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("NormalAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("Attack");
    }
}