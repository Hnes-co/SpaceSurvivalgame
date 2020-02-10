using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        return transform.position.x > 20.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
