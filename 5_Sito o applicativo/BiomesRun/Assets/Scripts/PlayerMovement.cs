using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    Rigidbody rb;

    public float speed = 10.0f;
    public Image imgLives;

    private int lives = 3;

    [SerializeField]
    private Sprite[] _liveSprites;

    bool canTakeDamage;

    public AudioSource HitEnemy;
    public AudioSource key;
    public AudioSource star;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        canTakeDamage = true;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

}

// Update is called once per frame
    void Update()
    {
        //imposto il player attaccato al terreno
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //verifico di essere attaccato al terreno
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

    public int updateLives(int currentLives) // metodo che aggiorna le vite del personaggio
    {
        imgLives.sprite = _liveSprites[currentLives];
        return currentLives;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mostro") // se collido con un oggetto con il tag mostro mi togle una vita
        {
            if (canTakeDamage)
            {
                HitEnemy.Play();
                canTakeDamage = false;
                StartCoroutine(CollisionWithMonster());
            }
        }
        if (lives == 0) // se le vite sono 0 carica la schermata di perdita
        {
            GetComponent<MenuManager>().LoseLives();
        }

        if (collision.gameObject.tag == "stella") // se collido con un oggetto con il tag stella mi aumenta la velocità
        {
            star.Play();
            Destroy(collision.gameObject);
            StartCoroutine(CollisionWithStar());
        }

        if (collision.gameObject.tag == "Portal1")
        // se collido con un oggetto con il Portal1 mi porta alla schermata di spiegazione del secondo bioma
        {
            GetComponent<MenuManager>().LoadBiome2();
        }

        if (collision.gameObject.tag == "Portal2")
        // se collido con un oggetto con il Portal2 mi porta alla schermata di spiegazione del terzo bioma
        {
            GetComponent<MenuManager>().LoadBiome3();
        }

        if (collision.gameObject.tag == "Portal3")
        // se collido con un oggetto con il Portal3 mi porta alla schermata di vittoria
        {
            GetComponent<MenuManager>().Victory();
        }

        if(collision.gameObject.tag == "WrongKey")
        // se collido con un oggetto con il WrongKey mi porta alla schermata di perdita per la chiave falsa
        {
            key.Play();
            GetComponent<MenuManager>().LoseKey();
        }

    }

    private void MyInput() // metodo che prende le assi del mouse
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() //metodo che serve per muovere il player
    {
        //calcolo direzione di movimento
        moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput) /2;

        rb.velocity = moveDirection.normalized * moveSpeed * moveMultiplier;
    }

    public void SpeedControl() // metodo che rende la velocità costante
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    IEnumerator CollisionWithMonster() // coroutine che danneggia il giocatore togliendogli una vita
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

    IEnumerator CollisionWithStar() // coroutine per la velocità se si prende una stella
    {
        moveSpeed += 5;
        yield return new WaitForSeconds(3f);
        moveSpeed -= 5;
    }
}
