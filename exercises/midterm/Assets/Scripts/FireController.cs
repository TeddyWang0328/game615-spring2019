using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject shellPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public float shellSpeed = 20;


    private Transform firePosition;

    // Start is called before the first frame update
    void Start()
    {
        firePosition = transform.Find("Fireposition");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            GameObject Player = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            Player.GetComponent<Rigidbody>().velocity = Player.transform.forward * shellSpeed;
        }
    }
}