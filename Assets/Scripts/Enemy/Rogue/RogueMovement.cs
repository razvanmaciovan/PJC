using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityTypes;

public class RogueMovement : MonoBehaviour
{
    public Animator animator;
    private Transform rogue;
    public bool isFlipped;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        rogue = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString()).transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Health", enemyController.CurrentHitPoints);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < rogue.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > rogue.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
