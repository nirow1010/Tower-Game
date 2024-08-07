using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMove : MonoBehaviour
{

    // max move speed of the character
    [SerializeField] private float moveSpeed = 1f;

    // acceleration rate of the character run
    [SerializeField] private float accelRate = 0.1f;

    // deceleration rate of the character stop
    [SerializeField] private float decelRate = 0.1f;

    // moving direction vector of the character
    private Vector2 moveDirection = new Vector2(0, 0);

    // Rigidbody2D attached to the character
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();
        
        Vector2 movement = (moveDirection * moveSpeed - rb.velocity) * (moveDirection.magnitude > 0 ? accelRate : decelRate); // set the movement vector (the amount of vector force the character will receive)
        rb.AddForce(movement, ForceMode2D.Force);
    }
    
}
