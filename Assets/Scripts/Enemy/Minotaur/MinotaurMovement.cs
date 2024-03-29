using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityTypes;

public class MinotaurMovement : MonoBehaviour
{
    public Animator animator;
    private Transform player;
    public bool isFlipped;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        player = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString()).transform;
    }

    // Update is called once per frame
    void Update()
    {
        // set speed in animator
        // animator.SetFloat("Speed", Mathf.Abs(horizontalMoveSpeed));
        // tell animator if minotaur is attacking
        //animator.SetBool("b_Attack1", b_Attack1);
        //animator.SetBool("b_Charge", b_Charge);
        //animator.SetBool("b_Spin", b_Spin);
        //animator.SetBool("b_Stab", b_Stab);
        //animator.SetBool("b_Stomp", b_Stomp);
        // set health of minotaur in animator
        animator.SetInteger("Health", enemyController.CurrentHitPoints);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Stomp()
    {
        CameraShake.Instance.ShakeCamera(4f,0.2f);
        //TODO Deal damage to player if he collides with the ground
        if (player.GetComponent<PlayerController>().m_Grounded)
        {
            player.GetComponent<PlayerController>().TakeDamage(enemyController.CalculateDamageToPlayer());
        }
    }
}
