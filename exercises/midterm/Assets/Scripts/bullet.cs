using UnityEngine;


using UnityEngine.UI;

using System.Collections;

public class bullet : MonoBehaviour
{

    private int count;
    // Start is called before the first frame update
    void Start()
    {

      





    
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

        }


    }
}
