using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 10f;
    float maxVel = 5f;
    SpriteRenderer sprite;

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

}
