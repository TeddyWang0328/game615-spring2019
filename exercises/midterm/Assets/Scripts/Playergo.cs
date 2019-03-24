using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Playergo : MonoBehaviour
{
    float moveSpeed = 1f;
    float rotateSpeed = 60f;
    float jumpForce = 0.05f;
    public Text winText;
    public Text countText;
    //NOTE: Changing this will drastically affect the jumpForce and fall speed.
    float gravityModifier = 0.2f;

    float yVelocity = 0;
    bool previousIsGroundedValue;
    private int count;
    CharacterController cc;



    //Camera controls (we can tweak these to make the camera follow differently - see Update())
    float camLookAhead = 8f;
    float camFollowBehind = 5f;
    float camFollowAbove = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the CharacterController component.
        cc = gameObject.GetComponent<CharacterController>();

        //Initialize the value of this value (what it does is described in Update())
        previousIsGroundedValue = cc.isGrounded;
        count = 0;


        SetCountText();
        winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //--- ROTATION ---
        //Rotate on the y axis based on the hAxis value
        //NOTE: If the player isn't pressing left or right, hAxis will be 0 and there will be no rotation
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);



        //--- DEALING WITH GRAVITY ---
        if (!cc.isGrounded)
        { //If we go in this block of code, cc.isGrounded is false (that's what the ! does)
          //If we're not on the ground, apply "gravity" to yVelocity
            yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

            //If we are moving upward (yVelocity > 0), and the player has released the jump button
            //start falling downward (by setting the yVelocity to 0)
            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
            {
                yVelocity = 0;
            }
        }
        else
        {
            if (!previousIsGroundedValue)
            {
                //By being in this if statement, we know we JUST landed.
                //NOTE: We know we just landed because cc.isGrounded is true (meaning
                //		on the last cc.Move() call we collided with something. This condition also
                //		required previousIsGroundedValue to be false which means we were not colliding
                //		with the ground on the previous Update.

                //Set the yVelocity to zero right when we hit the ground so that we don't accumulate 
                //a bunch of yVelocity. The CharacterController will prevent us from moving through
                //the floor, but we are managing the yVelocity ourselves, so we need to make sure
                //that it is zero when we start to fall. This is where we do that.
                yVelocity = 0;
            }

            //JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
            //make the player start moving upwards, and gravity will start slowing the movement upward
            //and eventually make the player hit the ground (thus landing in the 'if' statment above)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }

        }





        //--- TRANSLATION ---
        //Move the player forward based on the vAxis value
        //NOTE: If the player isn't pressing up or down, vAxis will be 0 and there will be no movement
        //		based on input. However, yVelocity will still move the player downward if they are
        //		not colliding with the ground anymore
        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

        //Set the amount we move in the y direction to be whatever we have gotten from simulating physics
        amountToMove.y = yVelocity;

        //This will move the player according to the forward vector and the yVelocity using the
        //CharacterController.
        cc.Move(amountToMove);

        //Store our current previousIsGroundedValue (so we can do that check to see if we just
        //landed above as described above)
        //NOTE: After cc.Move() is called, cc.isGrounded is updated to relfect whether that Move()
        //		function call collided with the ground.
        previousIsGroundedValue = cc.isGrounded;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("AG"))
        {

            other.gameObject.SetActive(false);


            count = count + 1;


            SetCountText();
        }


    }


    void SetCountText()
    {

        countText.text = "Beat enemies: " + count.ToString();


        if (count >= 1)
        {

            winText.text = "Please click the Hint button to see the key information";
            SceneManager.LoadScene("mm1");
        }
    }
}