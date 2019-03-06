using UnityEngine;

using UnityEngine.UI;

using System.Collections;

public class Move : MonoBehaviour
{
    public float speed = 2; //[1] object moving speed
    public Transform[] target;  // [2]  target
    public float delta = 0.2f; //error value
    private static int i = 0;


    void Update()
    {
        moveTo();


    }

    void moveTo()
    {

        target[i].position = new Vector3(target[i].position.x, transform.position.y, target[i].position.z);

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
        if (other.gameObject.name == "Chicken")
        {
            Debug.Log("Destory" + other.gameObject.name);
            Destroy(other.gameObject);


        }


    }
}