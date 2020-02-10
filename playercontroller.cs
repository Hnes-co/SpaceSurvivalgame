using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PauseMenuController p;
    public float speed = 5;
    public float bulletSpeed = 10;
    public Rigidbody2D bullet_prefab;
    public Transform playerPosition;
    public int health = 5;
    public Canvas menu;
    //public Text healthField;
    public Slider playerhealthbar;
    public Text killsField;
    //public Text timerField;
    public Text paused;
    public Text gameOver;
    public Text finalResult;
    public Button restart;
    public Button quit;
    public Button resume;
    public Button mainMenu;
    public Text Lampotila;
    public Text Humidity;
    public Text Pressure;
    private float humid;
    
    public GameObject shield;
    private int rechargetime;
    

    public int Kills { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(true);
        Kills = 0;
        playerhealthbar.enabled = true;
        playerhealthbar.value = 100;
        rb = GetComponent<Rigidbody2D>();
        p = GetComponent<PauseMenuController>();
        killsField.text = Kills.ToString();
        menu.enabled = false;
        StartCoroutine("Lampo");
    }

    IEnumerator Lampo()
    {
        for (; ; )
        {

            Humidity.text = "Humidity: "+ SQL.ReadHumid().ToString();
            Pressure.text = "Pressure: "+ SQL.ReadPress().ToString();
            Lampotila.text = "Temperature: "+ SQL.ReadTemp().ToString() + " °C";
            humid = SQL.ReadHumid() * 5;
            yield return new WaitForSeconds(5);
            
        }
    }
    void FixedUpdate()
    {
        shield.transform.position = gameObject.transform.position;
            

        // update timer and other textfields
        //time += Time.deltaTime;
        //healthField.text = health.ToString();
        killsField.text = Kills.ToString();
        //timerField.text = time.ToString("0.0");

        // commands for moving
        if (health > 0)
        {
            float movehorizontal = Input.GetAxis("Horizontal");
            float movevertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(movehorizontal, movevertical);
            rb.AddForce(movement * speed);
        }

        if (health <= 0)
        {
            rb.AddForce(new Vector2(0, -1) * 15);
            if (gameObject.transform.position.y < -7.5)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                Time.timeScale = 0;
            }
        }
        
        // command for shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D bulletCopy = Instantiate(bullet_prefab, playerPosition.position, Quaternion.identity);
            bulletCopy.AddForce(playerPosition.right * 150);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "OwnBullet" || collider.gameObject.tag == "Player")
        {

        }
        else if (collider.gameObject.tag == "PickUp")
        {
            Destroy(collider.gameObject);
            health += 1;
            playerhealthbar.value += 20;
        }
        else
        {
            if (shield.activeSelf == true)
            {
                shield.SetActive(false);
                rechargetime = 0;
                StartCoroutine("Recharge");
            }
            else
            {
                health -= 1;
                playerhealthbar.value -= 20;
            }
        }
        if (health == 0)
        {
            //healthField.text = health.ToString();
            killsField.text = Kills.ToString();
            p.ShowGameOverScreen();
            //finalResult.text = "Score: " + Kills.ToString() + " in " + time.ToString("0.0") + " sec";
        }
    }

    public IEnumerator Recharge()
    {
        while (rechargetime <= 20)
        {
            rechargetime += 10;
            if (rechargetime == 20)
            {
                shield.SetActive(true);
            }

            yield return new WaitForSeconds(10);
        }
    }
}
