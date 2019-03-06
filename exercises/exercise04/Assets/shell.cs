using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "enemy")
        {
            Debug.Log("Destory" + other.gameObject.name);
            Destroy(other.gameObject);


        }


    }
}
