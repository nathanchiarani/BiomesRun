using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;


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