using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 3f;
    float maxVel = 5f;
    SpriteRenderer sprite;

    private int scoreValue = 0;

    private int lifeValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var xdiff = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Mathf.Abs(_rb.velocity.x) > maxVel)
         {
             var temp = _rb.velocity;
             temp.x = maxVel * Mathf.Sign(xdiff);
             _rb.velocity = temp;
             return;
         }

         _rb.AddForce(Vector2.right * xdiff, ForceMode2D.Impulse);

        
        if (Input.GetButtonDown("Jump"))
        {
            sprite.flipY = !sprite.flipY;

            var tmp = Physics2D.gravity;
            tmp.y *= -1;
            Physics2D.gravity = tmp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Gate")
        {
            scoreValue += 1;
            transform.position = new Vector3(50.0f, 0.0f, 0.0f);

        }

        if (scoreValue >= 2)
        {
            Destroy(this);
        }

        if (collision.collider.tag == "Enemy")
        {
            lifeValue -= 1;
        }

        if (lifeValue <= 0)
        {
            Destroy(this);
        }
    }
}
