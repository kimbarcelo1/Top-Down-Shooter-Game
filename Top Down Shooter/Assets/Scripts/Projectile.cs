using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;

    public GameObject expolsionPartiles;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, lifeTime);
        Invoke("DestroyProjectiles", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectiles()
    {
        Destroy(gameObject);

        // instatiate particle effects
        Instantiate(expolsionPartiles, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage); // find the enemy script then call TakeDamage function
            DestroyProjectiles(); // destroy the projectile
        }
    }
}
