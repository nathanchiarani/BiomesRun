using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    // Start is called before the first frame update
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    public Image imgLives;

    private int lives = 3;

    [SerializeField]
    private Sprite[] _liveSprites;

    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1000);
    }

    public int updateLives(int currentLives)
    {
        imgLives.sprite = _liveSprites[currentLives];
        return currentLives;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "mostro")
        {
            lives--;
            imgLives.sprite = _liveSprites[updateLives(lives)];
        }
        if (lives == 0)
        {
            //SceneManager.LoadScene(7);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalInput = Input.GetAxis("Vertical") * movementSpeed;
        
        transform.Translate(horizontalInput * Time.deltaTime, 0f, verticalInput * Time.deltaTime);
    }
}