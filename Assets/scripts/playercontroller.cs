using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
   // public float jumpForce;
    public GroundCheck GroundCheck;
    
    private Rigidbody2D rb2d;
    private bool isGrounded = false;
   

    private void Awake()
    {
        Debug.Log("player ccontroller is awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void PickUpKey()
    {
        Debug.Log("player picked up the key");
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("collision:" + collision.gameObject.name);
    // }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        MoveCharacter(horizontal, Vertical);
        playMovementAnimation(horizontal , Vertical);
        isGrounded = GroundCheck.isGrounded;
    }

    

    private void MoveCharacter(float horizontal , float Vertical)
    {
        UnityEngine.Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        if (Vertical > 0)
        {
            rb2d.AddForce(new UnityEngine.Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void playMovementAnimation(float horizontal , float Vertical)
{
        animator.SetFloat("speed", Mathf.Abs(horizontal));
      //  animator.SetBool("jump", );
        animator.SetBool("isGrounded", isGrounded);
        UnityEngine.Vector3 scale = transform.localScale;
        // float hori = horizontal < 0 ? scale.x = -1f * Mathf.Abs(scale.x) : scale.x = Mathf.Abs(scale.x);
         if (horizontal < 0)
         {
             scale.x = -1f * Mathf.Abs(scale.x);
         }
         else if (horizontal > 0)
         {
             scale.x = Mathf.Abs(scale.x);
         }
         transform.localScale = scale;
       
        if (Vertical > 0 && isGrounded == true)
        {
            animator.SetBool("jump", true);
            
        }
        else
        {
            animator.SetBool("jump", false);
            
        }
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }     
    }
    /*
    public float timeinair = 0;
    public float deathtimer = 10;
    private bool dead = false;
    private GroundCheck player;

    void update()
    {
        if (!player.isGrounded)
        {
            timeinair += Time.deltaTime;
        }
        else if(timeinair >= deathtimer)
        {
            dead = true;
        }
    }
    */
}