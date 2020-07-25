using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float pushForce = 1000f;

    [SerializeField] int hp = 10;

    [SerializeField] Transform groundCheck;
    Rigidbody2D rb;

    [SerializeField] bool grounded = false;
    [SerializeField] GameObject potion;

    [SerializeField] bool kick = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        if (kick)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(potion, new Vector2(transform.position.x + 1f,transform.position.y+1f),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kick)
            return;

        float h = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(h * speed * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        grounded = Physics2D.OverlapPoint(groundCheck.position);
    }

    public void DealDamage()
    {
        hp -= 1;

    }

    public void KickPlayer()
    {
        kick = true;
        rb.velocity = Vector2.zero;
        rb.AddRelativeForce(new Vector2(-1, 1) * pushForce, ForceMode2D.Impulse);
        StartCoroutine(waiter(3));
    }

    IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
        kick = false;
    }
}
