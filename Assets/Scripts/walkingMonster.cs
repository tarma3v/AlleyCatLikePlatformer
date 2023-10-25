using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : Entity
{
    private float speed = 3.5f;
    private Vector3 direction;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        direction = transform.right;
        direction *= -1;
    }

    private void Move()
    {
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + 0.7f * direction.x * transform.right, 0.1f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f, 0.1f);
        if (colliders.Length > 0) direction *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x > 0.0f;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
}