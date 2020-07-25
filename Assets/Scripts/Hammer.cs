using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Animator animator;
    bool dead = false;

    [SerializeField] int maxHits = 3;
    [SerializeField] int hits = 0;
    [SerializeField] bool endHit = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5);
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - 2f, transform.position.y - 1f), transform.localScale * 4,0);
        foreach (var hitCollider in hitColliders)
        {
            if (endHit && hitCollider.GetComponent<Player>() != null)
            {
                //Debug.Log("Found something");
                if(hits >= maxHits)
                {
                    animator.SetBool("done", true);
                    dead = true;
                }
                else
                {
                    animator.SetTrigger("hit");
                    endHit = false;
                }
            }
        }
    }

    public void Hit()
    {
        hits++;
    }

    public void EndHit()
    {
        endHit = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, 5);
        Gizmos.DrawWireCube(new Vector2(transform.position.x - 2f, transform.position.y - 1f), transform.localScale * 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().DealDamage();
        }
    }


    public void KickPlayer()
    {
        if(dead)
        {
            FindObjectOfType<Player>().KickPlayer();
        }

    }

}
