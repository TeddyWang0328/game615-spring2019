using UnityEngine;

using System.Collections;

using UnityEngine.UI;

public class Killerchoose : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {



        GameObject btnObj = GameObject.Find("Truth");

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

        Application.LoadLevel("Killerchoose");

    }

}