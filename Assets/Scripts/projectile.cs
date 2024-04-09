using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float BulletSpeed;

    public int BulletDamage;

    public float lifeTime;

    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(BulletDamage);
            DestroyProjectile();
        }

        if (other.tag == "boss")
        {
            other.GetComponent<Boss>().TakeDamage(BulletDamage);
            DestroyProjectile();
        }
    }
}
