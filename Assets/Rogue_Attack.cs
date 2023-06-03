using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue_Attack : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    RogueMovement rogue;
    private static int startHealth = -1;
    public float attackRange = 3f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        rogue = animator.GetComponent<RogueMovement>();
        startHealth = animator.GetInteger("Health");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //rogue.LookAtPlayerRogue();

        if (animator.GetInteger("Health") < startHealth && Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Dash");
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
