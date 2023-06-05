using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityTypes;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    public GameObject WeaponSlot;
    public Animator HeadAnimator;
    public Animator BodyAnimator;
    public Animator BootsAnimator;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private Vector3 _scaleofobject;
    private float _mousepos;
    private Camera _mainCamera;
    [Header("Combat")]
    [Space]
    public int Health = 100;

    public bool IsDead;
    private bool canBeHit;
    public float InvulnerableDuration;
    private AudioSource _hitSound;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;



    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        _scaleofobject = transform.localScale;
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _hitSound = GetComponent<AudioSource>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Start()
    {
        IsDead = false;
        canBeHit = true;
    }
    private void Update()
    {
        if (IsDead) return;
        // Player should face the mouse
        _mousepos = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        if (_mousepos <= transform.position.x)
            transform.localScale = new Vector3(-_scaleofobject.x, _scaleofobject.y, _scaleofobject.z);
        else transform.localScale = new Vector3(_scaleofobject.x, _scaleofobject.y, _scaleofobject.z);
    }
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, bool jump)
    {
        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    public void TakeDamage(int damage)
    {
        if(canBeHit)
        {
            _hitSound.Play();
            Health -= damage;
            StartCoroutine(Invulnerable());
        }
        if (Health <= 0)
        {
            IsDead = true;
            GetComponent<PlayerMovement>().isDead = true;
            m_Rigidbody2D.freezeRotation = true;
            GetComponentInChildren<WeaponController>().canAttack = false;
            GameManager.Instance.OnPlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(UnityTags.Enemy.ToString()) && other is BoxCollider2D)
        {
            TakeDamage(other.gameObject.GetComponent<EnemyController>().CalculateDamageToPlayer());
            Debug.Log("damage player");
        }
    }

    IEnumerator Invulnerable()
    {
        canBeHit = false;
        yield return new WaitForSeconds(InvulnerableDuration);
        canBeHit = true;
        //yield break;
    }
}