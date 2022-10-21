using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
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
        Debug.Log(currentLives);
        return currentLives;
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "mostro")
        {
            lives--;
            print(lives);
            StartCoroutine(WaitSec());
            imgLives.sprite = _liveSprites[updateLives(lives)];
        }
        if (lives == 0)
        {
            StartCoroutine(WaitSec());
            Destroy(this.gameObject);
            //SceneManager.LoadScene(<perdita>);
        }
    }
    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
