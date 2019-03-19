
using UnityEngine;

using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Travel: MonoBehaviour
{
    public float speed = 2; //[1] object moving speed
    public Transform[] target;  // [2]  target
    public float delta = 0.2f; //error value
    private static int i = 0;
    public Text loseText;
    public GameObject playerPrefab;

    void Start()
    {
        loseText.text = "";
    }

    void Update()
    {
        moveTo();


    }

    void moveTo()
    {



        // [4] Bring the object towards the target point 
        transform.LookAt(target[i]);

        // [5] The object moves forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // [6] Determine whether the object has reached the target point
        if (transform.position.x > target[i].position.x - delta
            && transform.position.x < target[i].position.x + delta
            && transform.position.z > target[i].position.z - delta
            && transform.position.z < target[i].position.z + delta)
            i = (i + 1) % target.Length;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Destory" + other.gameObject.name);
            Destroy(other.gameObject);
            setloseText();

        }

        void setloseText()
        {
            loseText.text = "You lose";
            playerPrefab.gameObject.SetActive(false);
        }
    }
}