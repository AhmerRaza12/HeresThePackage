using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed=250.0f;
    [SerializeField] float moveSpeed=8.0f;
    
    [SerializeField] float slowSpeed=5.0f;
    [SerializeField] float boostSpeed=12.5f;
 
    void Start()
    {
      //Nothing here     
    }
    public void OnCollisionEnter2D(Collision2D other) {
            Debug.Log("Ouch!");
            moveSpeed=slowSpeed;

    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Boosts"){
         Debug.Log("Picked up Boosts");
           moveSpeed=boostSpeed;
          
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed *Time.deltaTime;
        float moveAmount =Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
}
