using UnityEngine;


using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class biu : MonoBehaviour
{


    public float speed;
    public Text countText;
    public Text winText;



    
    private int count;


    void Start()
    {

        

        count = 0;


        SetCountText();


        winText.text = "";

    }


    void FixedUpdate()
    {

        

       

        
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