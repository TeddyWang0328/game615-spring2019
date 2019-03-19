using UnityEngine;

using System.Collections;

using UnityEngine.UI;

public class SL : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {



        GameObject btnObj = GameObject.Find("Wrong");

        Button btn = btnObj.GetComponent<Button>();

        btn.onClick.AddListener(delegate ()

        {

            this.GoNextScene(btnObj);

        });

    }



    // Update is called once per frame

    void Update()

    {

    }



    public void GoNextScene(GameObject NScene)

    {

        Application.LoadLevel("Youlose");

    }

}