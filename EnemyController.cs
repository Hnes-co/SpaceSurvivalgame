using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public int health = 1;
    public Rigidbody2D bullet_prefab;
    public float bulletSpeed = 5f;
    public Transform enemypos;
    public int kills = 0;

    public void Start()
    {
        StartCoroutine("CheckIfFar");
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    public IEnumerator CheckIfFar()
    {
        for (; ; )
        {
            if (isFar())
            {
                Destroy(gameObject);
                yield return null;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public IEnumerator Shoot()
    {
        for (; ; )
        {
            Rigidbody2D bulletCopy = Instantiate(bullet_prefab, enemypos.position, Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bulletSpeed);
            yield return new WaitForSeconds(2.5f);
        }
    }

    bool isFar()
    {
        return transform.position.x < -20.0f;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyBullet" || collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "PickUp")
        {

        }
        else
        {
            health -= 1;
        }
        if (health == 0)
        {
            kills += 25;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.Kills = kills + playerController.Kills;
            Destroy(gameObject);
        }
    }
}
