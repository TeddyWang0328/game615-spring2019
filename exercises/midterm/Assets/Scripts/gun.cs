using UnityEngine;


using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gun : MonoBehaviour
{


    public float speed;
    public Text countText;
    public Text winText;
    


    private Rigidbody rb;
    private int count;


    void Start()
    {

        rb = GetComponent<Rigidbody>();


        count = 0;


        SetCountText();


        winText.text = "";

    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


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


    }


    void SetCountText()
    {

        countText.text = "Target: " + count.ToString();


        if (count >= 12)
        {

            winText.text = "Please click the Hint button to see the key information";
            SceneManager.LoadScene("st1");

        }
    }
}