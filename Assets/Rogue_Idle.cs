using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue_Idle : StateMachineBehaviour
{
    private float timer = 0;
    private static int startHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        startHealth = animator.GetInteger("Health");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            animator.SetFloat("Speed", 0.1f);
        }

        if (animator.GetInteger("Health") < startHealth)
        {
            animator.SetTrigger("Dash");
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
