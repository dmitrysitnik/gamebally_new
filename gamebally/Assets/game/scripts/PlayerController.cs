using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public static float speed = 7;
    public static float upSpeed = 50;
    private static bool isHaveSpeedUp = false;
    private static bool isHavePickUp = false;
    private int count;
    private Rigidbody rb;
    public Text gameOver;
    public static BoxCollider bx;

    void Start()
    {

        winText.text = "";
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        gameOver.text = "";
        speed = 7;
        isHaveSpeedUp = false;
        isHavePickUp = false;
        bx = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (IsGameOver())
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }

        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//CrossPlatformInputManager.GetAxis("Horizontal");//
        float moveVertical = Input.GetAxis("Vertical");//CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// Взаимодействие с объектами
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("bSpeedUp"))
        {
            other.gameObject.SetActive(false);
            isHaveSpeedUp = true;

        }

        if (other.gameObject.CompareTag("bPickUp"))
        {
            other.gameObject.SetActive(false);
            isHavePickUp = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {            
            winText.text = "You Win!";
            StartCoroutine(GameController.Win());          
        }
    }

    public static void RestartLevel()
    {
        // reload the scene
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
    
    public bool IsGameOver()
    {
        bool isGameOver = false;
        if (rb.position.y < -2.0)
        {
            isGameOver = true;
            GameOver();
        }
        return isGameOver;     
    }

    public void GameOver()
    {
        gameOver.text = "Game Over. Press 'R' to restart";
    }

   public static IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(10.0f);
        isHaveSpeedUp = false;
        speed -= upSpeed;
    }

    public static void SpeedUp()
    {
        if(isHaveSpeedUp)
        {
            speed += upSpeed;
        }
    }

    public static void PickUp()
    {
        if (isHavePickUp)
        {
            bx.size = new Vector3(5.0f, 5.0f, 5.0f);

            //sc.radius = 0.5f;
        }
    }

    public static IEnumerator ReturnState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isHavePickUp = false;
        bx.size = new Vector3(0, 0, 0);
    }



}