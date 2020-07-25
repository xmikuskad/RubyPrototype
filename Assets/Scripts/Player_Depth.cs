using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Depth : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float fallAmount = 0.01f;

    Rigidbody2D rb;
    CharacterController con;

    [SerializeField] bool jumping = false;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1 -----------------
        //Buguje sa o stenu 
        /*if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }*/

        //2 ------------------------------
        //Kolizie nefunguju
        /*if(Input.GetKey(KeyCode.W))
        {
            con.Move(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
             con.Move(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
             con.Move(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
             con.Move(Vector3.right * Time.deltaTime * speed);
        }*/

        //3 --------------------
        //Not a good idea
        /*if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0,1) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
             rb.velocity = new Vector2(0, -1) * speed;
         }
        if (Input.GetKey(KeyCode.A))
        {
             rb.velocity = new Vector2(-1, 0) * speed;
         }
        if (Input.GetKey(KeyCode.D))
        {
             rb.velocity = new Vector2(1, 0) * speed;
         }*/

        //4 ---------------------------
        //Funguje celkom fajn, problem ked idem aj W aj A napr
        /*if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y+speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y-speed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(new Vector2(transform.position.x -speed, transform.position.y));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
        }*/

        //5 -------------------------------
        //Funguje v pohode ale je tam rozbiehanie
        //rb.MovePosition(new Vector2(Input.GetAxis("Horizontal") * speed + transform.position.x, Input.GetAxis("Vertical") * speed + transform.position.y));

        //6 -------------------------------
        //Funguje asi najlepsie ale problemy so skakanim
        /*float moveX = 0, moveY = 0;

        float maxHeight = 0f, minHeight = 0f;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveY += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += speed;
        }

        if (jumping)
        {
            moveY -= speed*fallAmount;
            if (Mathf.Abs(transform.position.y - startY) < 0.2f)
                jumping = false;
        }

        //Pokus o skok
        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            moveY += jumpForce;
            jumping = true;
            startY = transform.position.y;
        }


        rb.MovePosition(new Vector2(transform.position.x + moveX, transform.position.y + moveY));*/

    }



}
