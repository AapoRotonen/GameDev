using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 1f;
    public float speed = 3f;
    public float JumpSpeed = 10f;
    public float direction = 0f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    int JumpCount = 0;

    //private float direction = 0f;
    private bool isTouchingGround;
    public bool combatTrigger = false;
    private Rigidbody2D player;

    public Animator animator;



    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(direction));

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpSpeed), ForceMode2D.Impulse);
            JumpCount++;
        }
    }


    void Attack()
    {
        // Play an attack animation, detect enemies in range of attack and damage then
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Combat is on and hitted " + enemy);
            enemy.GetComponent<Enemy>().TakeHit(attackDamage);
        }

    }

    void onDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
