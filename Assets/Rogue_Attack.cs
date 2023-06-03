using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue_Attack : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    RogueMovement rogue;
    private static int startHealth = -1;
    public float attackRange = 1f;
    public float Speed = 3f;

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
        rogue.LookAtPlayerRogue();
        var target = new Vector2(player.position.x, rb.position.y);
        var newPos = Vector2.MoveTowards(rb.position, target, Speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
