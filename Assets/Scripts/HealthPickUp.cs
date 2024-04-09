using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    Player playerScript;

    public int healAmount;

    public float lifeTime;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Invoke("DestroyHealth", lifeTime);
    }

    void DestroyHealth()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript.heal(healAmount);
            Destroy(gameObject);
        }
    }
}
