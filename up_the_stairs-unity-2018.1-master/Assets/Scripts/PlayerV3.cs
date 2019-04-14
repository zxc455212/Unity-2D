﻿using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerV3 : PlayerBase
{
    public float jumpSpeed = 8f;
    public float jumpForce = 15f;
    public float walkForce = 100f;
    public float walkSpeedLimit = 3.5f;
    
    private SpriteRenderer _renderer;
    private Animator _animator;
    private Rigidbody2D _body;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _renderer.flipX = false;
            _animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _renderer.flipX = true;
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _body.velocity += new Vector2(0, jumpSpeed); 
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_body.velocity.x < walkSpeedLimit)
            {   
                _body.AddForce(new Vector2(walkForce, 0));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_body.velocity.x > -walkSpeedLimit)
            {
                _body.AddForce(new Vector2(-walkForce, 0));
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _body.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead")
        {
            _animator.SetBool("Dead", true);
            onGameOver();
        }
        else if (collision.tag == "Finish")
        {
            _animator.SetBool("Finished", true);
            onGameOver();
        }
    }

    public override void Stop()
    {
        _body.velocity = Vector2.zero;
        _body.simulated = false;
        enabled = false;
    }
}
