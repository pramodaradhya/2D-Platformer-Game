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
    private Rigidbody2D rb2d;

    private void Awake()
    {
        Debug.Log("player ccontroller is awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
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

        UnityEngine.Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Vertical >0)
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
}