using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    public Rigidbody2D enemy_prefab;
    public Rigidbody2D enemyMissile_prefab;
    public Rigidbody2D boss1_prefab;
    public Rigidbody2D boss2_prefab;
    public Rigidbody2D boss3_prefab;
    public Rigidbody2D boss4_prefab;
    public Rigidbody2D boss5_prefab;
    private Rigidbody2D bossCopy;
    public Transform spawnpoint;
    public float speed = 5.0f;
    private float time = -5;
    private bool radiobutton = false;
    private int i = 0;
    public Canvas bossinfo;
    public Text bossname;
    public Slider bosshealthbar;

    // Start is called before the first frame update
    void Start()
    {
        bossinfo.enabled = false;
        radiobutton = false;
        i = 0;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //// Timer
        //if (time <= 3.0)
        //{
        //    //time += Time.deltaTime;
        //}

        // Phase 1
        if (time == 5 && !radiobutton)
        {
            StartCoroutine("SpawnNormalEnemy");
            radiobutton = true;
        }

        if (/*i == 10*/ time == 30 && radiobutton)
        {
            StopCoroutine("SpawnNormalEnemy");
            SpawnBoss1();
            bossinfo.enabled = true;
            bossname.text = "Aleksi";
            bosshealthbar.value = 100;
            radiobutton = false;
        }

        // Phase 2
        if (/*i == 11*/ time == 45 && !radiobutton)
        {
            StartCoroutine("SpawnNormalEnemy2");
            radiobutton = true;
        }

        if (time == 75 && radiobutton)
        {
            StopCoroutine("SpawnNormalEnemy2");
            SpawnBoss2();
            bossinfo.enabled = true;
            bossname.text = "Sami";
            bosshealthbar.value = 100;
            radiobutton = false;
        }

        // Phase 3
        if (/*i == 11*/ time == 90 && !radiobutton)
        {
            StartCoroutine("SpawnMissileEnemy");
            radiobutton = true;
        }

        if (time == 120 && radiobutton)
        {
            StopCoroutine("SpawnMissileEnemy");
            SpawnBoss3();
            bossinfo.enabled = true;
            bossname.text = "Hannes";
            bosshealthbar.value = 100;
            radiobutton = false;
        }

        // Phase 4
        if (/*i == 11*/ time == 135 && !radiobutton)
        {
            StartCoroutine("SpawnMissileEnemy2");
            radiobutton = true;
        }

        if (time == 165 && radiobutton)
        {
            StopCoroutine("SpawnMissileEnemy2");
            SpawnBoss4();
            bossinfo.enabled = true;
            bossname.text = "Minna";
            bosshealthbar.value = 100;
            radiobutton = false;
        }

        // Phase 5
        if (/*i == 11*/ time == 180 && !radiobutton)
        {
            StartCoroutine("SpawnNormalEnemy3");
            StartCoroutine("SpawnMissileEnemy3");
            radiobutton = true;
        }

        if (time == 210 && radiobutton)
        {
            StopCoroutine("SpawnNormalEnemy3");
            StopCoroutine("SpawnMissileEnemy3");
            SpawnBoss5();
            bossinfo.enabled = true;
            bossname.text = "Konstantinos";
            bosshealthbar.value = 100;
            radiobutton = false;
        }
    }

    private IEnumerator Timer()
    {
        for (; ; )
        {
            time += 5;

            yield return new WaitForSeconds(5f);
        }
    }

    public void SpawnBoss1()
    {
        bossCopy = Instantiate(boss1_prefab, spawnpoint.position, new Quaternion(0, 0, 0, 0));
        i += 1;
    }

    public void SpawnBoss2()
    {
        bossCopy = Instantiate(boss2_prefab, spawnpoint.position, new Quaternion(0, 0, 0, 0));
        i += 1;
    }

    public void SpawnBoss3()
    {
        bossCopy = Instantiate(boss3_prefab, spawnpoint.position, new Quaternion(0, 0, 0, 0));
        i += 1;
    }

    public void SpawnBoss4()
    {
        bossCopy = Instantiate(boss4_prefab, spawnpoint.position, new Quaternion(0, 0, 0, 0));
        i += 1;
    }

    public void SpawnBoss5()
    {
        bossCopy = Instantiate(boss5_prefab, spawnpoint.position, new Quaternion(0, 0, 0, 0));
        i += 1;
    }

    public void DamageBoss()
    {
        bosshealthbar.value -= 2;

        if (bosshealthbar.value <= 0)
            bossinfo.enabled = false;
    }

    public IEnumerator SpawnNormalEnemy()
    {
        while (/*i < 10*/ time >= 5 && time < 30)
        {
            Rigidbody2D enemyCopy = Instantiate(enemy_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyCopy.AddForce(new Vector2(-1, 0) * speed);
            i += 1;
            yield return new WaitForSeconds(2f);
        }
    }

    public IEnumerator SpawnNormalEnemy2()
    {
        while (/*i >= 11 && i <= 20*/ time >= 45 && time < 75)
        {
            Rigidbody2D enemyCopy = Instantiate(enemy_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyCopy.AddForce(new Vector2(-1, 0) * speed);
            i += 1;
            yield return new WaitForSeconds(1.5f);
        }
    }

    public IEnumerator SpawnNormalEnemy3()
    {
        while (/*i >= 11 && i <= 20*/ time >= 180 && time < 210)
        {
            Rigidbody2D enemyCopy = Instantiate(enemy_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyCopy.AddForce(new Vector2(-1, 0) * speed);
            i += 1;
            yield return new WaitForSeconds(2.5f);
        }
    }

    public IEnumerator SpawnMissileEnemy()
    {
        while (/*i >= 11 && i <= 20*/ time >= 90 && time < 120)
        {
            Rigidbody2D enemyMissileCopy = Instantiate(enemyMissile_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyMissileCopy.AddForce(new Vector2(-1, 0) * speed);
            yield return new WaitForSeconds(2f);
        }
    }

    public IEnumerator SpawnMissileEnemy2()
    {
        while (/*i >= 11 && i <= 20*/ time >= 135 && time < 165)
        {
            Rigidbody2D enemyMissileCopy = Instantiate(enemyMissile_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyMissileCopy.AddForce(new Vector2(-1, 0) * speed);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public IEnumerator SpawnMissileEnemy3()
    {
        while (/*i >= 11 && i <= 20*/ time >= 180 && time < 210)
        {
            Rigidbody2D enemyMissileCopy = Instantiate(enemyMissile_prefab, new Vector3(spawnpoint.position.x, spawnpoint.position.y + Random.Range(-8, 8), spawnpoint.position.z), new Quaternion(0, 0, 1, 1));
            enemyMissileCopy.AddForce(new Vector2(-1, 0) * speed);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
