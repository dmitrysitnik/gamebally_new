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
    public float speed;
    public float upSpeed;
    private int count;
    private Rigidbody rb;
    public Text gameOver;

    void Start()
    {

        winText.text = "";
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        gameOver.text = "";

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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Bonus"))
        {
            other.gameObject.SetActive(false);
            speed += upSpeed;
            StartCoroutine(SpeedDown());
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

    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(10.0f);
        speed -= upSpeed;
    }
}