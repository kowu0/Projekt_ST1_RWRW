using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // ilość siły dodanej podczas skoku
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // jak bardzo wygładzić ruch
    [SerializeField] private bool m_AirControl = false;                         // bool od sterowania postacia podczas lotu
    [SerializeField] private LayerMask m_WhatIsGround;                          // maska określająca co jest podłożem
    [SerializeField] private Transform m_GroundCheck;                           // pozycja gdzie sprawdzać czy postać jest m_Grounded

    const float k_GroundedRadius = .2f; // promień określający w jakim zakresie sprawdzać czy jest grounded
    private bool m_Grounded;            // bool czy jest grounded
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // określenie w którą stronę gracz patrzy
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public Rigidbody2D playerRb;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // ustawia status gracza jako grounded gdy circlecast (taki okrąg) trafi w coś oznaczone jako ground
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
        if (KBCounter <= 0) { 
        //kontrolowanie możliwe tylko jeśli postać jest na podłożu lub w powietrzu, ale przy włączonej funkcji AirControl
        if (m_Grounded || m_AirControl)
        {
           
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        // Jeśli gracz może/powinien skoczyć
        if (m_Grounded && jump)
        {
            // dodaje siłę wertykalną (oś y)
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

        }
        else
        //tutaj kod odpowiedzialny za odrzucanie postaci albo w lewo albo w prawo
        {
            if(KnockFromRight)
            {
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (!KnockFromRight)
            {
                playerRb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        // mnoży skale na iksie przez -1 żeby odwrócić 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}