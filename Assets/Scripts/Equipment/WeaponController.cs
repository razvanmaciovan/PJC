using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityTypes;

public class WeaponController : MonoBehaviour
{
[Header("Modifiables values")]

    private GameObject _particles;
    private int _damage = 1;
    private float _delay;
    private Animator anim;
    private Animator swingParticles;
    private AudioSource sound;
    private float nextAttack;
    private bool isHit;
    public bool canAttack = true;

    void Start()
    {
        //swingParticles = Particles.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        SetVolume();
    }

    public void Init(WeaponScriptableObject weapon, bool attack = true)
    {
        anim = gameObject.GetComponent<Animator>();
        _damage = weapon.Damage;
        _delay = weapon.Delay;
        anim.runtimeAnimatorController = weapon.AnimatorController;
        canAttack = attack;
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack)
        {
            Attack();
        }
    }
   

    //Attack animation
    private void Attack()
    {       
        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                //sound.Play();
                nextAttack = Time.time + _delay;               
            }
        }      
    }
    
    /// <summary>
    /// Event to be called from the weapon animations
    /// </summary>
    private void PlayParticles()
    {
        //swingParticles.SetTrigger("Swing");
        //if(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().hasParticles == true)
        //swingParticles.Play("Swoosh");
    }
    private void SetVolume()
    {
        sound.volume = PlayerPrefs.GetFloat("volume");
    }

    //Detects collision with Enemies
    //Deals damage according to the Player level
    //Triggers the hit animations from enemies.
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy") && isHit == false)
        {
            sound.Play();
            other.gameObject.GetComponent<EnemyController>().TakeDamage(_damage);
            isHit = true;
            Debug.Log("damage");
            StartCoroutine(HitCooldown());
        }
    }

    //Cooldown before hitting again
    private IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(_delay);
        isHit = false;
    }

}
