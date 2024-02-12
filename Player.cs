using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed;
    private float Move;
    private Rigidbody2D rb;
    public float Jump;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb!=null){
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed*Move, rb.velocity.y);
        if(Input.GetButtonDown("Jump")&&isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, Jump), ForceMode2D.Impulse);
        }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping=true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping=false;
        }
    }
}
