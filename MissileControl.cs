using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D missile_prefab;
    public float missileSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine("CheckIfFar");
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

    bool isFar()
    {
        return transform.position.x < -20.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (missile_prefab.transform.position.x > target.position.x + 1)
            missile_prefab.transform.position = Vector2.MoveTowards(missile_prefab.transform.position, target.position, missileSpeed * Time.deltaTime);
        else
            missile_prefab.AddForce(new Vector2(-1, 0) * missileSpeed, 0);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "OwnBullet")
        {
            Destroy(gameObject);
        }
    }
}
