using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{

    public float forwardSpeed = 15f;
    public float rollSpeed = 35f;
    public float pitchSpeed = 20f;

    public float pitchSpeedRate = 5f;

    float cameraFollowBehindAmount = 15;
    float cameraFollowAboveAmount = 5;

    public GameObject shitPrefab;
    public float shitLaunchForce = 1000f;

    public Text winText;
    public Text countText;
    private int count;

    Rigidbody rigidbody;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

        count = 0;


        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Get the up/down/left/right input values
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //Rotate
        transform.Rotate(vAxis * rollSpeed * Time.deltaTime, hAxis * pitchSpeed / 4 * Time.deltaTime, -hAxis * pitchSpeed * Time.deltaTime, Space.Self);

       



        //Move the plane and keep it above the terrain height
        transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainHeight)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject football = Instantiate(shitPrefab, transform.position + transform.forward * 5, transform.rotation);
            Rigidbody footballRB = football.GetComponent<Rigidbody>();
            footballRB.AddForce(transform.forward * shitLaunchForce);
        }

        //Position the camera
        Camera.main.transform.position = transform.position + -transform.forward * cameraFollowBehindAmount + Vector3.up * cameraFollowAboveAmount;
        Camera.main.transform.LookAt(transform);
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

        countText.text = "mission: " + count.ToString();


        if (count >= 1)
        {

            winText.text = "Kiss landing！Please click the Hint button to see the key information";
        }
    }
}