using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D potCollider;

    //setup the tree numbers that will be used in the game
    public int RedNum = 0;
    public int BlueNum = 0;
    public int GreenNum = 0;
    public int numBot = 0;
    public string color = "clear";

    public List<Sprite> spr;

    [SerializeField] private Text Blue;
    [SerializeField] private Text Green;
    [SerializeField] private Text Red;
    [SerializeField] private Text Total;

    public GameObject DarkPurpleGem;
    public GameObject DarkBronwnGem;
    public GameObject DarkTealGem;
    public GameObject LightBrownGem;
    public GameObject LightPurpleGem;
    public GameObject LightTealGem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        potCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RedNum < BlueNum)
        {
           color =  "DarkPurple";
        }
        if (RedNum < GreenNum)
        {
            color = "DarkBronwn";
        }
        if (GreenNum < BlueNum)
        {
            color = "DarkTeal";
        }
        if(GreenNum < RedNum)
        {
            color = "LightBrown";
        }
        if (BlueNum < RedNum)
        {
            color = "LightPurple";
        }
        if (BlueNum < GreenNum)
        {
            color = "LightTeal";
        }


        if (numBot > 5 && Input.GetMouseButtonDown(1))
        {
            Debug.Log("good");
            numBot = 0;
            BlueNum = 0;
            GreenNum = 0;
            RedNum = 0; 
            Total.text = "Total: " + numBot;
            Red.text = "Red: " + RedNum;
            Blue.text = "Blue: " + BlueNum;
            Green.text = "Green: " + GreenNum;

            Vector3 spawnPosition = new Vector3(-0.07f, -2.48f, -1f);
            switch (color)
            { 
                case "DarkPurple":
                    Instantiate(DarkPurpleGem, spawnPosition, Quaternion.identity);
                    break;
                case "DarkBronwn":
                    Instantiate(DarkBronwnGem, spawnPosition, Quaternion.identity);
                    break;
                case "DarkTeal":
                    Instantiate(DarkTealGem, spawnPosition, Quaternion.identity);
                    break;
                case "LightBrown":
                    Instantiate(LightBrownGem, spawnPosition, Quaternion.identity);
                    break;
                case "LightPurple":
                    Instantiate(LightPurpleGem, spawnPosition, Quaternion.identity);
                    break;
                case "LightTeal":
                    Instantiate(LightTealGem, spawnPosition, Quaternion.identity);
                    break;
            }
        }

        switch (numBot)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = spr[0];
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = spr[1];
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = spr[2];
                break;
        }

        if (numBot == 10)
        {
            potCollider.isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player put the gem inro the pod, react based on the color that player put into the pod, then destory the gem
        if (collision.gameObject.CompareTag("Red"))
        {
            RedNum++;
            numBot++;
            Red.text = "Red: " + RedNum;
            Total.text = "Total: " + numBot;
            Debug.Log(RedNum);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Blue"))
        {
            BlueNum++;
            numBot++;
            Blue.text = "Blue: " + BlueNum;
            Total.text = "Total: " + numBot;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            GreenNum++;
            numBot++;
            Green.text = "Green: " + GreenNum;
            Total.text = "Total: " + numBot;
            Destroy(collision.gameObject);
        }
    }
}
