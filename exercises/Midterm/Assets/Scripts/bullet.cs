using UnityEngine;


using UnityEngine.UI;

using System.Collections;

public class bullet : MonoBehaviour
{
    public Text countText;
    public Text winText;

    private int count;
    // Start is called before the first frame update
    void Start()
    {

        count = 0;


        SetCountText();


        winText.text = "";
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}
