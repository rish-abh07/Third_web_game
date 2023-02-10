using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;

public class PlayerMovement : MonoBehaviour
{   
    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
      
        
        playerRb.velocity = new Vector3(horizontalInput, playerRb.velocity.y, verticalInput) * speed ;
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Blockchain"))
        {
            SceneManager.LoadScene("End");
        }
    }
}
