using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    public Text countText;
    public Text distanceText;
    public Text pickText;
    public static int distance;

    public AudioSource ding;
    public AudioSource hitBlock;

    Vector3 fatVector = Vector3.zero;
    Vector3 thinVector = Vector3.zero;

    private int life;

    private int calories = 2500;


    private float time = 0.0f;

    private float speed = 5.0f;

    private Vector3 moveVector;

    private readonly float animationDuration = 2.0f;

    private float verticalVelocity = 0.0f;
    private readonly float gravity = 12.0f;
    public float jumpForce = 5;

    private float hitTime = 0.0f;

    private bool isFat, isThin;


    void SetCountText()
    {
        countText.text = "Calories: " + calories.ToString();
    }

    void SetDistanceText()
    {
        distance = (int)transform.position.z;
        distanceText.text = "Distance: " + distance + " m";
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        life = 3;
        ding = GetComponents<AudioSource>()[0];
        hitBlock = GetComponents<AudioSource>()[1];
        SetCountText();
        SetDistanceText();
        isFat = false;
        isThin = false;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        hitTime += Time.deltaTime;
        if (time > 1.0f)
        {
            calories -= 50;
            time = 0.0f;
            SetCountText();
        }

   
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        //Deal with the boundries
        HandleHorizontalMove();
        HandleJump();

        controller.Move(moveVector * Time.deltaTime);
        SetDistanceText();
        ChangeState(calories);
    }



    private void OnTriggerEnter(Collider other)
    {
        ding.Play();
        string message = "";
       
        switch (other.gameObject.tag)
        {
            case "Pick Up":
                other.gameObject.SetActive(false);
                calories += 5;
                SetCountText();
                message = other.gameObject.tag + " Calories: 5";
                break;
            case "apple":
                other.gameObject.SetActive(false);
                calories += 52;
                SetCountText();
                message = other.gameObject.tag + " Calories: 52";
                break;
            case "avocado":
                other.gameObject.SetActive(false);
                calories += 170;
                SetCountText();
                message = other.gameObject.tag + " Calories: 170";
                break;
            case "banana":
                other.gameObject.SetActive(false);
                calories += 95;
                SetCountText();
                message = other.gameObject.tag + " Calories: 95";
                break;
            case "bread":
                other.gameObject.SetActive(false);
                calories += 218;
                SetCountText();
                message = other.gameObject.tag + " Calories: 218";
                break;
            case "burger":
                other.gameObject.SetActive(false);
                calories += 303;
                SetCountText();
                message = other.gameObject.tag + " Calories: 303";
                break;
            case "cake":
                other.gameObject.SetActive(false);
                calories += 459;
                SetCountText();
                message = other.gameObject.tag + " Calories: 459";
                break;
            case "carrot":
                other.gameObject.SetActive(false);
                calories += 28;
                SetCountText();
                message = other.gameObject.tag + " Calories: 28";
                break;
            case "blue cheese":
                other.gameObject.SetActive(false);
                calories += 283;
                SetCountText();
                message = other.gameObject.tag + " Calories: 283";
                break;
            case "cheese":
                other.gameObject.SetActive(false);
                calories += 416;
                SetCountText();
                message = other.gameObject.tag + " Calories: 416";
                break;
            case "cherry":
                other.gameObject.SetActive(false);
                calories += 90;
                SetCountText();
                message = other.gameObject.tag + " Calories: 90";
                break;
            case "chicken":
                other.gameObject.SetActive(false);
                calories += 145;
                SetCountText();
                message = other.gameObject.tag + " Calories: 145";
                break;
            case "chili con carne":
                other.gameObject.SetActive(false);
                calories += 300;
                SetCountText();
                message = other.gameObject.tag + " Calories: 300";
                break;
            case "chip":
                other.gameObject.SetActive(false);
                calories += 30;
                SetCountText();
                message = other.gameObject.tag + " Calories: 30";
                break;
            case "bag chips":
                other.gameObject.SetActive(false);
                calories += 145;
                SetCountText();
                message = other.gameObject.tag + " Calories: 145";
                break;
            case "conconut":
                other.gameObject.SetActive(false);
                calories += 354;
                SetCountText();
                message = other.gameObject.tag + " Calories: 354";
                break;
            case "croissant":
                other.gameObject.SetActive(false);
                calories += 386;
                SetCountText();
                message = other.gameObject.tag + " Calories: 386";
                break;
            case "doughnut":
                other.gameObject.SetActive(false);
                calories += 336;
                SetCountText();
                message = other.gameObject.tag + " Calories: 336";
                break;
            case "drink01":
                other.gameObject.SetActive(false);
                calories += 37;
                SetCountText();
                message = other.gameObject.tag + " Calories: 37";
                break;
            case "drink02":
                other.gameObject.SetActive(false);
                calories += 84;
                SetCountText();
                message = other.gameObject.tag + " Calories: 84";
                break;
            case "drink03":
                other.gameObject.SetActive(false);
                calories += 70;
                SetCountText();
                message = other.gameObject.tag + " Calories: 70";
                break;
            case "fried egg":
                other.gameObject.SetActive(false);
                calories += 91;
                SetCountText();
                message = other.gameObject.tag + " Calories: 91";
                break;
            case "fries":
                other.gameObject.SetActive(false);
                calories += 312;
                SetCountText();
                message = other.gameObject.tag + " Calories: 312";
                break;
            case "grapes":
                other.gameObject.SetActive(false);
                calories += 67;
                SetCountText();
                message = other.gameObject.tag + " Calories: 67";
                break;
            case "gyoza":
                other.gameObject.SetActive(false);
                calories += 100;
                SetCountText();
                message = other.gameObject.tag + " Calories: 100";
                break;
            case "big mac":
                other.gameObject.SetActive(false);
                calories += 600;
                SetCountText();
                message = other.gameObject.tag + " Calories: 600";
                break;
            case "hotdog":
                other.gameObject.SetActive(false);
                calories += 290;
                SetCountText();
                message = other.gameObject.tag + " Calories: 290";
                break;
            case "ice cream":
                other.gameObject.SetActive(false);
                calories += 150;
                SetCountText();
                message = other.gameObject.tag + " Calories: 150";
                break;
            case "ice cream2":
                other.gameObject.SetActive(false);
                calories += 208;
                SetCountText();
                message = other.gameObject.tag + " Calories: 208";
                break;
            case "maki":
                other.gameObject.SetActive(false);
                calories += 45;
                SetCountText();
                message = other.gameObject.tag + " Calories: 45";
                break;
            case "meatball":
                other.gameObject.SetActive(false);
                calories += 197;
                SetCountText();
                message = other.gameObject.tag + " Calories: 197";
                break;
            case "mochi":
                other.gameObject.SetActive(false);
                calories += 350;
                SetCountText();
                message = other.gameObject.tag + " Calories: 350";
                break;
            case "muffin":
                other.gameObject.SetActive(false);
                calories += 377;
                SetCountText();
                message = other.gameObject.tag + " Calories: 377";
                break;
            case "mushroom":
                other.gameObject.SetActive(false);
                calories += 22;
                SetCountText();
                message = other.gameObject.tag + " Calories: 22";
                break;
            case "omelette":
                other.gameObject.SetActive(false);
                calories += 154;
                SetCountText();
                message = other.gameObject.tag + " Calories: 154";
                break;
            case "onigiri":
                other.gameObject.SetActive(false);
                calories += 220;
                SetCountText();
                message = other.gameObject.tag + " Calories: 220";
                break;
            case "onion":
                other.gameObject.SetActive(false);
                calories += 40;
                SetCountText();
                message = other.gameObject.tag + " Calories: 40";
                break;
            case "pea":
                other.gameObject.SetActive(false);
                calories += 85;
                SetCountText();
                message = other.gameObject.tag + " Calories: 85";
                break;
            case "pepper":
                other.gameObject.SetActive(false);
                calories += 20;
                SetCountText();
                message = other.gameObject.tag + " Calories: 20";
                break;
            case "pineapple":
                other.gameObject.SetActive(false);
                calories += 50;
                SetCountText();
                message = other.gameObject.tag + " Calories: 50";
                break;
            case "pizza":
                other.gameObject.SetActive(false);
                calories += 266;
                SetCountText();
                message = other.gameObject.tag + " Calories: 266";
                break;
            case "rice":
                other.gameObject.SetActive(false);
                calories += 130;
                SetCountText();
                message = other.gameObject.tag + " Calories: 130";
                break;
            case "salad":
                other.gameObject.SetActive(false);
                calories += 20;
                SetCountText();
                message = other.gameObject.tag + " Calories: 20";
                break;
            case "saucisson":
                other.gameObject.SetActive(false);
                calories += 300;
                SetCountText();
                message = other.gameObject.tag + " Calories: 300";
                break;
            case "sausage":
                other.gameObject.SetActive(false);
                calories += 300;
                SetCountText();
                message = other.gameObject.tag + " Calories: 300";
                break;
            case "shrimp":
                other.gameObject.SetActive(false);
                calories += 100;
                SetCountText();
                message = other.gameObject.tag + " Calories: 100";
                break;
            case "steak_cooked":
                other.gameObject.SetActive(false);
                calories += 300;
                message = other.gameObject.tag + " Calories: 300";
                SetCountText();
                break;
            case "steak_uncooked":
                other.gameObject.SetActive(false);
                calories += 200;
                SetCountText();
                message = other.gameObject.tag + " Calories: 200";
                break;
            case "sushi":
                other.gameObject.SetActive(false);
                calories += 250;
                SetCountText();
                message = other.gameObject.tag + " Calories: 250";
                break;
            case "sweetpepper":
                other.gameObject.SetActive(false);
                calories += 20;
                SetCountText();
                message = other.gameObject.tag + " Calories: 20";
                break;
            case "tacos":
                other.gameObject.SetActive(false);
                calories += 226;
                SetCountText();
                message = other.gameObject.tag + " Calories: 226";
                break;
            case "tempura":
                other.gameObject.SetActive(false);
                calories += 60;
                SetCountText();
                message = other.gameObject.tag + " Calories: 60";
                break;
            case "toast":
                other.gameObject.SetActive(false);
                calories += 87;
                SetCountText();
                message = other.gameObject.tag + " Calories: 87";
                break;
            case "tomato":
                other.gameObject.SetActive(false);
                calories += 17;
                SetCountText();
                message = other.gameObject.tag + " Calories: 17";
                break;
            case "watermelon":
                other.gameObject.SetActive(false);
                calories += 250;
                SetCountText();
                message = other.gameObject.tag + " Calories: 250";
                break;
            case "wine":
                other.gameObject.SetActive(false);
                calories += 82;
                SetCountText();
                message = other.gameObject.tag + " Calories: 250";
                break;
            default:
                break;

        }
        StartCoroutine(ShowMessage(message, 2));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Block"))
        {

            if (hitTime >= 2.0f)
            {
                hitTime = 0.0f;
                hitBlock.Play();
                switch (life)
                {

                    case 3:
                        Destroy(GameObject.FindWithTag("heart3"));
                        break;
                    case 2:
                        Destroy(GameObject.FindWithTag("heart2"));
                        break;
                    case 1:
                        ChangeGameOverSence();
                        Destroy(GameObject.FindWithTag("heart1"));
                        break;
                }
                life -= 1;
              }
        }
    }

    private void HandleHorizontalMove()
    {
        if (transform.position.x <= 3.8 && transform.position.x >= -3.8)
        {
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        }
        else if (transform.position.x <= -3.8)
        {
            moveVector.x = 0;
            transform.position = new Vector3(-3.8f, transform.position.y, transform.position.z);
            print(transform.position.x);
        }
        else
        {
            moveVector.x = 0;
            transform.position = new Vector3(3.8f, transform.position.y, transform.position.z);
        }

        moveVector.z = speed;
    }

    private void HandleJump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.y = verticalVelocity;
    }

    private void ChangeGameOverSence()
    {
        SceneManager.LoadScene("gameover");
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        pickText.text = message;
        pickText.enabled = true;
        yield return new WaitForSeconds(delay);
        pickText.enabled = false;
    }

    private void ChangeState(int cal)
    {
        if(cal >= 3500)
        {
            if (!isFat)
            {
                jumpForce = 4;
                speed = 3;
                transform.localScale = new Vector3(1.7f, 1, 2);
                isFat = true;
            }

        }
        else if(cal <= 1500)
        {

            if (!isThin)
            {
                jumpForce = 4;
                speed = 3;
                transform.localScale = new Vector3(0.7f, 1, 0.7f);
                isThin = true;
            }
        }
        else
        {

            if(isFat || isThin)
            {
                jumpForce = 5;
                speed = 5;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                isFat = false;
                isThin = false;
            }


        }
    }


}
