using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public VirtualJoystick joystick;

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public Animator hurtAnim;

    private Vector2 moveAmount;

    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyheart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2();

        if (joystick.InputDir != Vector3.zero)
            moveInput = joystick.InputDir;

         
        moveAmount = moveInput.normalized * speed;;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRuning", true);
        }
        else
        {
            anim.SetBool("isRuning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpadateHealthUI(health);
        hurtAnim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            SaveManager.Instance.Save();
            SaveManager.Instance.save.Coin += GameStats.Instance.coinCollectedThisSession;
            SceneManager.LoadScene("lost");
        }
    }

    void UpadateHealthUI(int currentHealth)
    {
        for(int i =0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }

        }
    }

    public void heal(int healAmount)
    {
        if(health + healAmount > 4)
        {
            health = 4;
        }
        else
        {
            health += healAmount;
        }
        UpadateHealthUI(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
        }
    }
 }
