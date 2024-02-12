using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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

    //set the list of the sprite so later The sprite can change
    public List<Sprite> spr;

    //set different text to change
    [SerializeField] private Text Blue;
    [SerializeField] private Text Green;
    [SerializeField] private Text Red;
    [SerializeField] private Text Total;
    [SerializeField] public Text Warning;

    //set up the game object so later can genrate when ger result
    public GameObject DarkPurpleGem;
    public GameObject DarkBronwnGem;
    public GameObject DarkTealGem;
    public GameObject LightBrownGem;
    public GameObject LightPurpleGem;
    public GameObject LightTealGem;
    void Start()
    {
        //get the collider and rigidbody before the game start
        rb = GetComponent<Rigidbody2D>();
        potCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //this is the main program that allow the game to calculate what kind of gem player is making, based on the different color combination, the output will be different
        if (RedNum < BlueNum)
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

       

        //if there are five or more elements in the pot, player can start making the gem by right click
        if (numBot >= 5 && Input.GetMouseButtonDown(1))
        {
            Debug.Log("good");
            //set everything back to 0 after making the gem
            numBot = 0;
            BlueNum = 0;
            GreenNum = 0;
            RedNum = 0; 
            Total.text = "Total: " + numBot;
            Red.text = "Red: " + RedNum;
            Blue.text = "Blue: " + BlueNum;
            Green.text = "Green: " + GreenNum;
            Warning.text = "Pot is not full!";

            //set the gem span position, which is disgned
            Vector3 spawnPosition = new Vector3(-0.07f, -2.48f, -1f);
            //besed on the different result of the color combination, the gem that will be genrated will be different 
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

        //based on how many elements where put into the pod, the sprite of the pot will be different
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
        //if there is 10 elements in the pod, players can't put more elements into the pod
        if (numBot == 10)
        {
            potCollider.isTrigger = false;
        }
        //the word will display if the pot is full or not

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //when player put the gem into the pod, react based on the color that player put into the pod, then destory the gem, calculate how many gems where inside the pod that shares the same color, and calculate the total amount of the gems
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
        string potMessage = (numBot <= 9) ? "Pot is not full!" : "Pot is full!";
        Debug.Log(potMessage);
        Warning.text = potMessage;
    }
}
