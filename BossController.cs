using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D boss;
    private bool rightSpot = false;
    //public int health = 50;
    private int kills = 0;
    public Rigidbody2D b_prefab;
    public float bSpeed = 150f;
    public float s = 150f;
    public Transform enemypos;
    private GameObject p;
    private Transform target;
    private PauseMenuController pmc;
    private GameObject sp;
    private SpawnEnemies se;
    private GameObject player;
    private PlayerController playerController;
    public GameObject pickup_prefab;
    private GameObject pickup_copy;
    private Rigidbody2D pick;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        boss = gameObject.GetComponent<Rigidbody2D>();
        boss.AddForce(new Vector2(-1, 0) * s);
        StartCoroutine("CheckIfFar");
        p = GameObject.Find("Player");
        sp = GameObject.Find("EnemySpawnPoint");
        se = sp.GetComponent<SpawnEnemies>();
        pmc = p.GetComponent<PauseMenuController>();

        if (boss.name == "Boss1(Clone)")
        {
            StartCoroutine("Shoot");
        }
        else if (boss.name == "Boss2(Clone)")
        {
            StartCoroutine("Shoot2");
        }
        else if (boss.name == "Boss3(Clone)")
        {
            StartCoroutine("Shoot3");
        }
        else if (boss.name == "Boss4(Clone)")
        {
            StartCoroutine("Shoot4");
        }
        else
        {
            StartCoroutine("Shoot5");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boss.transform.position.x <= 14 && !rightSpot)
        {
            boss.velocity = new Vector2(0, 0);
            rightSpot = true;
            //boss.AddForce(new Vector2(0, -s));
        }
        if (rightSpot)
        {
            //if (boss.transform.position.y <= -7 && !tooLow)
            //{
            //    boss.velocity = new Vector2(0, 0);
            //    boss.AddForce(new Vector2(0, s));
            //    tooLow = true;
            //}
            //else if (boss.transform.position.y >= 7 && tooLow)
            //{
            //    boss.velocity = new Vector2(0, 0);
            //    boss.AddForce(new Vector2(0, -s));
            //    tooLow = false;
            //}
            if (boss.name == "Boss2(Clone)")
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(13, target.position.y + 0.5f), 3 * Time.deltaTime);
            }
            else if (boss.name == "Boss1(Clone)")
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(13, target.position.y + 0.6f), 4 * Time.deltaTime);
            }
            else if (boss.name == "Boss3(Clone)")
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(13, target.position.y + 0.7f), 5 * Time.deltaTime);
            }
            else if (boss.name == "Boss4(Clone)")
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(13, target.position.y + 0.8f), 6 * Time.deltaTime);
            }
            else
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(11, target.position.y + 1.5f), 7 * Time.deltaTime);
            }
        }

        //Vector3 pos = transform.position;
        //Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        //pos += transform.rotation * velocity;
        //transform.position = pos;
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
            Rigidbody2D bulletCopy = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y - 1.2f), Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bSpeed);
            yield return new WaitForSeconds(1.25f);
        }
    }

    public IEnumerator Shoot2()
    {
        for (; ; )
        {
            Rigidbody2D bulletCopy = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y - 1.3f), Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bSpeed);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public IEnumerator Shoot3()
    {
        for (; ; )
        {
            Rigidbody2D bulletCopy = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y + 1.2f), Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bSpeed);
            Rigidbody2D bulletCopy2 = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y - 1.4f), Quaternion.identity);
            bulletCopy2.AddForce(new Vector2(-1, 0) * bSpeed);
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator Shoot4()
    {
        for (; ; )
        {
            Rigidbody2D bulletCopy = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y + 1.3f), Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bSpeed);
            Rigidbody2D bulletCopy2 = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y - 1.5f), Quaternion.identity);
            bulletCopy2.AddForce(new Vector2(-1, 0) * bSpeed);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public IEnumerator Shoot5()
    {
        for (; ; )
        {
            Rigidbody2D bulletCopy = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y + 1.8f), Quaternion.identity);
            bulletCopy.AddForce(new Vector2(-1, 0) * bSpeed);
            Rigidbody2D bulletCopy2 = Instantiate(b_prefab, new Vector2(enemypos.position.x - 0.5f, enemypos.position.y - 2f), Quaternion.identity);
            bulletCopy2.AddForce(new Vector2(-1, 0) * bSpeed);
            yield return new WaitForSeconds(0.5f);
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
            //se.bosshealthbar.value -= 2;
            se.DamageBoss();
        }
        if (se.bosshealthbar.value == 0)
        {
            if (boss.name == "Boss1(Clone)")
            {
                kills += 100;
            }
            else if (boss.name == "Boss2(Clone)")
            {
                kills += 200;
            }
            else if (boss.name == "Boss3(Clone)")
            {
                kills += 300;
            }
            else if (boss.name == "Boss4(Clone)")
            {
                kills += 400;
            }
            else
            {
                kills += 500;
            }
            
            playerController.Kills = kills + playerController.Kills;
            pickup_copy = Instantiate(pickup_prefab, gameObject.transform.position, Quaternion.identity);
            pick = pickup_copy.GetComponent<Rigidbody2D>();
            pick.AddForce(new Vector2(-250, pick.transform.position.y));
            Destroy(gameObject);

            if (boss.name == "Boss5(Clone)")
            {
                pmc.ShowWinScreen();
            }
        }
    }
}
