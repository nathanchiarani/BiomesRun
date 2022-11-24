using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float moveMultiplier;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Player damage manager")]
    public float damageTime;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    int punteggio;

    Rigidbody rb;

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    public Image imgLives;

    private int lives = 3;

    [SerializeField]
    private Sprite[] _liveSprites;

    bool canTakeDamage;


    public int updateLives(int currentLives)
    {
        imgLives.sprite = _liveSprites[currentLives];
        return currentLives;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mostro")
        {
            if (canTakeDamage)
            {
                canTakeDamage = false;
                StartCoroutine(CollisionWithMonster());
            }
        }
        if (lives == 0)
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(<perdita>);
        }

        //if (collision.gameObject.tag == "gemma")
        //{
        //    StartCoroutine(DestroyBonus(collision.gameObject));
        //}
    }


    //IEnumerator DestroyBonus(GameObject obj) //Coroutine
    //{
    //    if (obj.gameObject.tag == "gemma")
    //    {
    //        obj.gameObject.GetComponent<BoxCollider>().enabled = false;
    //        yield return new CollisionWithMonster(0.25f);
    //        punteggio++;
    //        GameObject.FindGameObjectWithTag("ValorePunteggio").GetComponent<Text>().text = punteggio.ToString();
    //        Destroy(obj.gameObject);
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        canTakeDamage = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calcolo direzione di movimento
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.velocity = moveDirection.normalized * moveSpeed * moveMultiplier;
    }

    public void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    IEnumerator CollisionWithMonster()
    {
        if(damageTime == 0)
        {
            damageTime = 1f;
        }
        lives--;
        imgLives.sprite = _liveSprites[updateLives(lives)];
        yield return new WaitForSeconds(damageTime);
        canTakeDamage = true;
    }
}
